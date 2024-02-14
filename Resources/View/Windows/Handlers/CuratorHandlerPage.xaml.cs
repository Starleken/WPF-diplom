using Diplom.Resources.Model;
using Diplom.Resources.Scripts;
using Diplom.Resources.ViewModel.Handlers;
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

namespace Diplom.Resources.View.Windows.Handlers
{
    /// <summary>
    /// Interaction logic for CuratorHandlerPage.xaml
    /// </summary>
    public partial class CuratorHandlerPage : Page
    {
        private CuratorHandlerViewModel viewModel;

        public CuratorHandlerPage()
        {
            InitializeComponent();

            viewModel = new CuratorHandlerViewModel();
            DataContext = viewModel;
        }

        public CuratorHandlerPage(CuratorEntity curator, HandlerOpenType openType)
        {
            InitializeComponent();

            viewModel = new CuratorHandlerViewModel(curator);
            DataContext = viewModel;

            InitByOpenType(openType);
        }

        private void InitByOpenType(HandlerOpenType openType)
        {
            if (openType == HandlerOpenType.update)
            {
                ChangeButton.Visibility = Visibility.Visible;
                AddButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                AddButton.Visibility = Visibility.Collapsed;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddCurator();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateCurator();
        }
    }
}
