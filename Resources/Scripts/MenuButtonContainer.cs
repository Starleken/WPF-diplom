using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Diplom.Resources.Scripts
{
    class MenuButtonContainer
    {
        private Button buttonText;
        private Border activityIndicator;

        public MenuButtonContainer(Button buttonText, Border activityIndicator)
        {
            this.buttonText = buttonText;
            this.activityIndicator = activityIndicator;
        }

        public void ActivateButton()
        {
            buttonText.Foreground = new SolidColorBrush(Colors.White);
            activityIndicator.Visibility = System.Windows.Visibility.Visible;
        }

        public void DeactivateButton()
        {
            Color color = (Color)ColorConverter.ConvertFromString("#e2e5e9");
            buttonText.Foreground = new SolidColorBrush(color);
            activityIndicator.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
