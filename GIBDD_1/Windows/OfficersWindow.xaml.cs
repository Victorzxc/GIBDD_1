using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel; 
using GIBDD_1.Models;
using GIBDD_1;

namespace YourProjectName
{
    public partial class OfficersWindow : Window
    {
        private GIBDDContext _context; // Контекст БД
        public ObservableCollection<Officers> Officers { get; set; }

        public OfficersWindow()
        {
            InitializeComponent();
            // Установка соединения с БД
            _context = new GIBDDContext();
            LoadOfficers();
        }

        private void LoadOfficers()
        {
            Officers = new ObservableCollection<Officers>(_context.Officers.ToList());
            OfficersDataGrid.ItemsSource = Officers;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text;
            if (string.IsNullOrEmpty(searchText))
            {
                LoadOfficers();
                return;
            }
            var filteredOfficers = _context.Officers.Where(o => o.LastName.Contains(searchText) ||
                                                                   o.FirstName.Contains(searchText) ||
                                                                   o.OfficerNumber.Contains(searchText)).ToList();
            Officers = new ObservableCollection<Officers>(filteredOfficers);
            OfficersDataGrid.ItemsSource = Officers;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addOfficerWindow = new AddOfficerWindow();
            if (addOfficerWindow.ShowDialog() == true)
            {
                // Обновить список офицеров.
                LoadOfficers();
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
            if (OfficersDataGrid.SelectedItem is Officers selectedOfficer)
            {
                _context.Officers.Remove(selectedOfficer);
                _context.SaveChanges();
                LoadOfficers();
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        private void OfficersDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
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
