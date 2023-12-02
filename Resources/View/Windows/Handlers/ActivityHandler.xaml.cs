using Diplom.Resources.Model.Activity;
using Diplom.Resources.Scripts;
using Diplom.Resources.ViewModel.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Diplom.Resources.View.Windows.Handlers
{
    /// <summary>
    /// Interaction logic for ActivityHandler.xaml
    /// </summary>
    public partial class ActivityHandler : Window
    {
        private ActivityHandlerViewModel viewModel;

        public ActivityHandler()
        {
            InitializeComponent();

            viewModel = new ActivityHandlerViewModel();
            this.DataContext = viewModel;
        }

        public ActivityHandler(Activity activity, HandlerOpenType openType)
        {
            InitializeComponent();

            viewModel = new ActivityHandlerViewModel(activity, openType);
            this.DataContext = viewModel;

            if (openType == HandlerOpenType.watch)
            {
                InitWatchType();
            }
            else
            {
                InitUpdateType();
            }
        }

        private void InitWatchType()
        {
            AddButton.Visibility = Visibility.Collapsed;
        }

        private void InitUpdateType()
        {
            EditButton.Visibility = Visibility.Visible;
            AddButton.Visibility = Visibility.Collapsed;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddActivity();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateActivity();
        }
    }
}
