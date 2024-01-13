using Diplom.Resources.Model;
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
    class StudentHandlerViewModel : INotifyPropertyChanged
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

        private ObservableCollection<EducationFormEntity> educationForms;

        public ObservableCollection<EducationFormEntity> EducationForms
        {
            get { return educationForms; }
            set 
            {
                educationForms = value;
                OnPropertyChanged(nameof(EducationForms));
            }
        }

        private ObservableCollection<GroupEntity> groups;

        public ObservableCollection<GroupEntity> Groups
        {
            get { return groups; }
            set
            {
                groups = value;
                OnPropertyChanged(nameof(Groups));
            }
        }

        public StudentHandlerViewModel(List<EducationFormEntity> educationForms, List<GroupEntity> groups)
        {
            EducationForms = new ObservableCollection<EducationFormEntity>(educationForms);
            Groups = new ObservableCollection<GroupEntity>(groups);

            Student = new StudentEntity();
            Student.user.role.id = 3;
        }

        public StudentHandlerViewModel(StudentEntity student, List<EducationFormEntity> educationForms, List<GroupEntity> groups)
        {
            EducationForms = new ObservableCollection<EducationFormEntity>(educationForms);
            Groups = new ObservableCollection<GroupEntity>(groups);

            this.Student = student;
        }

        public void AddStudent()
        {
            new StudentRepository().Post(new Requests.Student.StudentCreateRequest(Student));
        }

        public void PutStudent()
        {
            new StudentRepository().Put(new Requests.Student.StudentUpdateRequest(Student));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
