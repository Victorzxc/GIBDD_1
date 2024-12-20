using System;
using System.Windows;
using GIBDD_1.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace GIBDD_1
{
    public partial class AddDriverWindow : Window
    {
        public AddDriverWindow()
        {
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var newDriver = new Drivers
            {
                LastName = LastNameTextBox.Text,
                FirstName = FirstNameTextBox.Text,
                MiddleName = MiddleNameTextBox.Text,
                DateOfBirth = DateTime.Parse(DateOfBirthTextBox.Text),
                DriverLicenseNumber = DriverLicenseNumberTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text
            };
            using (var context = new GIBDDContext())
            {
                context.Drivers.Add(newDriver);
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