using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class TeamMatchView
    {
        public int TeamNumber { get; set; }
        public string EventCode { get; set; }
        public int MatchNumber { get; set; }
        public string ScoutName { get; set; }
        public bool A_InitiationLine { get; set; }
        public int APowerCellMissed { get; set; }
        public int APowerCellLower { get; set; }
        public int APowerCellOuter { get; set; }
        public int APowerCellInner { get; set; }
        public int TPowerCellMissed { get; set; }
        public int TPowerCellLower { get; set; }
        public int TPowerCellOuter { get; set; }
        public int TPowerCellInner { get; set; }
        public int NumCycles { get; set; }
        public bool T_ControlPanelRotation { get; set; }
        public bool T_ControlPanelPosition { get; set; }
        public bool E_Park { get; set; }
        public bool E_ClimbAttempt { get; set; }
        public bool E_ClimbSuccess { get; set; }
        public bool E_Balanced { get; set; }
        public int DisabledSeconds { get; set; }
    }
}
