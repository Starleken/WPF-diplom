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
    /// Interaction logic for DocumetsPage.xaml
    /// </summary>
    public partial class DocumentsPage : Page
    {
        private DocumentsViewModel viewModel;

        public DocumentsPage(Student student)
        {
            InitializeComponent();

            viewModel = new DocumentsViewModel(student);
            DataContext = viewModel;

            SnilsButton_Click(null, null);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SnilsButton_Click(object sender, RoutedEventArgs e)
        {
            DisableAllDataGrid();
            SnilsDataGrid.Visibility = Visibility.Visible;

            DocumentNameTextBlock.Text = "Снилс";
            Color color = (Color)ColorConverter.ConvertFromString("#07bf96");
            viewModel.GetSnilsByStudent();
        }

        private void FluorographyButton_Click(object sender, RoutedEventArgs e)
        {
            DisableAllDataGrid();
            FluorographiesDataGrid.Visibility = Visibility.Visible;

            DocumentNameTextBlock.Text = "Флюроография";
            Color color = (Color)ColorConverter.ConvertFromString("#07bf96");
            viewModel.GetFluographiesByStudent();
        }

        private void MedicalPoliciesButton_Click(object sender, RoutedEventArgs e)
        {
            DisableAllDataGrid();
            MedicalPoliciesDataGrid.Visibility = Visibility.Visible;

            DocumentNameTextBlock.Text = "Медицинский полюс";
            Color color = (Color)ColorConverter.ConvertFromString("#07bf96");
            viewModel.GetMedicalPoliciesByStudent();
        }

        private void FluVaccinesButton_Click(object sender, RoutedEventArgs e)
        {
            DisableAllDataGrid();
            FluVaccinesDataGrid.Visibility = Visibility.Visible;

            DocumentNameTextBlock.Text = "Прививка от гриппа";
            Color color = (Color)ColorConverter.ConvertFromString("#07bf96");
            viewModel.GetFluVaccinesByStudent();
        }

        private void SnilsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void DisableAllDataGrid()
        {
            SnilsDataGrid.Visibility = Visibility.Collapsed;
            FluorographiesDataGrid.Visibility = Visibility.Collapsed;
            MedicalPoliciesDataGrid.Visibility = Visibility.Collapsed;
            FluVaccinesDataGrid.Visibility = Visibility.Collapsed;
        }
    }
}
