using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class TabletDataViewModel
    {
        private string _Identifier;
        private string _TabletName;
        private string _TabletColorName;
        private string _TabletColorBackground;
        private string _LastSubmittedTest;
        private string _BatteryLevel;
        private string _BatteryLevelColor;
        private string _AuthenticationLevel;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Identifier
        {
            get
            {
                return this._Identifier;
            }

            set
            {
                if (value != this._Identifier)
                {
                    this._Identifier = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string TabletName
        {
            get
            {
                return this._TabletName;
            }

            set
            {
                if (value != this._TabletName)
                {
                    this._TabletName = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string TabletColorName
        {
            get
            {
                return this._TabletColorName;
            }

            set
            {
                if (value != this._TabletColorName)
                {
                    this._TabletColorName = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string TabletColorBackground
        {
            get
            {
                return this._TabletColorBackground;
            }

            set
            {
                if (value != this._TabletColorBackground)
                {
                    this._TabletColorBackground = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string LastSubmittedTest
        {
            get
            {
                return this._LastSubmittedTest;
            }

            set
            {
                if (value != this._LastSubmittedTest)
                {
                    this._LastSubmittedTest = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string BatteryLevel
        {
            get
            {
                return this._BatteryLevel;
            }

            set
            {
                if (value != this._BatteryLevel)
                {
                    this._BatteryLevel = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string BatteryLevelColor
        {
            get
            {
                return this._BatteryLevelColor;
            }

            set
            {
                if (value != this._BatteryLevelColor)
                {
                    this._BatteryLevelColor = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string AuthenticationLevel
        {
            get
            {
                return this._AuthenticationLevel;
            }

            set
            {
                if (value != this._AuthenticationLevel)
                {
                    this._AuthenticationLevel = value;
                    NotifyPropertyChanged();
                }
            }
        }

    }
}
