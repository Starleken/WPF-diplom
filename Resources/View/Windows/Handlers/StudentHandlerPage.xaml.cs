using Diplom.Resources.Model;
using Diplom.Resources.Scripts;
using Diplom.Resources.ViewModel.Handlers;
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

namespace Diplom.Resources.View.Windows.Handlers
{
    /// <summary>
    /// Interaction logic for StudentHandlerPage.xaml
    /// </summary>
    public partial class StudentHandlerPage : Page
    {
        private StudentHandlerViewModel viewModel;

        public StudentHandlerPage(List<EducationFormEntity> educationForms, List<GroupEntity> groups)
        {
            InitializeComponent();
            viewModel = new StudentHandlerViewModel(educationForms, groups);
            this.DataContext = viewModel;
        }

        public StudentHandlerPage(StudentEntity student, HandlerOpenType handlerType, List<EducationFormEntity> educationForms, List<GroupEntity> groups)
        {
            InitializeComponent();
            viewModel = new StudentHandlerViewModel(student, educationForms, groups);
            this.DataContext = viewModel;

            if (handlerType == HandlerOpenType.watch)
            {
                InitWatchType();
            }
            else if (handlerType == HandlerOpenType.update)
            {
                InitUpdateType();
            }
        }

        private void InitWatchType()
        {
            AddButton.Visibility = Visibility.Collapsed;
        }

        private void InitUpdateType()
        {
            AddButton.Visibility = Visibility.Collapsed;
            ChangeButton.Visibility = Visibility.Visible;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddStudent();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.PutStudent();
        }
    }
}
