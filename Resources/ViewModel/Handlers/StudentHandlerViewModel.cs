using Diplom.Resources.Model;
using Diplom.Resources.Scripts.HttpRequests.Post;
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

        private ObservableCollection<EducationForm> educationForms;

        public ObservableCollection<EducationForm> EducationForms
        {
            get { return educationForms; }
            set 
            {
                educationForms = value;
                OnPropertyChanged(nameof(EducationForms));
            }
        }

        private ObservableCollection<Group> groups;

        public ObservableCollection<Group> Groups
        {
            get { return groups; }
            set
            {
                groups = value;
                OnPropertyChanged(nameof(Groups));
            }
        }

        public StudentHandlerViewModel(List<EducationForm> educationForms, List<Group> groups)
        {
            EducationForms = new ObservableCollection<EducationForm>(educationForms);
            Groups = new ObservableCollection<Group>(groups);

            Student = new Student();
            Student.user.role.id = 3;
        }

        public StudentHandlerViewModel(Student student, List<EducationForm> educationForms, List<Group> groups)
        {
            EducationForms = new ObservableCollection<EducationForm>(educationForms);
            Groups = new ObservableCollection<Group>(groups);

            this.Student = student;
        }

        public void AddStudent()
        {
            StudentPoster studentPoster = new StudentPoster();
            studentPoster.PostStudent(Student);
            
        }

        public void PutStudent()
        {
            new StudentRepository().PutStudent(Student);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
