using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class IO_TeamMatch
    {
        [JsonProperty("ID")]
        public int MatchID { get; set; }
        [JsonProperty("T#")]
        public int TeamNumber { get; set; }
        [JsonProperty("COL")]
        public string TabletId { get; set; }
        [JsonProperty("Q?")]
        public bool IsQualifying { get; set; }
        [JsonProperty("NAME")]
        public string TeamName { get; set; }
        [JsonProperty("E#")]
        public string EventCode { get; set; }
        [JsonProperty("M#")]
        public int MatchNumber { get; set; }
        [JsonProperty("POS")]
        public string RobotPosition { get; set; }
        [JsonProperty("SCT")]
        public string ScoutName { get; set; }
        [JsonProperty("ALN")]
        public bool A_InitiationLine { get; set; }
        [JsonProperty("PCM")]
        public int[] PowerCellMissed { get; set; }
        [JsonProperty("PCI")]
        public int[] PowerCellLower { get; set; }
        [JsonProperty("PCL")]
        public int[] PowerCellOuter { get; set; }
        [JsonProperty("PCO")]
        public int[] PowerCellInner { get; set; }
        [JsonProperty("CYC#")]
        public int NumCycles { get; set; }
        [JsonProperty("CPR")]
        public bool T_ControlPanelRotation { get; set; }
        [JsonProperty("CPP")]
        public bool T_ControlPanelPosition { get; set; }
        [JsonProperty("PRK")]
        public bool E_Park { get; set; }
        [JsonProperty("CMBA")]
        public bool E_ClimbAttempt { get; set; }
        [JsonProperty("CMBS")]
        public bool E_ClimbSuccess { get; set; }
        [JsonProperty("BAL")]
        public bool E_Balanced { get; set; }
        [JsonProperty("DSEC")]
        public int DisabledSeconds { get; set; }
        [JsonProperty("SBM")]
        public bool ClientSubmitted { get; set; }
        [JsonProperty("LSBM")]
        public DateTime ClientLastSubmitted { get; set; }
        [JsonProperty("LOGS")]
        public string[] TapLogs { get; set; }
        [JsonProperty("WITH")]
        public int[] AlliancePartners { get; set; }
        [JsonProperty("CYCS")]
        public int CycleTime { get; set; }
        [JsonProperty("DEFF")]
        public bool DefenseFor { get; set; }
        [JsonProperty("DEFA")]
        public bool DefenseAgainst { get; set; }
        [JsonProperty("COSH")]
        public int[] ShotCoordinates { get; set; }
        [JsonProperty("COLD")]
        public int[] LoadCoordinates { get; set; }
    }
}
