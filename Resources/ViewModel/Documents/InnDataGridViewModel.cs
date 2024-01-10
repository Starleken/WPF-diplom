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
    internal class InnDataGridViewModel
    {
        private InnRepository repository;

        public StudentEntity student { get; set; }

        private ObservableCollection<InnEntity> innEntities;

        public ObservableCollection<InnEntity> InnEntities
        {
            get { return innEntities; }
            set
            {
                innEntities = value;
                OnPropertyChanged(nameof(InnEntities));
            }
        }

        public InnDataGridViewModel(StudentEntity student)
        {
            repository = new InnRepository();

            InnEntities = new ObservableCollection<InnEntity>(repository.GetAllByStudent(student.id));

            this.student = student;
        }

        public void DeleteInn(InnEntity inn)
        {
            InnEntities.Remove(inn);

            new InnRepository().DeleteById(inn.id);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
