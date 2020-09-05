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
        private bool _Show;
        private bool _Ascending;
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
        public bool Show
        {
            get
            {
                return this._Show;
            }

            set
            {
                if (value != this._Show)
                {
                    this._Show = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool Ascending
        {
            get
            {
                return this._Ascending;
            }

            set
            {
                if (value != this._Ascending)
                {
                    this._Ascending = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
