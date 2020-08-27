using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LightMasterMVVM.Models
{
    public class FullMatchView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //MAYBE?
    }
}
