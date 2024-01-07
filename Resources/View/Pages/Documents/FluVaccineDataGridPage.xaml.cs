using Diplom.Resources.Model;
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

        public FluVaccineDataGridPage(StudentEntity student)
        {
            InitializeComponent();

            viewModel = new FluVaccineDataGridViewModel(student);
            DataContext = viewModel;
        }
    }
}
