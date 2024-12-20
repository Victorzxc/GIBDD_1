using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using GIBDD_1.Models; 
using System.Text; 

namespace GIBDD_1
{
    public partial class LoginWindow : Window
    {
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string lastName = LastNameTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string middleName = MiddleNameTextBox.Text;
            string officerNumber = OfficerNumberTextBox.Text;

            using (var context = new GIBDDContext())
            {
                // Важно:  Проверка на пустые поля
                if (string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(middleName) || string.IsNullOrEmpty(officerNumber))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Прерываем выполнение, если поля пустые
                }

                var officer = context.Officers.FirstOrDefault(o => o.LastName == lastName &&
                                                                  o.FirstName == firstName &&
                                                                  o.MiddleName == middleName &&
                                                                  o.OfficerNumber == officerNumber);

                if (officer != null)
                {
                    // Авторизация успешна
                    MessageBox.Show("Вход выполнен успешно.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show(); // Отображаем главное окно
                    this.Close(); // Закрываем окно авторизации
                }
                else
                {
                    // Авторизация не удалась
                    MessageBox.Show("Неверные данные для входа.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
