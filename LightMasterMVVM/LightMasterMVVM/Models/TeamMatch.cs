using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class TeamMatch
    {
        [Key]
        public int MatchID { get; set; }
        public int TeamNumber { get; set; }
        public string TeamName { get; set; }
        public string EventCode { get; set; }
        public int MatchNumber { get; set; }
        public string RobotPosition { get; set; }
        public string ScoutName { get; set; }
        public bool A_InitiationLine { get; set; }
        public int[] PowerCellMissed { get; set; }
        public int[] PowerCellLower { get; set; }
        public int[] PowerCellOuter { get; set; }
        public int[] PowerCellInner { get; set; }
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
