using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class TeamMatch
    {
        [Key]
        public int MatchID { get; set; }
        public string TabletId { get; set; }
        public bool IsQualifying { get; set; }
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
        public bool ClientSubmitted { get; set; }
        public DateTime ClientLastSubmitted { get; set; }
        public bool APIChecked { get; set; }
        public int APIAccuracy { get; set; }
        public string[] TapLogs { get; set; }

        [ForeignKey("TrackedTeam")]
        public int team_instance_id { get; set; }
        public virtual FRCTeamModel TrackedTeam { get; set; }
        public int[] AlliancePartners { get; set; }
        public int CycleTime { get; set; }
    }
}
