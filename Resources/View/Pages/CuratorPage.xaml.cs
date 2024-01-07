using Diplom.Resources.Model;
using Diplom.Resources.View.Windows;
using Diplom.Resources.View.Windows.Handlers;
using Diplom.Resources.ViewModel;
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

namespace Diplom.Resources.View.Pages
{
    /// <summary>
    /// Interaction logic for CuratorPage.xaml
    /// </summary>
    public partial class CuratorPage : Page
    {
        private CuratorsViewModel viewModel;
        private Frame frameContainer;

        public CuratorPage(Frame frameContainer)
        {
            InitializeComponent();

            viewModel = new CuratorsViewModel();
            DataContext = viewModel;
            this.frameContainer = frameContainer;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            CuratorHandlerPage handler = new CuratorHandlerPage();
            frameContainer.Navigate(handler);
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.FilterByName(SearchTextBox.Text);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            CuratorHandler handler = new CuratorHandler(GetSelectedCurator());
            handler.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private CuratorEntity GetSelectedCurator()
        {
            return (CuratorEntity)CuratorsDataGrid.SelectedItem;
        }
    }
}
