using Diplom.Resources.Model;
using Diplom.Resources.Scripts.HttpRequests.Post;
using System;
using System.Collections.Generic;
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

        public StudentHandlerViewModel()
        {
            Student= new Student();
            Student.user.role.id = 3;
        }

        public StudentHandlerViewModel(Student student)
        {
            this.Student = student;
        }

        public void AddStudent()
        {
            StudentPoster studentPoster = new StudentPoster();
            studentPoster.PostStudent(Student);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
