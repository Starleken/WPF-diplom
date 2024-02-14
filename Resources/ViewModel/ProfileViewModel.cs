using Diplom.Resources.Model;
using Diplom.Resources.Scripts;
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
    class ProfileViewModel : INotifyPropertyChanged
    {
        private StudentEntity student;

        public StudentEntity Student
        {
            get { return student; }
            set 
            {
                student = value;
                OnPropertyChanged(nameof(Student));
            }
        }

        private ObservableCollection<ProfileNotification> notifications;

        public ObservableCollection<ProfileNotification> Notifications
        {
            get { return notifications; }
            set
            {
                notifications = value;
                OnPropertyChanged(nameof(Notifications));
            }
        }

        public ProfileViewModel(UserEntity user)
        {
            StudentRepository repository = new StudentRepository();
            Student = repository.GetStudentsByUser(user.id);

            TestInitNotifications();
        }

        private void TestInitNotifications()
        {
            NotificationRepository notificationRepository = new NotificationRepository();
            string[] notifications = notificationRepository.GetAllByStudent(Student.id);

            Notifications = new ObservableCollection<ProfileNotification>();

            for (int i = 0; i < notifications.Length; i++)
            {
                Notifications.Add(new ProfileNotification(i + 1, notifications[i]));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
