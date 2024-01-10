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
    /// Interaction logic for FluVaccineDataGridPage.xaml
    /// </summary>
    public partial class FluVaccineDataGridPage : Page, IDocumentPage
    {
        private FluVaccineDataGridViewModel viewModel;
        private Frame frameContainer;

        public FluVaccineDataGridPage(Frame frameContainer, StudentEntity student)
        {
            InitializeComponent();

            viewModel = new FluVaccineDataGridViewModel(student);

            DataContext = viewModel;

            this.frameContainer = frameContainer;

            InitByRole();
        }

        private void InitByRole()
        {
            if (AuthController.CurrentUser.id != 3)
            {
                FluVaccinesDataGrid.Columns[1].Visibility = Visibility.Collapsed;
            }
        }

        public void AddEntity()
        {
            frameContainer.Navigate(new FluVaccineHandler(viewModel.student));
        }

        private FluVaccineEntity GetSelectedFluVaccine()
        {
            return (FluVaccineEntity)FluVaccinesDataGrid.SelectedItem;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            FluVaccineEntity fluVaccine = GetSelectedFluVaccine();

            if (fluVaccine != null)
            {
                frameContainer.Navigate(new FluVaccineHandler(fluVaccine, Scripts.HandlerOpenType.update));
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            WarningWindow warningWindow = new WarningWindow("Вы уверены что хотите удалить прививку?");
            warningWindow.ShowDialog();

            if (warningWindow.result == true)
            {
                viewModel.DeleteFluVaccine(GetSelectedFluVaccine());
            }
        }
    }
}
