using Diplom.Resources.Model;
using Diplom.Resources.Scripts.Exeptions;
using Diplom.Resources.Scripts.HttpRequests;
using Diplom.Resources.Scripts.Util;
using Diplom.Resources.View;
using Diplom.Resources.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diplom
{
    /// <summary>
    /// Interaction logic for AvtorizationWidnow.xaml
    /// </summary>
    public partial class AvtorizationWidnow : Window
    {
        private UserEntity[] users;

        public AvtorizationWidnow()
        {
            InitializeComponent();

            EnterButton.IsEnabled = false;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            EnterMainMenu();
        }

        private void EnterMainMenu()
        {
            AuthController authController = new AuthController();

            try
            {
                authController.AuthByLoginAndPassword(LoginTextBox.Text, PasswordTextBox.Text);
            }
            catch (AuthException ex)
            {
                new ErrorWindow(ex.Message).ShowDialog();
                return;
            }

            MainMenu mainMenu = new MainMenu(AuthController.CurrentUser);
            mainMenu.Show();

            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(LoginTextBox.Text) | String.IsNullOrEmpty(PasswordTextBox.Text))
            {
                EnterButton.IsEnabled = false;
            }
            else
            {
                EnterButton.IsEnabled = true;
            }
        }

        private void ExitApplicationButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
