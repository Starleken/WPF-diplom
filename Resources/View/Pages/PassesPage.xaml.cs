using Diplom.Resources.Model;
using Diplom.Resources.View.Windows;
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
    /// Interaction logic for PassesPage.xaml
    /// </summary>
    public partial class PassesPage : Page
    {
        PassesViewModel viewModel;

        public PassesPage()
        {
            InitializeComponent();

            viewModel = new PassesViewModel();
            DataContext = viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CustomizeButton_Click(object sender, RoutedEventArgs e)
        {
            //Pass pass = (Pass)PassesDataGrid.SelectedItem;

            //AddPassesWindow addPassesWindow = new AddPassesWindow(pass);
            //addPassesWindow.ShowDialog();
        }
    }
}
