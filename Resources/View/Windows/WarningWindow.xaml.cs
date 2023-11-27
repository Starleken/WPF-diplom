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
    /// Interaction logic for WarningWindow.xaml
    /// </summary>
    public partial class WarningWindow : Window
    {
        public bool result;

        public WarningWindow(string warningMessage)
        {
            InitializeComponent();

            WarningText.Text = warningMessage;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            result = false;
            this.Close();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            result = true;
            this.Close();
        }
    }
}
