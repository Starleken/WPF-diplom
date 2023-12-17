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
    /// Interaction logic for StudentDocumentsPage.xaml
    /// </summary>
    public partial class StudentDocumentsPage : Page
    {
        private StudentDocumentsViewModel viewModel;

        private Frame pageContainer;

        public StudentDocumentsPage(User user, Frame pageContainer)
        {
            InitializeComponent();

            this.pageContainer = pageContainer;
            viewModel = new StudentDocumentsViewModel(user);

            DataContext = viewModel;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StudentsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Student student = GetSelectedStudent();

            if(student == null)
            {
                return;
            }

            pageContainer.Navigate(new DocumentsPage(student));
        }

        private Student GetSelectedStudent()
        {
            Student student = (Student)StudentsDataGrid.SelectedItem;
            return student;
        }
    }
}
