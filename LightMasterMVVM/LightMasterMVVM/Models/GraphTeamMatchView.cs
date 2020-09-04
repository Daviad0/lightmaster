using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class GraphTeamMatchView
    {
        private int _TeamNumber;
        private int _TotalInnerPC;
        private int _TotalOuterPC;
        private int _TotalLowerPC;
        private int _TotalMissedPC;
        private int _AInnerPC;
        private int _AOuterPC;
        private int _ALowerPC;
        private int _AMissedPC;
        private int _TInnerPC;
        private int _TOuterPC;
        private int _TLowerPC;
        private int _TMissedPC;
        private int _TotalScoredPC;
        private int _TotalShotPC;
        private double _ParkRate;
        private double _ClimbRate;
        private double _BalanceRate;
        private int _Disabled;
        private double _DefenseRate;
        public int TeamNumber
        {
            get
            {
                return this._TeamNumber;
            }

            set
            {
                if (value != this._TeamNumber)
                {
                    this._TeamNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int TotalInnerPC
        {
            get
            {
                return this._TotalInnerPC;
            }

            set
            {
                if (value != this._TotalInnerPC)
                {
                    this._TotalInnerPC = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int TotalOuterPC
        {
            get
            {
                return this._TotalOuterPC;
            }

            set
            {
                if (value != this._TotalOuterPC)
                {
                    this._TotalOuterPC = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int TotalLowerPC
        {
            get
            {
                return this._TotalLowerPC;
            }

            set
            {
                if (value != this._TotalLowerPC)
                {
                    this._TotalLowerPC = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int TotalMissedPC
        {
            get
            {
                return this._TotalMissedPC;
            }

            set
            {
                if (value != this._TotalMissedPC)
                {
                    this._TotalMissedPC = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int AInnerPC
        {
            get
            {
                return this._AInnerPC;
            }

            set
            {
                if (value != this._AInnerPC)
                {
                    this._AInnerPC = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int AOuterPC
        {
            get
            {
                return this._AOuterPC;
            }

            set
            {
                if (value != this._AOuterPC)
                {
                    this._AOuterPC = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int ALowerPC
        {
            get
            {
                return this._ALowerPC;
            }

            set
            {
                if (value != this._ALowerPC)
                {
                    this._ALowerPC = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int AMissedPC
        {
            get
            {
                return this._AMissedPC;
            }

            set
            {
                if (value != this._AMissedPC)
                {
                    this._AMissedPC = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int TInnerPC
        {
            get
            {
                return this._TInnerPC;
            }

            set
            {
                if (value != this._TInnerPC)
                {
                    this._TInnerPC = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int TOuterPC
        {
            get
            {
                return this._TOuterPC;
            }

            set
            {
                if (value != this._TOuterPC)
                {
                    this._TOuterPC = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int TLowerPC
        {
            get
            {
                return this._TLowerPC;
            }

            set
            {
                if (value != this._TLowerPC)
                {
                    this._TLowerPC = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int TMissedPC
        {
            get
            {
                return this._TMissedPC;
            }

            set
            {
                if (value != this._TMissedPC)
                {
                    this._TMissedPC = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int TotalScoredPC
        {
            get
            {
                return this._TotalScoredPC;
            }

            set
            {
                if (value != this._TotalScoredPC)
                {
                    this._TotalScoredPC = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int TotalShotPC
        {
            get
            {
                return this._TotalShotPC;
            }

            set
            {
                if (value != this._TotalShotPC)
                {
                    this._TotalShotPC = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int Disabled
        {
            get
            {
                return this._Disabled;
            }

            set
            {
                if (value != this._Disabled)
                {
                    this._Disabled = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double ParkRate
        {
            get
            {
                return this._ParkRate;
            }

            set
            {
                if (value != this._ParkRate)
                {
                    this._ParkRate = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double ClimbRate
        {
            get
            {
                return this._ClimbRate;
            }

            set
            {
                if (value != this._ClimbRate)
                {
                    this._ClimbRate = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double BalanceRate
        {
            get
            {
                return this._BalanceRate;
            }

            set
            {
                if (value != this._BalanceRate)
                {
                    this._BalanceRate = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public double DefenseRate
        {
            get
            {
                return this._DefenseRate;
            }

            set
            {
                if (value != this._DefenseRate)
                {
                    this._DefenseRate = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
