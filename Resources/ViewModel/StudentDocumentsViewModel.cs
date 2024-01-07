using Diplom.Resources.Model;
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
    internal class StudentDocumentsViewModel : INotifyPropertyChanged
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

        public StudentDocumentsViewModel(UserEntity user)
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

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
