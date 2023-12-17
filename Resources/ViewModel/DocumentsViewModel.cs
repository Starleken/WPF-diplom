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
        public Student student { get; set; }

        private ObservableCollection<Snils> snils;

        public ObservableCollection<Snils> Snils
        {
            get { return snils; }
            set
            {
                snils = value;
                OnPropertyChanged(nameof(Snils));
            }
        }

        private ObservableCollection<Fluorography> fluorographies;

        public ObservableCollection<Fluorography> Fluorographies
        {
            get { return fluorographies; }
            set
            {
                fluorographies = value;
                OnPropertyChanged(nameof(Fluorographies));
            }
        }

        private ObservableCollection<MedicalPolicy> medicalPolicies;

        public ObservableCollection<MedicalPolicy> MedicalPolicies
        {
            get { return medicalPolicies; }
            set
            {
                medicalPolicies = value;
                OnPropertyChanged(nameof(MedicalPolicies));
            }
        }

        private ObservableCollection<FluVaccine> fluVaccines;

        public ObservableCollection<FluVaccine> FluVaccines
        {
            get { return fluVaccines; }
            set
            {
                fluVaccines = value;
                OnPropertyChanged(nameof(FluVaccines));
            }
        }

        public DocumentsViewModel(Student student)
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
            Snils = new ObservableCollection<Snils>(new SnilsRepository().GetAllByStudent(student.id).ToList());
        }

        public void GetFluographiesByStudent()
        {
            Fluorographies = new ObservableCollection<Fluorography>(new FluorographyRepository().GetAllByStudent(student.id).ToList());
        }

        public void GetMedicalPoliciesByStudent()
        {
            MedicalPolicies = new ObservableCollection<MedicalPolicy>(new MedicalPolicyRepository().GetAllByStudent(student.id).ToList());
        }

        public void GetFluVaccinesByStudent()
        {
            FluVaccines = new ObservableCollection<FluVaccine>(new FluVaccineRepository().GetAllByStudent(student.id).ToList());
        }
    }
}
