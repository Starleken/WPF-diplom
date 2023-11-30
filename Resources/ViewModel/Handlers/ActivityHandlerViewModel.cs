using Diplom.Resources.Model.Activity;
using Diplom.Resources.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.ViewModel.Handlers
{
    internal class ActivityHandlerViewModel : INotifyPropertyChanged
    {
        private Activity activity;

        public Activity Activity
        {
            get { return activity; }
            set 
            { 
                activity = value;
                OnPropertyChanged(nameof(Activity));
            }
        }

        public ActivityHandlerViewModel()
        {
            Activity = new Activity();
        }

        public ActivityHandlerViewModel(Activity activity, HandlerOpenType openType)
        {
            Activity = activity;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
