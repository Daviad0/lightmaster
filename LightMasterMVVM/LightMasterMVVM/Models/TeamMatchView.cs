using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class TeamMatchView : INotifyPropertyChanged
    {
        private int _TeamNumber;
        private string _EventCode;
        private int _MatchNumber;
        private string _ScoutName;
        private bool _A_InitiationLine;
        private int _APowerCellMissed;
        private int _APowerCellLower;
        private int _APowerCellOuter;
        private int _APowerCellInner;
        private int _AShotAccuracy;
        private int _TPowerCellMissed;
        private int _TPowerCellLower;
        private int _TPowerCellOuter;
        private int _TPowerCellInner;
        private int _TShotAccuracy;
        private int _NumCycles;
        private bool _T_ControlPanelRotation;
        private bool _T_ControlPanelPosition;
        private bool _E_Park;
        private bool _E_ClimbAttempt;
        private bool _E_ClimbSuccess;
        private bool _E_Balanced;
        private int _DisabledSeconds;
        private string _PartnersWith;
        private string _ImprovementShotPC;
        private int _CycleTime;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
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
        public int CycleTime
        {
            get
            {
                return this._CycleTime;
            }

            set
            {
                if (value != this._CycleTime)
                {
                    this._CycleTime = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string EventCode 
        {
            get
            {
                return this._EventCode;
            }

            set
            {
                if (value != this._EventCode)
                {
                    this._EventCode = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string ImprovementShotPC
        {
            get
            {
                return this._ImprovementShotPC;
            }

            set
            {
                if (value != this._ImprovementShotPC)
                {
                    this._ImprovementShotPC = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string PartnersWith
        {
            get
            {
                return this._PartnersWith;
            }

            set
            {
                if (value != this._PartnersWith)
                {
                    this._PartnersWith = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int MatchNumber 
        {
            get
            {
                return this._MatchNumber;
            }

            set
            {
                if (value != this._MatchNumber)
                {
                    this._MatchNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string ScoutName 
        {
            get
            {
                return this._ScoutName;
            }

            set
            {
                if (value != this._ScoutName)
                {
                    this._ScoutName = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool A_InitiationLine 
        {
            get
            {
                return this._A_InitiationLine;
            }

            set
            {
                if (value != this._A_InitiationLine)
                {
                    this._A_InitiationLine = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int APowerCellMissed 
        {
            get
            {
                return this._APowerCellMissed;
            }

            set
            {
                if (value != this._APowerCellMissed)
                {
                    this._APowerCellMissed = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int APowerCellLower 
        {
            get
            {
                return this._APowerCellLower;
            }

            set
            {
                if (value != this._APowerCellLower)
                {
                    this._APowerCellLower = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int APowerCellOuter 
        {
            get
            {
                return this._APowerCellOuter;
            }

            set
            {
                if (value != this._APowerCellOuter)
                {
                    this._APowerCellOuter = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int APowerCellInner 
        {
            get
            {
                return this._APowerCellInner;
            }

            set
            {
                if (value != this._APowerCellInner)
                {
                    this._APowerCellInner = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int AShotAccuracy
        {
            get
            {
                return this._AShotAccuracy;
            }

            set
            {
                if (value != this._AShotAccuracy)
                {
                    this._AShotAccuracy = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int TPowerCellMissed 
        {
            get
            {
                return this._TPowerCellMissed;
            }

            set
            {
                if (value != this._TPowerCellMissed)
                {
                    this._TPowerCellMissed = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int TPowerCellLower 
        {
            get
            {
                return this._TPowerCellLower;
            }

            set
            {
                if (value != this._TPowerCellLower)
                {
                    this._TPowerCellLower = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int TPowerCellOuter 
        {
            get
            {
                return this._TPowerCellOuter;
            }

            set
            {
                if (value != this._TPowerCellOuter)
                {
                    this._TPowerCellOuter = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int TPowerCellInner 
        {
            get
            {
                return this._TPowerCellInner;
            }

            set
            {
                if (value != this._TPowerCellInner)
                {
                    this._TPowerCellInner = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int TShotAccuracy
        {
            get
            {
                return this._TShotAccuracy;
            }

            set
            {
                if (value != this._TShotAccuracy)
                {
                    this._TShotAccuracy = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int NumCycles 
        {
            get
            {
                return this._NumCycles;
            }

            set
            {
                if (value != this._NumCycles)
                {
                    this._NumCycles = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool T_ControlPanelRotation 
        {
            get
            {
                return this._T_ControlPanelRotation;
            }

            set
            {
                if (value != this._T_ControlPanelRotation)
                {
                    this._T_ControlPanelRotation = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool T_ControlPanelPosition 
        {
            get
            {
                return this._T_ControlPanelPosition;
            }

            set
            {
                if (value != this._T_ControlPanelPosition)
                {
                    this._T_ControlPanelPosition = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool E_Park 
        {
            get
            {
                return this._E_Park;
            }

            set
            {
                if (value != this._E_Park)
                {
                    this._E_Park = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool E_ClimbAttempt 
        {
            get
            {
                return this._E_ClimbAttempt;
            }

            set
            {
                if (value != this._E_ClimbAttempt)
                {
                    this._E_ClimbAttempt = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool E_ClimbSuccess 
        {
            get
            {
                return this._E_ClimbSuccess;
            }

            set
            {
                if (value != this._E_ClimbSuccess)
                {
                    this._E_ClimbSuccess = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool E_Balanced 
        {
            get
            {
                return this._E_Balanced;
            }

            set
            {
                if (value != this._E_Balanced)
                {
                    this._E_Balanced = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int DisabledSeconds 
        {
            get
            {
                return this._DisabledSeconds;
            }

            set
            {
                if (value != this._DisabledSeconds)
                {
                    this._DisabledSeconds = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
