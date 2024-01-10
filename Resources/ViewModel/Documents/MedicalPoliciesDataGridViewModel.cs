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
    internal class MedicalPoliciesDataGridViewModel : INotifyPropertyChanged
    {
        private MedicalPolicyRepository repository;

        public StudentEntity student { get; set; }

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

        public MedicalPoliciesDataGridViewModel(StudentEntity student)
        {
            repository = new MedicalPolicyRepository();

            MedicalPolicies = new ObservableCollection<MedicalPolicyEntity>(repository.GetAllByStudent(student.id));

            this.student = student;
        }

        public void DeleteMedicalPolicy(MedicalPolicyEntity medicalPolicy)
        {
            MedicalPolicies.Remove(medicalPolicy);

            new MedicalPolicyRepository().DeleteById(medicalPolicy.id);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
