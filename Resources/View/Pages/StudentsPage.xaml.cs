using Diplom.Resources.Model;
using Diplom.Resources.Scripts;
using Diplom.Resources.Scripts.HttpRequests.Repository;
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
    /// Interaction logic for StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        private StudentsViewModel viewModel;

        private List<Group> groups;
        private List<EducationForm> educationForms;
        private Frame frame;

        public StudentsPage(User user, Frame frame)
        {
            InitializeComponent();

            groups = new GroupRepository().GetAll().ToList();
            educationForms = new EducationFormRepository().GetAll().ToList();
            this.frame = frame;

            viewModel = new StudentsViewModel(user);
            this.DataContext = viewModel;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.SearchStudentsByFullName(SearchTextBox.Text);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            StudentHandlerPage studentHandler = new StudentHandlerPage(educationForms, groups);
            frame.Navigate(studentHandler);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            StudentHandlerPage studentHandler = new StudentHandlerPage(GetSelectedStudent(), HandlerOpenType.update, educationForms, groups);
            frame.Navigate(studentHandler);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            WarningWindow warningWindow = new WarningWindow("Вы уверены что хотите удалить студента?");
            warningWindow.ShowDialog();

            if (warningWindow.result == true)
            {
                viewModel.DeleteStudent(GetSelectedStudent());
            }
        }

        private Student GetSelectedStudent()
        {
            return (Student)StudentsDataGrid.SelectedItem;
        }

        private void StudentsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            User user = GetSelectedStudent().user;

            if (user == null)
            {
                return;
            }

            ProfilPage profile = new ProfilPage(user);

            frame.Navigate(profile);
        }
    }
}
