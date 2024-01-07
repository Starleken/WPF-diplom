using Diplom.Resources.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.ViewModel
{
    internal class MainMenuViewModel : INotifyPropertyChanged
    {
		private UserEntity user;

		public UserEntity User
		{
			get { return user; }
			set 
			{
				user = value; 
				OnPropertyChanged(nameof(User));
			}
		}

        public MainMenuViewModel(UserEntity user)
        {
            this.User = user;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

		public void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
