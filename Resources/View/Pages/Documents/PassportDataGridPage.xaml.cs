using Diplom.Resources.Model;
using Diplom.Resources.View.Windows.Documents;
using Diplom.Resources.ViewModel.Documents;
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

namespace Diplom.Resources.View.Pages.Documents
{
    /// <summary>
    /// Interaction logic for PassportDataGridPage.xaml
    /// </summary>
    public partial class PassportDataGridPage : Page
    {
        private PassportDataGridViewModel viewModel;
        private Frame frameContainer;

        public PassportDataGridPage(Frame frameContainer, StudentEntity student)
        {
            InitializeComponent();
            viewModel = new PassportDataGridViewModel(student);
            DataContext = viewModel;
            this.frameContainer = frameContainer;
        }

        public void AddPassport()
        {
            frameContainer.Navigate(new PassportHandler(viewModel.student));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            PassportEntity passport = GetSelectedPassport();

            frameContainer.Navigate(new PassportHandler(passport, Scripts.HandlerOpenType.update));
        }

        private PassportEntity GetSelectedPassport()
        {
            return (PassportEntity)PassportsDataGrid.SelectedItem;
        }
    }
}
