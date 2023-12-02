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
    internal class CuratorsViewModel : INotifyPropertyChanged
    {
        private CuratorRepository curatorRepository;

        private ObservableCollection<Curator> curators;

        public ObservableCollection<Curator> Curators
        {
            get { return curators; }
            set 
            {
                curators = value;
                OnPropertyChanged(nameof(Curators));
            }
        }

        public CuratorsViewModel()
        {
            curatorRepository = new CuratorRepository();

            Curators = new ObservableCollection<Curator>(curatorRepository.GetAll());
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
