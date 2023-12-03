﻿using Diplom.Resources.Model;
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

        private List<Curator> allCurators;

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

            allCurators = curatorRepository.GetAll().ToList();

            Curators = new ObservableCollection<Curator>(allCurators);
        }

        public void FilterByName(string name) 
        {
            if (String.IsNullOrEmpty(name))
            {
                Curators = new ObservableCollection<Curator>(allCurators);
            }

            Curators = new ObservableCollection<Curator>(allCurators.Where(x => x.user.person.FullName1.ToLower().Contains(name.ToLower())));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
