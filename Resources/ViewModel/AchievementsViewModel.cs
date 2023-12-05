using Diplom.Resources.Model;
using Diplom.Resources.Model.Activity;
using Diplom.Resources.Scripts.HttpRequests.Get;
using Diplom.Resources.Scripts.HttpRequests.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.ViewModel
{
    internal class AchievementsViewModel : INotifyPropertyChanged
    {
        private ActivityRepository activityRepository = new ActivityRepository();

        private List<Activity> allActivities;

        private ObservableCollection<Activity> activities;

        public ObservableCollection<Activity> Activities
        {
            get { return activities; }
            set
            {
                activities = value;
                OnPropertyChanged(nameof(activities));
            }
        }

        private ObservableCollection<ActivityLevel> activityTypes;

        public ObservableCollection<ActivityLevel> ActivityTypes
        {
            get { return ActivityTypes; }
            set { activityTypes = value; }
        }

        public AchievementsViewModel(Student student)
        {
            PullAchievmentsByUserId(student);

            ActivityTypes = new ObservableCollection<ActivityLevel>(new ActivityTypeGetter().GetAll());
        }

        public void PullAchievmentsByUserId(Student student)
        {
            allActivities = activityRepository.GetActivitiesByUserId(student.user.id).ToList();
            Activities = new ObservableCollection<Activity>(allActivities);
        }

        public void DeleteActivity(Activity activity)
        {
            Activities.Remove(activity);
            allActivities.Remove(activity);
        }

        public void SearchActivitiesByName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                Activities = new ObservableCollection<Activity>(allActivities);
            }

            Activities = new ObservableCollection<Activity>(allActivities.Where(x => x.name.ToLower().Contains(name.ToLower())));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
