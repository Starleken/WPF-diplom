using Diplom.Resources.Model;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Diplom.Resources.View.Windows.Handlers
{
    /// <summary>
    /// Interaction logic for StudentHandler.xaml
    /// </summary>
    public partial class StudentHandler : Window
    {
        private StudentHandlerViewModel viewModel;

        public StudentHandler()
        {
            InitializeComponent();
            viewModel = new StudentHandlerViewModel();
            this.DataContext = viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddStudent();
        }
    }
}
