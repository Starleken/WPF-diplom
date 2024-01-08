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
    /// Interaction logic for FluVaccineDataGridPage.xaml
    /// </summary>
    public partial class FluVaccineDataGridPage : Page
    {
        private FluVaccineDataGridViewModel viewModel;
        private Frame frameContainer;

        public FluVaccineDataGridPage(Frame frameContainer, StudentEntity student)
        {
            InitializeComponent();

            viewModel = new FluVaccineDataGridViewModel(student);

            DataContext = viewModel;

            this.frameContainer = frameContainer;
        }

        public void AddFluVaccine()
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
    }
}
