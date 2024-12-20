using System;
using System.Windows;
using GIBDD_1.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
namespace GIBDD_1
{
    public partial class AddVehicleWindow : Window
    {
        private GIBDDContext _context;
        public AddVehicleWindow()
        {
            InitializeComponent();
            _context = new GIBDDContext();
            LoadDrivers();
        }
        private void LoadDrivers()
        {
            DriverComboBox.ItemsSource = _context.Drivers.ToList();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var newVehicle = new Vehicles
            {
                RegistrationNumber = RegistrationNumberTextBox.Text,
                Vin = VinTextBox.Text,
                Make = MakeTextBox.Text,
                Model = ModelTextBox.Text,
                Year = int.Parse(YearTextBox.Text),
                DriverId = (DriverComboBox.SelectedItem as Drivers)?.DriverId ?? 0
            };
            using (var context = new GIBDDContext())
            {
                context.Vehicles.Add(newVehicle);
                context.SaveChanges();
            }
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
