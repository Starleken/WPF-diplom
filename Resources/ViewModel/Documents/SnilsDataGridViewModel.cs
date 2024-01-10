using Diplom.Resources.Model;
using Diplom.Resources.Scripts.HttpRequests.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.ViewModel.Documents
{
    internal class SnilsDataGridViewModel : INotifyPropertyChanged
    {
        private SnilsRepository repository;

        private ObservableCollection<SnilsEntity> snilses;

        public StudentEntity student { get; set; }

        public ObservableCollection<SnilsEntity> Snilses
        {
            get { return snilses; }
            set
            {
                snilses = value;
                OnPropertyChanged(nameof(Snilses));
            }
        }

        public SnilsDataGridViewModel(StudentEntity student)
        {
            repository = new SnilsRepository();
            this.student = student;

            Snilses = new ObservableCollection<SnilsEntity>(repository.GetAllByStudent(student.id));
        }

        public void DeleteSnils(SnilsEntity snils)
        {
            Snilses.Remove(snils);

            new SnilsRepository().DeleteById(snils.id);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
