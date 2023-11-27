using Diplom.Resources.Model;
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

        public StudentsPage()
        {
            InitializeComponent();

            viewModel = new StudentsViewModel();
            this.DataContext = viewModel;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.SearchStudentsByFullName(SearchTextBox.Text);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            StudentHandler studentHandler = new StudentHandler();
            studentHandler.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
