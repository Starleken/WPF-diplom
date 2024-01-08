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
    internal class FluVaccineDataGridViewModel : INotifyPropertyChanged
    {
        private FluVaccineRepository repository;

        private ObservableCollection<FluVaccineEntity> fluVaccines;

        public StudentEntity student { get; set; }

        public ObservableCollection<FluVaccineEntity> FluVaccines
        {
            get { return fluVaccines; }
            set
            {
                fluVaccines = value;
                OnPropertyChanged(nameof(FluVaccines));
            }
        }

        public FluVaccineDataGridViewModel(StudentEntity student)
        {
            this.student = student;
            repository = new FluVaccineRepository();

            FluVaccines = new ObservableCollection<FluVaccineEntity>(repository.GetAllByStudent(student.id));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
