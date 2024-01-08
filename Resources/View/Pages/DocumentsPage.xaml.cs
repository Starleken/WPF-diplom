using Diplom.Resources.Model;
using Diplom.Resources.View.Pages.Documents;
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
        public delegate void AddButtonClick();
        public event AddButtonClick OnAddButtonClick;

        private DocumentsViewModel viewModel;

        private Frame frameContainer;

        public DocumentsPage(Frame frameContainer, UserEntity user, StudentEntity student)
        {
            InitializeComponent();

            viewModel = new DocumentsViewModel(student);
            DataContext = viewModel;
            this.frameContainer = frameContainer;

            SnilsButton_Click(null, null);

            InitByRole(user.role);
        }

        private void InitByRole(RoleEntity role)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            OnAddButtonClick?.Invoke();
        }

        private void SnilsButton_Click(object sender, RoutedEventArgs e)
        {
            DocumentNameTextBlock.Text = "Снилс";
            UnsubListeners();
            SnilsDataGridPage page = new SnilsDataGridPage(frameContainer, viewModel.student);
            OnAddButtonClick += page.AddSnils;
            PageDataGridContainer.Navigate(page);
        }

        private void FluorographyButton_Click(object sender, RoutedEventArgs e)
        {
            DocumentNameTextBlock.Text = "Флюроография";
            UnsubListeners();
            FluorographyDataGridPage page = new FluorographyDataGridPage(frameContainer, viewModel.student);
            OnAddButtonClick += page.AddFluorography;
            PageDataGridContainer.Navigate(page);
        }

        private void MedicalPoliciesButton_Click(object sender, RoutedEventArgs e)
        {
            DocumentNameTextBlock.Text = "Медицинский полюс";
            UnsubListeners();
            MedicalPoliciesDataGridPage page = new MedicalPoliciesDataGridPage(frameContainer, viewModel.student);
            OnAddButtonClick += page.AddMedicalPolicy;
            PageDataGridContainer.Navigate(page);
        }

        private void FluVaccinesButton_Click(object sender, RoutedEventArgs e)
        {
            DocumentNameTextBlock.Text = "Прививка от гриппа";
            UnsubListeners();
            FluVaccineDataGridPage page = new FluVaccineDataGridPage(frameContainer, viewModel.student);
            OnAddButtonClick += page.AddFluVaccine;
            PageDataGridContainer.Navigate(page);
        }

        private void InnButton_Click(object sender, RoutedEventArgs e)
        {
            DocumentNameTextBlock.Text = "ИНН";
            UnsubListeners();
            InnDataGridPage page = new InnDataGridPage(frameContainer, viewModel.student);
            OnAddButtonClick += page.AddInn;
            PageDataGridContainer.Navigate(page);
        }

        private void PassportsButton_Click(object sender, RoutedEventArgs e)
        {
            DocumentNameTextBlock.Text = "Паспорт";
            UnsubListeners();
            PassportDataGridPage page = new PassportDataGridPage(frameContainer, viewModel.student);
            OnAddButtonClick += page.AddPassport;
            PageDataGridContainer.Navigate(page);
        }

        private void UnsubListeners()
        {
            OnAddButtonClick = null;
        }
    }
}
