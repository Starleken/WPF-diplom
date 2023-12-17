using Diplom.Resources.Model;
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
    /// Interaction logic for StudentAchievementsPage.xaml
    /// </summary>
    public partial class StudentAchievementsPage : Page
    {
        private StudentAchievementsViewModel viewModel;
        private Frame pageContainer;

        private User user;

        public StudentAchievementsPage(User user, Frame pageContainer)
        {
            InitializeComponent();

            this.user = user;

            viewModel = new StudentAchievementsViewModel(user);
            DataContext = viewModel;

            this.pageContainer = pageContainer;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.SearchStudentsByFullName(SearchTextBox.Text);
        }

        private void StudentsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Student student = GetSelectedStudent();

            if (student == null)
            {
                return;
            }

            pageContainer.Navigate(new AchievementsPage(pageContainer, user, student));
        }

        private Student GetSelectedStudent()
        {
            return (Student)StudentsDataGrid.SelectedItem;
        }
    }
}
