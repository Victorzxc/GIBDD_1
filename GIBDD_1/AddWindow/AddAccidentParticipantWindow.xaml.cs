using System;
using System.Windows;
using GIBDD_1.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace GIBDD_1
{
    public partial class AddAccidentParticipantWindow : Window
    {
        private int _accidentId;
        public AddAccidentParticipantWindow(int accidentId)
        {
            InitializeComponent();
            _accidentId = accidentId;
            LoadComboBoxes();
        }
        private void LoadComboBoxes()
        {
            using (var context = new GIBDDContext())
            {
                DriverComboBox.ItemsSource = context.Drivers.ToList();
                VehicleComboBox.ItemsSource = context.Vehicles.ToList();
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var newParticipant = new AccidentParticipants
            {
                AccidentId = _accidentId,
                DriverId = (DriverComboBox.SelectedItem as Drivers)?.DriverId ?? 0,
                VehicleId = (VehicleComboBox.SelectedItem as Vehicles)?.VehicleId ?? 0,
                Role = RoleTextBox.Text
            };
            using (var context = new GIBDDContext())
            {
                context.AccidentParticipants.Add(newParticipant);
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
