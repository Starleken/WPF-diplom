using Diplom.Resources.Model;
using Diplom.Resources.Scripts;
using Diplom.Resources.ViewModel.Handlers.Documents;
using Microsoft.Win32;
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
    /// Interaction logic for InnHandler.xaml
    /// </summary>
    public partial class InnHandler : Page
    {
        private InnHandlerViewModel viewModel;

        public InnHandler(StudentEntity student)
        {
            InitializeComponent();

            viewModel = new InnHandlerViewModel(student);
            DataContext = viewModel;
        }

        public InnHandler(InnEntity inn, HandlerOpenType openType)
        {
            InitializeComponent();

            viewModel = new InnHandlerViewModel(inn);
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
            viewModel.AddInn();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateInn();
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Files|*.jpg;*.jpeg;*.png;";
            if (dlg.ShowDialog() == true)
            {
                Uri uri = new Uri(dlg.FileName, UriKind.Absolute);
                InnImage.Source = BitmapFrame.Create(uri);
                viewModel.Inn.imageURL = uri.AbsolutePath;
            }
        }
    }
}
