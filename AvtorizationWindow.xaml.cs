using Diplom.Resources.Model;
using Diplom.Resources.Scripts.HttpRequests;
using Diplom.Resources.View;
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
        private User[] users;

        public AvtorizationWidnow()
        {
            InitializeComponent();

            EnterButton.IsEnabled = false;

            UserGetter userGetter = new UserGetter();
            users = userGetter.GetAll();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            EnterMainMenu();
        }

        private void EnterMainMenu()
        {
            User user;

            try
            {
                user = GetUserByAvtorizationData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            MainMenu mainMenu = new MainMenu(user);
            mainMenu.Show();

            this.Close();
        }

        private User GetUserByAvtorizationData()
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;

            User user = users.FirstOrDefault(x => x.login == login && x.password == password);

            if (user == null)
            {
                throw new NullReferenceException("Пользователь не найден");
            }

            return user;
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
