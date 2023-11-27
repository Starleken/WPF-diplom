using Diplom.Resources.Model;
using Diplom.Resources.Scripts.HttpRequests.Post;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.ViewModel
{
    class AddStudentsViewModel : INotifyPropertyChanged
    {
        private User student;

        public User Student
        {
            get { return student; }
            set 
            {
                student = value;
                OnPropertyChanged(nameof(Student));
            }
        }

        //private ObservableCollection<Group> groups;

        //public ObservableCollection<Group> Groups
        //{
        //    get { return groups; }
        //    set 
        //    {
        //        groups = value;
        //        OnPropertyChanged(nameof(Groups));
        //    }
        //}

        public AddStudentsViewModel()
        {
            //Student = new User();
            //Student.RoleId = 3;

            //GroupGetter groupGetter = new GroupGetter();
            //Groups = new ObservableCollection<Group>(groupGetter.GetAll());
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddStudent()
        {
            //Student.GroupId = Student.Group.id;
            //UserPoster userPoster = new UserPoster();
            //userPoster.PostUser(Student);
        }
    }
}
