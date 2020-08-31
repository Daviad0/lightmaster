using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class TrackedProperty
    {
        private int _OrderNum;
        private string _OrderTypeProperty;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int OrderNum
        {
            get
            {
                return this._OrderNum;
            }

            set
            {
                if (value != this._OrderNum)
                {
                    this._OrderNum = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string OrderTypeProperty
        {
            get
            {
                return this._OrderTypeProperty;
            }

            set
            {
                if (value != this._OrderTypeProperty)
                {
                    this._OrderTypeProperty = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
