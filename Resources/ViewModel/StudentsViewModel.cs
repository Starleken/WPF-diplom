using Diplom.Resources.Model;
using Diplom.Resources.Scripts.HttpRequests.Get;
using Diplom.Resources.Scripts.HttpRequests.Repository;
using Diplom.Resources.View.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.ViewModel
{
    internal class StudentsViewModel : INotifyPropertyChanged
    {
        private StudentRepository studentRepository = new StudentRepository();
        private CuratorRepository curatorRepository = new CuratorRepository();

        private List<StudentEntity> allStudents;

        private ObservableCollection<StudentEntity> students;

        public ObservableCollection<StudentEntity> Students
        {
            get { return students; }
            set 
            {
                students = value; 
                OnPropertyChanged(nameof(Students));
            }
        }

        public StudentsViewModel(UserEntity user)
        {
            PullStudentsByRole(user);
        }

        private void PullStudentsByRole(UserEntity user)
        {
            if (user.role.id == 1)
            {
                allStudents = studentRepository.GetAll().ToList();
                Students = new ObservableCollection<StudentEntity>(allStudents);
            }
            else
            {
                CuratorEntity curator = curatorRepository.GetCuratorByUser(user.id);
                allStudents = studentRepository.GetStudentsByGroup(curator.group.id).ToList();
                Students = new ObservableCollection<StudentEntity>(allStudents);
            }
        }

        public void SearchStudentsByFullName(string fullName)
        {
            if (fullName == null)
            {
                Students = new ObservableCollection<StudentEntity>(allStudents);
            }

            Students = new ObservableCollection<StudentEntity>(allStudents.Where(x => x.user.person.FullName1.ToLower().Contains(fullName.ToLower())));
        }

        public void DeleteStudent(StudentEntity student)
        {
            Students.Remove(student);

            new StudentRepository().DeleteById(student.id);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
