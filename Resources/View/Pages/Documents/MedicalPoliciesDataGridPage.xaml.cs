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
    /// Interaction logic for MedicalPoliciesDataGridPage.xaml
    /// </summary>
    public partial class MedicalPoliciesDataGridPage : Page
    {
        private MedicalPoliciesDataGridViewModel viewModel;
        private Frame frameContainer;

        public MedicalPoliciesDataGridPage(Frame frameContainer, StudentEntity student)
        {
            InitializeComponent();
            viewModel = new MedicalPoliciesDataGridViewModel(student);
            DataContext = viewModel;
            this.frameContainer = frameContainer;
        }

        public void AddMedicalPolicy()
        {
            frameContainer.Navigate(new MedicalPolicyHandler(viewModel.student));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            MedicalPolicyEntity medicalPolicy = GetSelectedMedicalPolicy();

            frameContainer.Navigate(new MedicalPolicyHandler(medicalPolicy, Scripts.HandlerOpenType.update));
        }

        private MedicalPolicyEntity GetSelectedMedicalPolicy()
        {
            return (MedicalPolicyEntity)MedicalPoliciesDataGrid.SelectedItem;
        }
    }
}
