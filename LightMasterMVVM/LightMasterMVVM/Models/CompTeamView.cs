using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class CompTeamView
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private int _team_number;
        public int team_number
        {
            get
            {
                return this._team_number;
            }

            set
            {
                if (value != this._team_number)
                {
                    this._team_number = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
