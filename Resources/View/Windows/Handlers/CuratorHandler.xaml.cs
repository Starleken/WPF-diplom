﻿using Diplom.Resources.Model;
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

namespace Diplom.Resources.View.Windows.Handlers
{
    /// <summary>
    /// Interaction logic for CuratorHandler.xaml
    /// </summary>
    public partial class CuratorHandler : Window
    {
        private CuratorHandlerViewModel viewModel;

        public CuratorHandler()
        {
            InitializeComponent();

            viewModel = new CuratorHandlerViewModel();
            DataContext = viewModel;
        }

        public CuratorHandler(CuratorEntity curator)
        {
            InitializeComponent();

            viewModel = new CuratorHandlerViewModel(curator);
            DataContext = viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddCurator();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateCurator();
        }
    }
}
