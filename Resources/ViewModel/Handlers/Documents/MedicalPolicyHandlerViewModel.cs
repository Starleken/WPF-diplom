using Diplom.Resources.Model;
using Diplom.Resources.Scripts;
using Diplom.Resources.Scripts.HttpRequests.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.ViewModel.Handlers.Documents
{
    internal class MedicalPolicyHandlerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private MedicalPolicyEntity medicalPolicy;

        public MedicalPolicyEntity MedicalPolicy
        {
            get { return medicalPolicy; }
            set 
            {
                medicalPolicy = value;
                OnPropertyChanged(nameof(MedicalPolicy));
            }
        }

        private StudentEntity student;
        private MedicalPolicyRepository repository;

        public MedicalPolicyHandlerViewModel(StudentEntity student)
        {
            MedicalPolicy = new MedicalPolicyEntity();

            this.student = student;
            this.repository = new MedicalPolicyRepository();
        }

        public MedicalPolicyHandlerViewModel(MedicalPolicyEntity medicalPolicy)
        {
            this.MedicalPolicy = medicalPolicy;
            this.repository = new MedicalPolicyRepository();
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddMedicalPolicy()
        {
            MedicalPolicy.student = student;
            repository.Post(MedicalPolicy);
        }

        public void UpdateMedicalPolicy()
        {
            repository.Put(MedicalPolicy);
        }
    }
}
