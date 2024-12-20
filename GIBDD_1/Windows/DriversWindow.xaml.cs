using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using GIBDD_1.Models; 

namespace GIBDD_1
{
    public partial class DriversWindow : Window
    {
        private GIBDDContext _context; // Контекст БД
        public ObservableCollection<Drivers> Drivers { get; set; }

        public DriversWindow()
        {
            InitializeComponent();
            _context = new GIBDDContext();
            LoadDrivers();
        }
        private void LoadDrivers()
        {
            Drivers = new ObservableCollection<Drivers>(_context.Drivers.ToList());
            DriversDataGrid.ItemsSource = Drivers;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text;
            if (string.IsNullOrEmpty(searchText))
            {
                LoadDrivers();
                return;
            }
            var filteredDrivers = _context.Drivers.Where(o => o.LastName.Contains(searchText) ||
                                                                  o.FirstName.Contains(searchText) ||
                                                                  o.MiddleName.Contains(searchText)).ToList();
            Drivers = new ObservableCollection<Drivers>(filteredDrivers);
            DriversDataGrid.ItemsSource = Drivers;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addDriverWindow = new AddDriverWindow();
            if (addDriverWindow.ShowDialog() == true)
            {
                // Обновить список водителей.
                LoadDrivers();
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
            if (DriversDataGrid.SelectedItem is Drivers selectedDriver)
            {
                _context.Drivers.Remove(selectedDriver);
                _context.SaveChanges();
                LoadDrivers();
            }
            else
            {
                MessageBox.Show("Выберите водителя для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        private void DriversDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
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