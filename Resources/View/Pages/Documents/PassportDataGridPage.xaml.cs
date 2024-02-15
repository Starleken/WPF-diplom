using Diplom.Resources.Model;
using Diplom.Resources.Scripts.Interfaces;
using Diplom.Resources.Scripts.Util;
using Diplom.Resources.View.Windows;
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
    public partial class PassportDataGridPage : Page, IUnigue, IDocumentPage
    {
        private PassportDataGridViewModel viewModel;
        private Frame frameContainer;

        public PassportDataGridPage(Frame frameContainer, StudentEntity student)
        {
            InitializeComponent();
            viewModel = new PassportDataGridViewModel(student);
            DataContext = viewModel;
            this.frameContainer = frameContainer;

            InitByRole();
        }

        private void InitByRole()
        {
            if (AuthController.CurrentUser.id != 3)
            {
                PassportsDataGrid.Columns[2].Visibility = Visibility.Collapsed;
            }
        }

        public void AddEntity()
        {
            frameContainer.Navigate(new PassportHandler(viewModel.student));
        }

        public int GetDocumentCount()
        {
            return viewModel.Passports.Count;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            PassportEntity passport = GetSelectedPassport();

            frameContainer.Navigate(new PassportHandler(passport, Scripts.HandlerOpenType.update));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            WarningWindow warningWindow = new WarningWindow("Вы уверены что хотите удалить паспорт?");
            warningWindow.ShowDialog();

            if (warningWindow.result == true)
            {
                viewModel.DeletePassport(GetSelectedPassport());
            }
        }

        private PassportEntity GetSelectedPassport()
        {
            return (PassportEntity)PassportsDataGrid.SelectedItem;
        }

        private void PassportsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PassportEntity passport = GetSelectedPassport();

            frameContainer.Navigate(new PassportHandler(passport, Scripts.HandlerOpenType.watch));
        }
    }
}
