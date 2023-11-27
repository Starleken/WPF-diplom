﻿using Diplom.Resources.Model.Activity;
using Diplom.Resources.Scripts.HttpRequests.Get;
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

        private ObservableCollection<ActivityType> activityTypes;

        public ObservableCollection<ActivityType> ActivityTypes
        {
            get { return ActivityTypes; }
            set { activityTypes = value; }
        }


        public AchievementsViewModel()
        {
            ActivityGetter activityGetter = new ActivityGetter();
            allActivities = activityGetter.GetAll().ToList();
            Activities = new ObservableCollection<Activity>(allActivities);

            ActivityTypes = new ObservableCollection<ActivityType>(new ActivityTypeGetter().GetAll());
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
