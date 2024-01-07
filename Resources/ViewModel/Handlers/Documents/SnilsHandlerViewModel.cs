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
    internal class SnilsHandlerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private SnilsRepository repository;

        private StudentEntity student;

        private SnilsEntity snils;

        public SnilsEntity Snils
        {
            get { return snils; }
            set
            {
                snils = value;
                OnPropertyChanged(nameof(Snils));
            }
        }

        public SnilsHandlerViewModel(StudentEntity student)
        {
            Snils = new SnilsEntity();
            repository = new SnilsRepository();
            this.student = student;
        }

        public SnilsHandlerViewModel(SnilsEntity snils)
        {
            Snils = snils;
            repository = new SnilsRepository();
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddSnils()
        {
            Snils.student = student;
            repository.Post(Snils);
        }

        public void UpdateSnils()
        {
            repository.Put(Snils);
        }
    }
}
