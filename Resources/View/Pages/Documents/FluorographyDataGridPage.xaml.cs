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
    /// Interaction logic for FluorographyDataGridPage.xaml
    /// </summary>
    public partial class FluorographyDataGridPage : Page, IUnigue, IDocumentPage
    {
        private FluorographyDataGridViewModel viewModel;
        private Frame frameContainer;

        public FluorographyDataGridPage(Frame frameContainer, StudentEntity student)
        {
            InitializeComponent();

            viewModel = new FluorographyDataGridViewModel(student);

            DataContext = viewModel;

            this.frameContainer = frameContainer;

            InitByRole();
        }

        private void InitByRole()
        {
            if (AuthController.CurrentUser.id != 3)
            {
                FluorographiesDataGrid.Columns[2].Visibility = Visibility.Collapsed;
            }
        }

        public void AddEntity()
        {
            frameContainer.Navigate(new FluorographyHandler(viewModel.student));
        }

        public int GetDocumentCount()
        {
            return viewModel.Fluorographies.Count;
        }

        private FluorographyEntity GetSelectedFluorography()
        {
            return (FluorographyEntity)FluorographiesDataGrid.SelectedItem;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            FluorographyEntity fluorography = GetSelectedFluorography();

            if (fluorography != null)
            {
                frameContainer.Navigate(new FluorographyHandler(fluorography, Scripts.HandlerOpenType.update));
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            WarningWindow warningWindow = new WarningWindow("Вы уверены что хотите удалить флюорографию?");
            warningWindow.ShowDialog();

            if (warningWindow.result == true)
            {
                viewModel.DeleteFluorography(GetSelectedFluorography());
            }
        }

        private void FluorographiesDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FluorographyEntity fluorography = GetSelectedFluorography();

            if (fluorography != null)
            {
                frameContainer.Navigate(new FluorographyHandler(fluorography, Scripts.HandlerOpenType.watch));
            }
        }
    }
}
