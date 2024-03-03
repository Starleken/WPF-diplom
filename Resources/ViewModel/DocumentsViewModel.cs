using Diplom.Resources.Model;
using Diplom.Resources.Scripts.HttpRequests.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.ViewModel
{
    class DocumentsViewModel : INotifyPropertyChanged
    {
        public StudentEntity student { get; set; }

        private ObservableCollection<SnilsEntity> snils;

        public ObservableCollection<SnilsEntity> Snils
        {
            get { return snils; }
            set
            {
                snils = value;
                OnPropertyChanged(nameof(Snils));
            }
        }

        private ObservableCollection<FluorographyEntity> fluorographies;

        public ObservableCollection<FluorographyEntity> Fluorographies
        {
            get { return fluorographies; }
            set
            {
                fluorographies = value;
                OnPropertyChanged(nameof(Fluorographies));
            }
        }

        private ObservableCollection<MedicalPolicyEntity> medicalPolicies;

        public ObservableCollection<MedicalPolicyEntity> MedicalPolicies
        {
            get { return medicalPolicies; }
            set
            {
                medicalPolicies = value;
                OnPropertyChanged(nameof(MedicalPolicies));
            }
        }

        private ObservableCollection<FluVaccineEntity> fluVaccines;

        public ObservableCollection<FluVaccineEntity> FluVaccines
        {
            get { return fluVaccines; }
            set
            {
                fluVaccines = value;
                OnPropertyChanged(nameof(FluVaccines));
            }
        }

        public DocumentsViewModel(StudentEntity student)
        {
            this.student = student;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GetSnilsByStudent()
        {
            Snils = new ObservableCollection<SnilsEntity>(new SnilsRepository().GetAllByStudent(student.id).ToList());
        }

        public void GetFluographiesByStudent()
        {
            FluorographyEntity entity = new FluorographyRepository().GetAllByStudent(student.id);
            Fluorographies = new ObservableCollection<FluorographyEntity>(new List<FluorographyEntity>() { entity});
        }

        public void GetMedicalPoliciesByStudent()
        {
            MedicalPolicies = new ObservableCollection<MedicalPolicyEntity>(new MedicalPolicyRepository().GetAllByStudent(student.id).ToList());
        }

        public void GetFluVaccinesByStudent()
        {
            FluVaccines = new ObservableCollection<FluVaccineEntity>(new FluVaccineRepository().GetAllByStudent(student.id).ToList());
        }
    }
}
