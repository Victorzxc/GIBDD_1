using System.Windows;
using YourProjectName;

namespace GIBDD_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AccidentsButton_Click(object sender, RoutedEventArgs e)
        {
            AccidentsWindow accidentsWindow = new AccidentsWindow();
            accidentsWindow.Show();
            Close();
        }

        private void DriversButton_Click(object sender, RoutedEventArgs e)
        {
            DriversWindow driversWindow = new DriversWindow();
            driversWindow.Show();
            Close();
        }
        private void OfficersButton_Click(object sender, RoutedEventArgs e)
        {
            OfficersWindow officersWindow = new OfficersWindow();
            officersWindow.Show();
            Close();
        }
        private void ViolationsButton_Click(object sender, RoutedEventArgs e)
        {
            ViolationsWindow violationsWindow = new ViolationsWindow();
            violationsWindow.Show();
            Close();
        }
        private void VehiclesButton_Click(object sender, RoutedEventArgs e)
        {
            VehiclesWindow vehiclesWindow = new VehiclesWindow();
            vehiclesWindow.Show();
            Close();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close(); 
        }
    }
}
