using Diplom.Resources.Model;
using Diplom.Resources.Scripts;
using Diplom.Resources.Scripts.HttpRequests.Post;
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
        private Curator curator;

        private GroupRepository groupRepository = new GroupRepository();
        private CuratorRepository curatorRepository = new CuratorRepository();

        public Curator Curator
        {
            get { return curator; }
            set
            {
                curator = value;
                OnPropertyChanged(nameof(Curator));
            }
        }

        private ObservableCollection<Group> groups;

        public ObservableCollection<Group> Groups
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
            Groups = new ObservableCollection<Group>(groupRepository.GetAll());

            Curator = new Curator();
            Curator.user.role.id = 2;
        }

        public CuratorHandlerViewModel(Curator curator)
        {
            Groups = new ObservableCollection<Group>(groupRepository.GetAll());

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
