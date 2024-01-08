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
    internal class InnHandlerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private InnRepository repository;

        private StudentEntity student;

        private InnEntity inn;

        public InnEntity Inn
        {
            get { return inn; }
            set
            {
                inn = value;
                OnPropertyChanged(nameof(Inn));
            }
        }

        public InnHandlerViewModel(StudentEntity student)
        {
            Inn = new InnEntity();
            repository = new InnRepository();
            this.student = student;
        }

        public InnHandlerViewModel(InnEntity inn)
        {
            Inn = inn;
            repository = new InnRepository();
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddInn()
        {
            Inn.student = student;
            repository.Post(new Requests.Inn.InnCreateRequest(Inn), Inn.imageURL);
        }

        public void UpdateInn()
        {
            repository.Put(new Requests.Inn.InnUpdateRequest(Inn), Inn.imageURL);
        }
    }
}
