using Diplom.Resources.Model;
using Diplom.Resources.Scripts.Interfaces;
using Diplom.Resources.Scripts.Util;
using Diplom.Resources.View.Windows;
using Diplom.Resources.View.Windows.Documents;
using Diplom.Resources.ViewModel.Documents;
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

namespace Diplom.Resources.View.Pages.Documents
{
    /// <summary>
    /// Interaction logic for InnDataGridPage.xaml
    /// </summary>
    public partial class InnDataGridPage : Page, IUnigue, IDocumentPage
    {
        private InnDataGridViewModel viewModel;
        private Frame frameContainer;

        public InnDataGridPage(Frame frameContainer, StudentEntity student)
        {
            InitializeComponent();
            viewModel = new InnDataGridViewModel(student);

            DataContext = viewModel;

            this.frameContainer = frameContainer;
        }

        public void AddEntity()
        {
            frameContainer.Navigate(new InnHandler(viewModel.student));
        }

        public int GetDocumentCount()
        {
            return viewModel.InnEntities.Count;
        }

        private InnEntity GetSelectedInn()
        {
            return (InnEntity)InnDataGrid.SelectedItem;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            InnEntity inn = GetSelectedInn();

            if (inn != null)
            {
                frameContainer.Navigate(new InnHandler(inn, Scripts.HandlerOpenType.update));
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            WarningWindow warningWindow = new WarningWindow("Вы уверены что хотите удалить ИНН?");
            warningWindow.ShowDialog();

            if (warningWindow.result == true)
            {
                viewModel.DeleteInn(GetSelectedInn());
            }
        }

        private void InnDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            InnEntity inn = GetSelectedInn();

            if (inn != null)
            {
                frameContainer.Navigate(new InnHandler(inn, Scripts.HandlerOpenType.watch));
            }
        }
    }
}
