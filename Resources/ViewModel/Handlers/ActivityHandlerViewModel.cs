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

        private ActivityEntity activity;

        public ActivityEntity Activity
        {
            get { return activity; }
            set 
            { 
                activity = value;
                OnPropertyChanged(nameof(Activity));
            }
        }

        private ObservableCollection<ActivityLevelEntity> activityLevels;

        public ObservableCollection<ActivityLevelEntity> ActivityLevels
        {
            get { return activityLevels; }
            set 
            {
                activityLevels = value; 
                OnPropertyChanged(nameof(ActivityLevels));
            }
        }

        private ObservableCollection<ActivityTypeEntity> activityTypes;

        public ObservableCollection<ActivityTypeEntity> ActivityTypes
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

            Activity = new ActivityEntity();

            ActivityLevels = new ObservableCollection<ActivityLevelEntity>(new ActivityLevelRepository().GetAll());
            ActivityTypes = new ObservableCollection<ActivityTypeEntity>(new ActivityTypeRepository().GetAll());
        }

        public ActivityHandlerViewModel(StudentEntity student, ActivityEntity activity, HandlerOpenType openType)
        {
            this.student = student;

            Activity = activity;

            ActivityLevels = new ObservableCollection<ActivityLevelEntity>(new ActivityLevelRepository().GetAll());
            ActivityTypes = new ObservableCollection<ActivityTypeEntity>(new ActivityTypeRepository().GetAll());
        }

        public void AddActivity()
        {
            Activity.student = student;
            new ActivityRepository().PostActivity(new Requests.Activity.ActivityCreateRequest(Activity), Activity.imageURL);
        }

        public void UpdateActivity()
        {
            new ActivityRepository().PutActivity(new Requests.Activity.ActivityUpdateRequest(Activity), Activity.imageURL);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
