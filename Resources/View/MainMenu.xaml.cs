using Diplom.Resources.Model;
using Diplom.Resources.Scripts;
using Diplom.Resources.Scripts.HttpRequests;
using Diplom.Resources.View.Pages;
using Diplom.Resources.ViewModel;
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
using System.Windows.Shapes;

namespace Diplom.Resources.View
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private MainMenuViewModel viewModel;

        private Dictionary<string, MenuButtonContainer> menuButtons;

        public MainMenu(User user)
        {
            InitializeComponent();

            viewModel = new MainMenuViewModel(user);
            this.DataContext = viewModel;

            InitButtons();
            InitByRole();

            AchievementsButton_Click(null, null);
        }

        private void InitButtons()
        {
            menuButtons = new Dictionary<string, MenuButtonContainer>();
            menuButtons.Add("DocumentsButton", new MenuButtonContainer(DocumentsButton, DocumentsActivity));
            menuButtons.Add("AchievementsButton", new MenuButtonContainer(AchievementsButton, AchievementsActivity));
            menuButtons.Add("StudentsButton", new MenuButtonContainer(StudentsButton, StudentsActivity));
            menuButtons.Add("PassesButton", new MenuButtonContainer(PassesButton, PassesActivity));
        }

        private void InitByRole()
        {
            string roleName = viewModel.User.role.name;

            if (roleName == "Куратор")
                InitByCurator();
            else if (roleName == "Студент")
                InitByStudent();
        }

        private void InitByCurator()
        {
        }

        private void InitByStudent()
        {
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            ExitToAvtorizationWindow();
        }

        private void ExitToAvtorizationWindow()
        {
            AvtorizationWidnow avtorizationWidnow = new AvtorizationWidnow();
            avtorizationWidnow.Show();

            this.Close();
        }

        private void DocumentsButton_Click(object sender, RoutedEventArgs e)
        {
            DisableActivityButtons();
            menuButtons["DocumentsButton"].ActivateButton();
            NavigateTo(new DocumentsPage());
        }

        private void PassesButton_Click(object sender, RoutedEventArgs e)
        {
            DisableActivityButtons();
            menuButtons["PassesButton"].ActivateButton();
            NavigateTo(new PassesPage());
        }

        private void AchievementsButton_Click(object sender, RoutedEventArgs e)
        {
            DisableActivityButtons();
            menuButtons["AchievementsButton"].ActivateButton();

            AchievementsActivity.Visibility = Visibility.Visible;
            NavigateTo(new AchievementsPage());
        }

        private void StudentsButton_Click(object sender, RoutedEventArgs e)
        {
            DisableActivityButtons();
            menuButtons["StudentsButton"].ActivateButton();

            NavigateTo(new StudentsPage());
        }

        private void NavigateTo(Page page)
        {
            FrameContainer.Navigate(page);
        }

        private void DisableActivityButtons()
        {
            foreach(var buttons in menuButtons)
            {
                buttons.Value.DeactivateButton();
            }
        }

        private void ExitApplicationButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ExpandWindowButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                return;
            }

            this.WindowState = WindowState.Maximized;
        }

        private void minimizeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
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
