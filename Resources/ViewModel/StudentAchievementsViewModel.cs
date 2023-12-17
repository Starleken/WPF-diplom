using Diplom.Resources.Model;
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
    internal class StudentAchievementsViewModel : INotifyPropertyChanged
    {
        private StudentRepository studentRepository = new StudentRepository();
        private CuratorRepository curatorRepository = new CuratorRepository();

        private List<Student> allStudents;

        private ObservableCollection<Student> students;

        public ObservableCollection<Student> Students
        {
            get { return students; }
            set
            {
                students = value;
                OnPropertyChanged(nameof(Students));
            }
        }

        public StudentAchievementsViewModel(User user)
        {
            PullStudentsByRole(user);   
        }

        private void PullStudentsByRole(User user)
        {
            if (user.role.id == 1)
            {
                allStudents = studentRepository.GetAll().ToList();
                Students = new ObservableCollection<Student>(allStudents);
            }
            else
            {
                Curator curator = curatorRepository.GetCuratorByUser(user.id);
                allStudents = studentRepository.GetStudentsByGroup(curator.group.id).ToList();
                Students = new ObservableCollection<Student>(allStudents);
            }
        }

        public void SearchStudentsByFullName(string fullName)
        {
            if (fullName == null)
            {
                Students = new ObservableCollection<Student>(allStudents);
            }

            Students = new ObservableCollection<Student>(allStudents.Where(x => x.user.person.FullName1.ToLower().Contains(fullName.ToLower())));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
