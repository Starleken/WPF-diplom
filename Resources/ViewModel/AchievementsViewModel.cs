using Diplom.Resources.Model;
using Diplom.Resources.Model.Activity;
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
        public StudentEntity student { get; set; }

        private ActivityRepository activityRepository = new ActivityRepository();

        private List<ActivityEntity> allActivities;

        private ObservableCollection<ActivityEntity> activities;

        public ObservableCollection<ActivityEntity> Activities
        {
            get { return activities; }
            set
            {
                activities = value;
                OnPropertyChanged(nameof(activities));
            }
        }

        private ObservableCollection<ActivityLevelEntity> activityTypes;

        public ObservableCollection<ActivityLevelEntity> ActivityTypes
        {
            get { return ActivityTypes; }
            set { activityTypes = value; }
        }

        public AchievementsViewModel(StudentEntity student)
        {
            this.student = student;

            PullAchievmentsByStudentId(student);

            ActivityTypes = new ObservableCollection<ActivityLevelEntity>(new ActivityLevelRepository().GetAll());
        }

        public void PullAchievmentsByStudentId(StudentEntity student)
        {
            allActivities = activityRepository.GetActivitiesByStudentId(student.id).ToList();
            Activities = new ObservableCollection<ActivityEntity>(allActivities);
        }

        public void DeleteActivity(ActivityEntity activity)
        {
            new ActivityRepository().DeleteById(activity.id);

            Activities.Remove(activity);
            allActivities.Remove(activity);
        }

        public void SearchActivitiesByName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                Activities = new ObservableCollection<ActivityEntity>(allActivities);
            }

            Activities = new ObservableCollection<ActivityEntity>(allActivities.Where(x => x.name.ToLower().Contains(name.ToLower())));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
