using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.ViewModel
{
    class PassesViewModel : INotifyPropertyChanged
    {
        //private ObservableCollection<Pass> passes;

        //public ObservableCollection<Pass> Passes
        //{
        //    get { return passes; }
        //    set 
        //    {
        //        passes = value;
        //        OnPropertyChanged(nameof(Passes));
        //    }
        //}

        public PassesViewModel()
        {
            //PassGetter passGetter = new PassGetter();
            //Passes = new ObservableCollection<Pass>(passGetter.GetAll());
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
