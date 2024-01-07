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
    internal class FluorographyHandlerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private FluorographyRepository repository;

        private StudentEntity student;

        private FluorographyEntity fluorography;

        public FluorographyEntity Fluorography
        {
            get { return fluorography; }
            set
            {
                fluorography = value;
                OnPropertyChanged(nameof(Fluorography));
            }
        }

        public FluorographyHandlerViewModel(StudentEntity student)
        {
            Fluorography = new FluorographyEntity();
            repository = new FluorographyRepository();
            this.student = student;
        }

        public FluorographyHandlerViewModel(FluorographyEntity fluorography)
        {
            Fluorography = fluorography;
            repository = new FluorographyRepository();
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddFluorography()
        {
            Fluorography.student = student;
            repository.Post(new Requests.Fluorography.FluorographyCreateRequest(Fluorography), Fluorography.imageURL);
        }

        public void UpdateFluorography()
        {
            repository.Put(new Requests.Fluorography.FluorographyUpdateRequest(Fluorography), Fluorography.imageURL);
        }
    }
}
