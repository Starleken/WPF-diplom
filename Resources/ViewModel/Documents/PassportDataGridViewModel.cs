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
    class PassportDataGridViewModel : INotifyPropertyChanged
    {
        private PassportRepository repository;

        private ObservableCollection<PassportEntity> passports;

        public StudentEntity student { get; set; }

        public ObservableCollection<PassportEntity> Passports
        {
            get { return passports; }
            set
            {
                passports = value;
                OnPropertyChanged(nameof(Passports));
            }
        }

        public PassportDataGridViewModel(StudentEntity student)
        {
            repository = new PassportRepository();
            this.student = student;

            Passports = new ObservableCollection<PassportEntity>(repository.GetAllByStudent(student.id));
        }

        public void DeletePassport(PassportEntity passport)
        {
            Passports.Remove(passport);

            new PassportRepository().DeleteById(passport.id);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
