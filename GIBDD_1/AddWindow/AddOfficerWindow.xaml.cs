using System;
using System.Windows;
using GIBDD_1.Models; 
using System.Collections.ObjectModel;

namespace GIBDD_1
{
    public partial class AddOfficerWindow : Window
    {

        public AddOfficerWindow()
        {
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var newOfficer = new Officers
            {
                LastName = LastNameTextBox.Text,
                FirstName = FirstNameTextBox.Text,
                MiddleName = MiddleNameTextBox.Text,
                OfficerNumber = OfficerNumberTextBox.Text,
                Title = TitleTextBox.Text
            };
            using (var context = new GIBDDContext())
            {
                context.Officers.Add(newOfficer);
                context.SaveChanges();
            }

            DialogResult = true; // Закрыть окно и вернуть true.
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Закрыть окно и вернуть false.
            Close();
        }
    }
}
