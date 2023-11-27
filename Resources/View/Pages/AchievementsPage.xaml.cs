using Diplom.Resources.Model.Activity;
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

        public AchievementsPage()
        {
            InitializeComponent();

            viewModel = new AchievementsViewModel();
            this.DataContext = viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ActivityHandler activityHandler = new ActivityHandler();
            activityHandler.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Activity selectedActivity = GetSelectedActivity();

            ActivityHandler activityHandler = new ActivityHandler();
            activityHandler.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            WarningWindow window = new WarningWindow("Вы уверены что хотите удалить?");
            window.ShowDialog();

            Activity selectedActivity = GetSelectedActivity();

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

        private Activity GetSelectedActivity()
        {
            Activity selectedActivity = (Activity)ActivitiesDataGrid.SelectedItem;

            return selectedActivity;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.SearchActivitiesByName(SearchTextBox.Text);
        }
    }
}
