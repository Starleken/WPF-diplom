using Diplom.Resources.Model;
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
    /// Interaction logic for ProfilPage.xaml
    /// </summary>
    public partial class ProfilPage : Page
    {
        private ProfileViewModel viewModel;

        public ProfilPage(UserEntity user)
        {
            InitializeComponent();

            viewModel = new ProfileViewModel(user);

            DataContext = viewModel;
        }
    }
}
