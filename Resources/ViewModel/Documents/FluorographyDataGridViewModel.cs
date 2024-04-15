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
    internal class FluorographyDataGridViewModel : INotifyPropertyChanged
    {
        private FluorographyRepository repository;

        private ObservableCollection<FluorographyEntity> fluorographies;

        public StudentEntity student { get; set; }

        public ObservableCollection<FluorographyEntity> Fluorographies
        {
            get { return fluorographies; }
            set 
            {
                fluorographies = value; 
                OnPropertyChanged(nameof(Fluorographies));
            }
        }

        public FluorographyDataGridViewModel(StudentEntity student)
        {
            repository = new FluorographyRepository();
            this.student = student;

            Fluorographies = new ObservableCollection<FluorographyEntity>(new FluorographyRepository().GetAllByStudent(student.id).ToList());
        }

        public void DeleteFluorography(FluorographyEntity fluorography)
        {
            Fluorographies.Remove(fluorography);

            new FluorographyRepository().DeleteById(fluorography.id);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
