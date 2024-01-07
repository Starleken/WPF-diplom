using Diplom.Resources.Model;
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
        private StudentEntity student;

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


        public ActivityHandlerViewModel(StudentEntity student)
        {
            this.student = student;

            Activity = new Activity();

            ActivityLevels = new ObservableCollection<ActivityLevel>(new ActivityLevelRepository().GetAll());
            ActivityTypes = new ObservableCollection<ActivityType>(new ActivityTypeRepository().GetAll());
        }

        public ActivityHandlerViewModel(StudentEntity student, Activity activity, HandlerOpenType openType)
        {
            this.student = student;

            Activity = activity;

            ActivityLevels = new ObservableCollection<ActivityLevel>(new ActivityLevelRepository().GetAll());
            ActivityTypes = new ObservableCollection<ActivityType>(new ActivityTypeRepository().GetAll());
        }

        public void AddActivity()
        {
            Activity.student = student;
            new ActivityRepository().PostActivity(new Requests.ActivityCreateRequest(Activity), Activity.imageURL);
        }

        public void UpdateActivity()
        {
            new ActivityRepository().PutActivity(new Requests.ActivityUpdateRequest(Activity), Activity.imageURL);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
