using Diplom.Resources.Model;
using Diplom.Resources.Model.Activity;
using Diplom.Resources.Scripts;
using Diplom.Resources.Scripts.HttpRequests.Repository;
using Diplom.Resources.ViewModel.Handlers;
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
using static System.Net.Mime.MediaTypeNames;

namespace Diplom.Resources.View.Windows.Handlers
{
    /// <summary>
    /// Interaction logic for ActivityHandler.xaml
    /// </summary>
    public partial class ActivityHandler : Page
    {
        ActivityHandlerViewModel viewModel;

        public ActivityHandler(StudentEntity student)
        {
            InitializeComponent();

            viewModel = new ActivityHandlerViewModel(student);
            DataContext = viewModel;
        }

        public ActivityHandler(StudentEntity student, ActivityEntity activity, HandlerOpenType openType)
        {
            InitializeComponent();

            viewModel = new ActivityHandlerViewModel(student, activity, openType);
            DataContext = viewModel;

            if (openType == HandlerOpenType.update)
            {
                InitUpdateView();
            }
            else InitWatchView();
        }

        private void InitUpdateView()
        {
            AddButton.Visibility = Visibility.Collapsed;
            EditButton.Visibility = Visibility.Visible;
        }

        private void InitWatchView()
        {
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

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Files|*.jpg;*.jpeg;*.png;";
            if (dlg.ShowDialog() == true)
            {
                Uri uri = new Uri(dlg.FileName, UriKind.Absolute);
                ActivityImage.Source = BitmapFrame.Create(uri);
                viewModel.Activity.imageURL = uri.AbsolutePath;
            }
        }
    }
}
