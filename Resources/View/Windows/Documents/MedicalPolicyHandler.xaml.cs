using Diplom.Resources.Model;
using Diplom.Resources.Scripts;
using Diplom.Resources.ViewModel.Handlers.Documents;
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

namespace Diplom.Resources.View.Windows.Documents
{
    /// <summary>
    /// Interaction logic for MedicalPolicyHandler.xaml
    /// </summary>
    public partial class MedicalPolicyHandler : Page
    {
        private MedicalPolicyHandlerViewModel viewModel;

        public MedicalPolicyHandler(StudentEntity student)
        {
            InitializeComponent();

            viewModel = new MedicalPolicyHandlerViewModel(student);
            DataContext = viewModel;
        }

        public MedicalPolicyHandler(MedicalPolicyEntity medicalPolicy, HandlerOpenType openType)
        {
            InitializeComponent();

            viewModel = new MedicalPolicyHandlerViewModel(medicalPolicy);
            DataContext = viewModel;

            InitByOpenType(openType);
        }

        private void InitByOpenType(HandlerOpenType openType)
        {
            if (openType == HandlerOpenType.update)
            {
                EditButton.Visibility = Visibility.Visible;
                AddButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                AddButton.Visibility = Visibility.Collapsed;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddMedicalPolicy();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateMedicalPolicy();
        }
    }
}
