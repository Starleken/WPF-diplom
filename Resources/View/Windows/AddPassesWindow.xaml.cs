﻿using Diplom.Resources.Model;
using Diplom.Resources.Scripts.HttpRequests.Post;
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

namespace Diplom.Resources.View.Windows
{
    /// <summary>
    /// Interaction logic for AddPassesWindow.xaml
    /// </summary>
    public partial class AddPassesWindow : Window
    {
        //private Pass pass;
        public AddPassesWindow(/*Pass pass*/)
        {
            InitializeComponent();

            //this.pass = pass;
            //DataContext = this.pass;
        }

        private void PassImage_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddPass_Click(object sender, RoutedEventArgs e)
        {
            //PassPoster passPoster = new PassPoster();
            //passPoster.PostUser(pass);
        }
    }
}
