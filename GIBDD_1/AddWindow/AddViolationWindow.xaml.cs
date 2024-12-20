using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GIBDD_1.Models;

namespace GIBDD_1
{
    public partial class AddViolationWindow : Window
    {
        private GIBDDContext _context;
        public AddViolationWindow()
        {
            InitializeComponent();
            _context = new GIBDDContext();
            LoadDrivers();
            LoadOfficers();
        }
        private void LoadDrivers()
        {
            DriverComboBox.ItemsSource = _context.Drivers.ToList();
        }

        private void LoadOfficers()
        {
            OfficerComboBox.ItemsSource = _context.Officers.ToList();
        }
        private void DriverComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DriverComboBox.SelectedItem is Drivers selectedDriver)
            {
                LoadVehicles(selectedDriver);
            }
            else
            {
                VehicleComboBox.ItemsSource = null;
            }
        }
        private void LoadVehicles(Drivers driver)
        {
            VehicleComboBox.ItemsSource = _context.Vehicles.Where(v => v.DriverId == driver.DriverId).ToList();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DriverComboBox.SelectedItem is Drivers selectedDriver && VehicleComboBox.SelectedItem is Vehicles selectedVehicle)
            {
                if (selectedVehicle.DriverId != selectedDriver.DriverId)
                {
                    MessageBox.Show("Выбранный автомобиль не принадлежит выбранному водителю!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            var newViolation = new Violations
            {
                DriverId = (DriverComboBox.SelectedItem as Drivers)?.DriverId ?? 0,
                VehicleId = (VehicleComboBox.SelectedItem as Vehicles)?.VehicleId ?? 0,
                ViolationCode = ViolationCodeTextBox.Text,
                ViolationTypeId = int.Parse(ViolationTypeIdTextBox.Text),
                Location = LocationTextBox.Text,
                FineAmount = decimal.Parse(FineAmountTextBox.Text),
                OfficerId = (OfficerComboBox.SelectedItem as Officers)?.OfficerId ?? 0,
                PaymentStatus = PaymentStatusTextBox.Text
            };
            _context.Violations.Add(newViolation);
            _context.SaveChanges();
            DialogResult = true;
            Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}