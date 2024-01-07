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
    /// Interaction logic for FluorographyHandler.xaml
    /// </summary>
    public partial class FluorographyHandler : Page
    {
        private FluorographyHandlerViewModel viewModel;

        public FluorographyHandler(StudentEntity student)
        {
            InitializeComponent();

            viewModel = new FluorographyHandlerViewModel(student);
            DataContext = viewModel;
        }

        public FluorographyHandler(FluorographyEntity fluorography, HandlerOpenType openType)
        {
            InitializeComponent();

            viewModel = new FluorographyHandlerViewModel(fluorography);
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
            viewModel.AddFluorography();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateFluorography();
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Files|*.jpg;*.jpeg;*.png;";
            if (dlg.ShowDialog() == true)
            {
                Uri uri = new Uri(dlg.FileName, UriKind.Absolute);
                FluorographyImage.Source = BitmapFrame.Create(uri);
                viewModel.Fluorography.imageURL = uri.AbsolutePath;
            }
        }
    }
}
