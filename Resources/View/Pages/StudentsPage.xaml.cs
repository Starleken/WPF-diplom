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

        public StudentsPage(User user)
        {
            InitializeComponent();

            groups = new GroupRepository().GetAll().ToList();
            educationForms = new EducationFormRepository().GetAll().ToList();

            viewModel = new StudentsViewModel(user);
            this.DataContext = viewModel;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.SearchStudentsByFullName(SearchTextBox.Text);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            StudentHandler studentHandler = new StudentHandler(educationForms, groups);
            studentHandler.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            StudentHandler studentHandler = new StudentHandler(GetSelectedStudent(), HandlerOpenType.update, educationForms, groups);
            studentHandler.ShowDialog();
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
            StudentHandler studentHandler = new StudentHandler(GetSelectedStudent(), HandlerOpenType.watch, educationForms, groups);
            studentHandler.ShowDialog();
        }
    }
}
