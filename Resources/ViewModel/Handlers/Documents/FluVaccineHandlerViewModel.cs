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
    internal class FluVaccineHandlerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private FluVaccineRepository repository;

        private StudentEntity student;

        private FluVaccineEntity fluVaccine;

        public FluVaccineEntity FluVaccine
        {
            get { return fluVaccine; }
            set
            {
                fluVaccine = value;
                OnPropertyChanged(nameof(FluVaccine));
            }
        }

        public FluVaccineHandlerViewModel(StudentEntity student)
        {
            FluVaccine = new FluVaccineEntity();
            repository = new FluVaccineRepository();
            this.student = student;
        }

        public FluVaccineHandlerViewModel(FluVaccineEntity fluVaccine)
        {
            FluVaccine = fluVaccine;
            repository = new FluVaccineRepository();
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddFluVaccine()
        {
            FluVaccine.student = student;
            repository.Post(new Requests.FluVaccine.FluVaccineCreateRequest(FluVaccine), FluVaccine.imageURL);
        }

        public void UpdateFluVaccine()
        {
            repository.Put(new Requests.FluVaccine.FluVaccineUpdateRequest(FluVaccine), FluVaccine.imageURL);
        }
    }
}
