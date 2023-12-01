using Diplom.Resources.Model.Activity;
using Diplom.Resources.Scripts;
using Diplom.Resources.Scripts.HttpRequests.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<ActivityLevel> activityLevels;

        public ObservableCollection<ActivityLevel> ActivityLevels
        {
            get { return activityLevels; }
            set 
            {
                activityLevels = value; 
                OnPropertyChanged(nameof(ActivityLevels));
            }
        }

        private ObservableCollection<ActivityType> activityTypes;

        public ObservableCollection<ActivityType> ActivityTypes
        {
            get { return activityTypes; }
            set 
            {
                activityTypes = value;
                OnPropertyChanged(nameof(ActivityTypes));
            }
        }


        public ActivityHandlerViewModel()
        {
            Activity = new Activity();

            ActivityLevels = new ObservableCollection<ActivityLevel>(new ActivityLevelRepository().GetAll());
            ActivityTypes = new ObservableCollection<ActivityType>(new ActivityTypeRepository().GetAll());
        }

        public ActivityHandlerViewModel(Activity activity, HandlerOpenType openType)
        {
            Activity = activity;
        }

        public void AddActivity()
        {
            new ActivityRepository().PostActivity(Activity);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
