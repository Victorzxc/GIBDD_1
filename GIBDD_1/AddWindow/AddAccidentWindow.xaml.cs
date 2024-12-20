using System;
using System.Windows;
using GIBDD_1.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace GIBDD_1
{
    public partial class AddAccidentWindow : Window
    {
        public AddAccidentWindow()
        {
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var newAccident = new Accidents
            {
                DateTime = DateTime.Parse(DateTimeTextBox.Text),
                Location = LocationTextBox.Text,
                Description = DescriptionTextBox.Text,
                OfficerId = int.Parse(OfficerIdTextBox.Text),
                RuleId = int.Parse(RuleIdTextBox.Text)
            };
            using (var context = new GIBDDContext())
            {
                context.Accidents.Add(newAccident);
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
