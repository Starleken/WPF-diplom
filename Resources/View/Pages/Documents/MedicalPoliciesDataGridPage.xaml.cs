﻿using Diplom.Resources.Model;
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
    /// Interaction logic for MedicalPoliciesDataGridPage.xaml
    /// </summary>
    public partial class MedicalPoliciesDataGridPage : Page, IUnigue, IDocumentPage
    {
        private MedicalPoliciesDataGridViewModel viewModel;
        private Frame frameContainer;

        public MedicalPoliciesDataGridPage(Frame frameContainer, StudentEntity student)
        {
            InitializeComponent();
            viewModel = new MedicalPoliciesDataGridViewModel(student);
            DataContext = viewModel;
            this.frameContainer = frameContainer;

            InitByRole();
        }

        private void InitByRole()
        {
            if (AuthController.CurrentUser.id != 3)
            {
                MedicalPoliciesDataGrid.Columns[1].Visibility = Visibility.Collapsed;
            }
        }

        public void AddEntity()
        {
            frameContainer.Navigate(new MedicalPolicyHandler(viewModel.student));
        }

        public int GetDocumentCount()
        {
            return viewModel.MedicalPolicies.Count;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            MedicalPolicyEntity medicalPolicy = GetSelectedMedicalPolicy();

            frameContainer.Navigate(new MedicalPolicyHandler(medicalPolicy, Scripts.HandlerOpenType.update));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            WarningWindow warningWindow = new WarningWindow("Вы уверены что хотите удалить мед.полис?");
            warningWindow.ShowDialog();

            if (warningWindow.result == true)
            {
                viewModel.DeleteMedicalPolicy(GetSelectedMedicalPolicy());
            }
        }

        private MedicalPolicyEntity GetSelectedMedicalPolicy()
        {
            return (MedicalPolicyEntity)MedicalPoliciesDataGrid.SelectedItem;
        }

        private void MedicalPoliciesDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MedicalPolicyEntity medicalPolicy = GetSelectedMedicalPolicy();

            frameContainer.Navigate(new MedicalPolicyHandler(medicalPolicy, Scripts.HandlerOpenType.watch));
        }
    }
}
