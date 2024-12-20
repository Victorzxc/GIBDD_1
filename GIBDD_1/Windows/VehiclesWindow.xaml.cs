using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using GIBDD_1.Models; 

namespace GIBDD_1
{
    public partial class VehiclesWindow : Window
    {
        private GIBDDContext _context; // Контекст БД
        public ObservableCollection<Vehicles> Vehicles { get; set; }

        public VehiclesWindow()
        {
            InitializeComponent();
            _context = new GIBDDContext();
            LoadVehicles();
        }
        private void LoadVehicles()
        {
            Vehicles = new ObservableCollection<Vehicles>(_context.Vehicles.ToList());
            VehiclesDataGrid.ItemsSource = Vehicles;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text;
            if (string.IsNullOrEmpty(searchText))
            {
                LoadVehicles();
                return;
            }
            var filteredVehicles = _context.Vehicles.Where(v => v.RegistrationNumber.Contains(searchText) ||
                                                                 v.Vin.Contains(searchText) ||
                                                                 v.Make.Contains(searchText) ||
                                                                 v.Model.Contains(searchText)).ToList();
            Vehicles = new ObservableCollection<Vehicles>(filteredVehicles);
            VehiclesDataGrid.ItemsSource = Vehicles;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addVehicleWindow = new AddVehicleWindow();
            if (addVehicleWindow.ShowDialog() == true)
            {
                LoadVehicles();
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
            if (VehiclesDataGrid.SelectedItem is Vehicles selectedVehicle)
            {
                _context.Vehicles.Remove(selectedVehicle);
                _context.SaveChanges();
                LoadVehicles();
            }
            else
            {
                MessageBox.Show("Выберите автомобиль для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        private void VehiclesDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
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
