using Diplom.Resources.Model;
using Diplom.Resources.Model.Activity;
using Diplom.Resources.Scripts;
using Diplom.Resources.View.Windows;
using Diplom.Resources.View.Windows.Handlers;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diplom.Resources.View.Pages
{
    /// <summary>
    /// Interaction logic for AchievementsPage.xaml
    /// </summary>
    public partial class AchievementsPage : Page
    {
        private AchievementsViewModel viewModel;
        private Frame frameContainer;

        public AchievementsPage(Frame frameContainer, UserEntity user, StudentEntity student)
        {
            InitializeComponent();

            viewModel = new AchievementsViewModel(student);
            this.DataContext = viewModel;
            this.frameContainer = frameContainer;

            InitByRole(user);
        }

        private void InitByRole(UserEntity user)
        {
            if (user.role.id != 3)
            {
                AddButton.Visibility = Visibility.Collapsed;
                ActivitiesDataGrid.Columns[4].Visibility = Visibility.Collapsed;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ActivityHandler activityHandler = new ActivityHandler(viewModel.student);
            frameContainer.Navigate(activityHandler);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            ActivityEntity selectedActivity = GetSelectedActivity();

            if (selectedActivity == null)
            {
                return;
            }

            ActivityHandler activityHandler = new ActivityHandler(viewModel.student, selectedActivity, HandlerOpenType.update);
            frameContainer.Navigate(activityHandler);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            WarningWindow window = new WarningWindow("Вы уверены что хотите удалить?");
            window.ShowDialog();

            ActivityEntity selectedActivity = GetSelectedActivity();

            if (selectedActivity == null)
            {
                ErrorWindow errorWindow = new ErrorWindow("Выберите документ");
                errorWindow.ShowDialog();
                return;
            }

            if (window.result == true)
            {
                viewModel.DeleteActivity(selectedActivity);
            }
        }

        private ActivityEntity GetSelectedActivity()
        {
            ActivityEntity selectedActivity = (ActivityEntity)ActivitiesDataGrid.SelectedItem;

            return selectedActivity;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.SearchActivitiesByName(SearchTextBox.Text);
        }

        private void AllButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
