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
    /// Interaction logic for SnilsDataGridPage.xaml
    /// </summary>
    public partial class SnilsDataGridPage : Page
    {
        private SnilsDataGridViewModel viewModel;
        private Frame frameContainer;

        public SnilsDataGridPage(Frame frameContainer, StudentEntity student)
        {
            InitializeComponent();

            this.frameContainer = frameContainer;
            viewModel = new SnilsDataGridViewModel(student);
            DataContext = viewModel;
        }

        public void AddSnils()
        {
            frameContainer.Navigate(new SnilsHandler(viewModel.student));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            frameContainer.Navigate(new SnilsHandler(GetSelectedSnils(), Scripts.HandlerOpenType.update));
        }

        private SnilsEntity GetSelectedSnils()
        {
            return (SnilsEntity)SnilsDataGrid.SelectedItem;
        }
    }
}
