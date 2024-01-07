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
    /// Interaction logic for SnilsHandler.xaml
    /// </summary>
    public partial class SnilsHandler : Page
    {
        private SnilsHandlerViewModel viewModel;

        public SnilsHandler(StudentEntity student)
        {
            InitializeComponent();

            viewModel = new SnilsHandlerViewModel(student);
            DataContext = viewModel;
        }

        public SnilsHandler(SnilsEntity snils, HandlerOpenType openType)
        {
            InitializeComponent();

            viewModel = new SnilsHandlerViewModel(snils);
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
            viewModel.AddSnils();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateSnils();
        }
    }
}
