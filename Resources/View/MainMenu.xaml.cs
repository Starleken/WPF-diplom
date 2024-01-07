using Diplom.Resources.Model;
using Diplom.Resources.Scripts;
using Diplom.Resources.Scripts.HttpRequests;
using Diplom.Resources.Scripts.HttpRequests.Repository;
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

        private UserEntity user;

        public MainMenu(UserEntity user)
        {
            InitializeComponent();

            this.user = user;

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
            menuButtons.Add("CuratorsButton", new MenuButtonContainer(CuratorsButton, CuratorsActivity));
            menuButtons.Add("ProfileButton", new MenuButtonContainer(ProfileButton, ProfileActivity));
        }

        private void InitByRole()
        {
            string roleName = viewModel.User.role.name;
            ProfileButton.Visibility = Visibility.Collapsed;

            if (roleName == "Куратор")
                InitByCurator();
            else if (roleName == "Студент")
                InitByStudent();
        }

        private void InitByCurator()
        {
            CuratorsButton.Visibility = Visibility.Collapsed;
            ProfileButton.Visibility = Visibility.Collapsed;
        }

        private void InitByStudent()
        {
            CuratorsButton.Visibility = Visibility.Collapsed;
            StudentsButton.Visibility = Visibility.Collapsed;
            ProfileButton.Visibility = Visibility.Visible;
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

            if (user.role.id == 3)
            {
                NavigateTo(new DocumentsPage(FrameContainer ,viewModel.User, new StudentRepository().GetStudentsByUser(viewModel.User.id)));
                return;
            }
            NavigateTo(new StudentDocumentsPage(viewModel.User, FrameContainer));
        }

        private void CuratorsButton_Click(object sender, RoutedEventArgs e)
        {
            DisableActivityButtons();
            menuButtons["CuratorsButton"].ActivateButton();
            NavigateTo(new CuratorPage(FrameContainer));
        }

        private void AchievementsButton_Click(object sender, RoutedEventArgs e)
        {
            DisableActivityButtons();
            menuButtons["AchievementsButton"].ActivateButton();

            if (user.role.id == 3)
            {
                AchievementsActivity.Visibility = Visibility.Visible;
                NavigateTo(new AchievementsPage(FrameContainer, viewModel.User, new StudentRepository().GetStudentsByUser(viewModel.User.id)));
            }
            else
            {
                AchievementsActivity.Visibility = Visibility.Visible;
                NavigateTo(new StudentAchievementsPage(viewModel.User, FrameContainer));
            }
        }

        private void StudentsButton_Click(object sender, RoutedEventArgs e)
        {
            DisableActivityButtons();
            menuButtons["StudentsButton"].ActivateButton();

            NavigateTo(new StudentsPage(viewModel.User, FrameContainer));
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

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            DisableActivityButtons();
            menuButtons["ProfileButton"].ActivateButton();
            NavigateTo(new ProfilPage(viewModel.User));
        }
    }
}
