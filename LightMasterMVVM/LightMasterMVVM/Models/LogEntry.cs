using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class LogEntry
    {
        private string _TimeFormatted;
        private string _Description;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string TimeFormatted
        {
            get
            {
                return this._TimeFormatted;
            }

            set
            {
                if (value != this._TimeFormatted)
                {
                    this._TimeFormatted = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Description
        {
            get
            {
                return this._Description;
            }

            set
            {
                if (value != this._Description)
                {
                    this._Description = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
