using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Acr.UserDialogs;

namespace Planbox.ViewModels
{
    public class BaseViewModel:INotifyPropertyChanged
    { 
     
        public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
