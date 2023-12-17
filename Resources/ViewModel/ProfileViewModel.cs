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
        private Student student;

        public Student Student
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

        public ProfileViewModel(User user)
        {
            StudentRepository repository = new StudentRepository();
            Student = repository.GetStudentsByUser(user.id);

            TestInitNotifications();
        }

        private void TestInitNotifications()
        {
            Notifications = new ObservableCollection<ProfileNotification>();
            Notifications.Add(new ProfileNotification(1, "Обновить паспорт"));
            Notifications.Add(new ProfileNotification(2, "Сделать флюроографию"));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
