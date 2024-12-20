using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using GIBDD_1.Models; 

namespace GIBDD_1
{
    public partial class AccidentsWindow : Window
    {
        private GIBDDContext _context; // Контекст БД
        public ObservableCollection<Accidents> Accidents { get; set; }
        public AccidentsWindow()
        {
            InitializeComponent();
            _context = new GIBDDContext();
            LoadAccidents();
        }
        private void LoadAccidents()
        {
            Accidents = new ObservableCollection<Accidents>(_context.Accidents.ToList());
            AccidentsDataGrid.ItemsSource = Accidents;
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text;
            if (string.IsNullOrEmpty(searchText))
            {
                LoadAccidents();
                return;
            }
            var filteredAccidents = _context.Accidents.Where(a => a.Location.Contains(searchText) ||
                                                                    a.Description.Contains(searchText) ||
                                                                    a.DateTime.ToString().Contains(searchText)).ToList();
            Accidents = new ObservableCollection<Accidents>(filteredAccidents);
            AccidentsDataGrid.ItemsSource = Accidents;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addAccidentWindow = new AddAccidentWindow();
            if (addAccidentWindow.ShowDialog() == true)
            {
                LoadAccidents();
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
            if (AccidentsDataGrid.SelectedItem is Accidents selectedAccident)
            {
                _context.Accidents.Remove(selectedAccident);
                _context.SaveChanges();
                LoadAccidents();
            }
            else
            {
                MessageBox.Show("Выберите ДТП для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ParticipantsButton_Click(object sender, RoutedEventArgs e)
        {
            if (AccidentsDataGrid.SelectedItem is Accidents selectedAccident)
            {
                AccidentParticipantsWindow participantsWindow = new AccidentParticipantsWindow(selectedAccident.AccidentId);
                participantsWindow.Show();
            }
            else
            {
                MessageBox.Show("Выберите ДТП для просмотра участников.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        private void AccidentsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
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
