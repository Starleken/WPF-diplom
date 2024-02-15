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
    /// Interaction logic for SnilsDataGridPage.xaml
    /// </summary>
    public partial class SnilsDataGridPage : Page, IUnigue, IDocumentPage
    {
        private SnilsDataGridViewModel viewModel;
        private Frame frameContainer;

        public SnilsDataGridPage(Frame frameContainer, StudentEntity student)
        {
            InitializeComponent();

            this.frameContainer = frameContainer;
            viewModel = new SnilsDataGridViewModel(student);
            DataContext = viewModel;

            InitByRole();
        }

        private void InitByRole()
        {
            if (AuthController.CurrentUser.id != 3)
            {
                SnilsDataGrid.Columns[1].Visibility = Visibility.Collapsed;
            }
        }

        public void AddEntity()
        {
            frameContainer.Navigate(new SnilsHandler(viewModel.student));
        }

        public int GetDocumentCount()
        {
            return viewModel.Snilses.Count;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            SnilsEntity snils = GetSelectedSnils();

            if (snils != null)
            {
                frameContainer.Navigate(new SnilsHandler(GetSelectedSnils(), Scripts.HandlerOpenType.update));
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            WarningWindow warningWindow = new WarningWindow("Вы уверены что хотите удалить снилс?");
            warningWindow.ShowDialog();

            if (warningWindow.result == true)
            {
                viewModel.DeleteSnils(GetSelectedSnils());
            }
        }

        private SnilsEntity GetSelectedSnils()
        {
            return (SnilsEntity)SnilsDataGrid.SelectedItem;
        }

        private void SnilsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SnilsEntity snils = GetSelectedSnils();

            if (snils != null)
            {
                frameContainer.Navigate(new SnilsHandler(GetSelectedSnils(), Scripts.HandlerOpenType.watch));
            }
        }
    }
}
