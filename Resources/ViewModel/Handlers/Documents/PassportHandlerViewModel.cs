using Diplom.Resources.Model;
using Diplom.Resources.Scripts.HttpRequests.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.ViewModel.Handlers.Documents
{
    class PassportHandlerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private PassportEntity passport;

        public PassportEntity Passport
        {
            get { return passport; }
            set
            {
                passport = value;
                OnPropertyChanged(nameof(Passport));
            }
        }

        private StudentEntity student;
        private PassportRepository repository;

        public PassportHandlerViewModel(StudentEntity student)
        {
            Passport = new PassportEntity();

            this.student = student;
            this.repository = new PassportRepository();
        }

        public PassportHandlerViewModel(PassportEntity passport)
        {
            this.Passport = passport;
            this.repository = new PassportRepository();
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddPassport()
        {
            Passport.student = student;
            repository.Post(new Requests.Passport.PassportCreateRequest(Passport), Passport.imageURL);
        }

        public void UpdatePassport()
        {
            repository.Put(new Requests.Passport.PassportUpdateRequest(Passport), Passport.imageURL);
        }
    }
}
