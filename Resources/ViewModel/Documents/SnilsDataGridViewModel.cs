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

        private ObservableCollection<SnilsEntity> snils;

        public StudentEntity student { get; set; }

        public ObservableCollection<SnilsEntity> Snils
        {
            get { return snils; }
            set
            {
                snils = value;
                OnPropertyChanged(nameof(Snils));
            }
        }

        public SnilsDataGridViewModel(StudentEntity student)
        {
            repository = new SnilsRepository();
            this.student = student;

            Snils = new ObservableCollection<SnilsEntity>(repository.GetAllByStudent(student.id));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
