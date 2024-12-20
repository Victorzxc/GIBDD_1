using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using GIBDD_1.Models; 

namespace GIBDD_1
{
    public partial class AccidentParticipantsWindow : Window
    {
        private GIBDDContext _context; // Контекст БД
        public ObservableCollection<AccidentParticipants> Participants { get; set; }
        private int _accidentId;
        public AccidentParticipantsWindow(int accidentId)
        {
            InitializeComponent();
            _accidentId = accidentId;
            _context = new GIBDDContext();
            LoadParticipants();

        }
        private void LoadParticipants()
        {
            Participants = new ObservableCollection<AccidentParticipants>(_context.AccidentParticipants.Where(p => p.AccidentId == _accidentId).ToList());
            ParticipantsDataGrid.ItemsSource = Participants;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addParticipantWindow = new AddAccidentParticipantWindow(_accidentId);
            if (addParticipantWindow.ShowDialog() == true)
            {
                LoadParticipants();
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
            if (ParticipantsDataGrid.SelectedItem is AccidentParticipants selectedParticipant)
            {
                _context.AccidentParticipants.Remove(selectedParticipant);
                _context.SaveChanges();
                LoadParticipants();
            }
            else
            {
                MessageBox.Show("Выберите участника ДТП для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AccidentsWindow accidentsWindow = new AccidentsWindow();
            accidentsWindow.Show();
            Close();
        }
        private void AccidentParticipantsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
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
