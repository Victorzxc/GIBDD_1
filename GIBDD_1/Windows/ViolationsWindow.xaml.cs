using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using GIBDD_1.Models; 

namespace GIBDD_1
{
    public partial class ViolationsWindow : Window
    {
        private GIBDDContext _context; // Контекст БД
        public ObservableCollection<Violations> Violations { get; set; }
        public ViolationsWindow()
        {
            InitializeComponent();
            _context = new GIBDDContext();
            LoadViolations();
        }
        private void LoadViolations()
        {
            Violations = new ObservableCollection<Violations>(_context.Violations.ToList());
            ViolationsDataGrid.ItemsSource = Violations;
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text;
            if (string.IsNullOrEmpty(searchText))
            {
                LoadViolations();
                return;
            }
            var filteredViolations = _context.Violations.Where(v => v.ViolationCode.Contains(searchText)).ToList();
            Violations = new ObservableCollection<Violations>(filteredViolations);
            ViolationsDataGrid.ItemsSource = Violations;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addViolationWindow = new AddViolationWindow();
            if (addViolationWindow.ShowDialog() == true)
            {
                LoadViolations();
            }
        }
        private void SaveEditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _context.SaveChanges();
                MessageBox.Show("Изменения сохранены", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViolationsDataGrid.SelectedItem is Violations selectedViolation)
            {
                _context.Violations.Remove(selectedViolation);
                _context.SaveChanges();
                LoadViolations();
            }
            else
            {
                MessageBox.Show("Выберите нарушение для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        private void ViolationsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
