using Diplom.Resources.Model;
using Diplom.Resources.Scripts;
using Diplom.Resources.Scripts.HttpRequests.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.ViewModel.Handlers
{
    internal class CuratorHandlerViewModel : INotifyPropertyChanged
    {
        private CuratorEntity curator;

        private GroupRepository groupRepository = new GroupRepository();
        private CuratorRepository curatorRepository = new CuratorRepository();

        public CuratorEntity Curator
        {
            get { return curator; }
            set
            {
                curator = value;
                OnPropertyChanged(nameof(Curator));
            }
        }

        private ObservableCollection<GroupEntity> groups;

        public ObservableCollection<GroupEntity> Groups
        {
            get { return groups; }
            set
            {
                groups = value;
                OnPropertyChanged(nameof(Groups));
            }
        }

        public CuratorHandlerViewModel()
        {
            Groups = new ObservableCollection<GroupEntity>(groupRepository.GetAll());

            Curator = new CuratorEntity();
            Curator.user.role.id = 2;
        }

        public CuratorHandlerViewModel(CuratorEntity curator)
        {
            Groups = new ObservableCollection<GroupEntity>(groupRepository.GetAll());

            this.Curator = curator;
        }

        public void AddCurator()
        {
            curatorRepository.Create(Curator);
        }

        public void UpdateCurator()
        {
            curatorRepository.Update(Curator);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
