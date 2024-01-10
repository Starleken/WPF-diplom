using Diplom.Resources.Model;
using Diplom.Resources.Scripts.Interfaces;
using Diplom.Resources.Scripts.Util;
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
            if (role.name != "Студент")
            {
                AddButton.Visibility = Visibility.Collapsed;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            OnAddButtonClick?.Invoke();
        }

        private void SnilsButton_Click(object sender, RoutedEventArgs e)
        {

            SnilsDataGridPage page = new SnilsDataGridPage(frameContainer, viewModel.student);
            ChangePage("Снилс", page);
        }

        private void FluorographyButton_Click(object sender, RoutedEventArgs e)
        {
            FluorographyDataGridPage page = new FluorographyDataGridPage(frameContainer, viewModel.student);
            ChangePage("Флюорография", page);
        }

        private void MedicalPoliciesButton_Click(object sender, RoutedEventArgs e)
        {
            MedicalPoliciesDataGridPage page = new MedicalPoliciesDataGridPage(frameContainer, viewModel.student);
            ChangePage("Медицинский полюс", page);
        }

        private void FluVaccinesButton_Click(object sender, RoutedEventArgs e)
        {
            FluVaccineDataGridPage page = new FluVaccineDataGridPage(frameContainer, viewModel.student);
            ChangePage("Прививка от гриппа", page);
        }

        private void InnButton_Click(object sender, RoutedEventArgs e)
        {
            InnDataGridPage page = new InnDataGridPage(frameContainer, viewModel.student);
            ChangePage("ИНН", page);
        }

        private void PassportsButton_Click(object sender, RoutedEventArgs e)
        {
            PassportDataGridPage page = new PassportDataGridPage(frameContainer, viewModel.student);
            ChangePage("Паспорт", page);
        }

        private void ChangePage(string pageName, IDocumentPage page)
        {
            DocumentNameTextBlock.Text = pageName;
            UnsubListeners();
            CheckUnigueDocumentCount(page);
            OnAddButtonClick += page.AddEntity;
            PageDataGridContainer.Navigate((Page)page);
        }

        private void CheckUnigueDocumentCount(IDocumentPage page)
        {
            if (AuthController.CurrentUser.role.name != "Студент")
            {
                return;
            }

            AddButton.Visibility = Visibility.Visible;

            int documentCount = 0;
            if (page is IUnigue unigue)
            {
                documentCount = unigue.GetDocumentCount();
            }

            if (documentCount > 0)
            {
                AddButton.Visibility = Visibility.Collapsed;
            }
        }

        private void UnsubListeners()
        {
            OnAddButtonClick = null;
        }
    }
}
