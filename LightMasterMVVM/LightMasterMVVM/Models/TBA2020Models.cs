using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class TBA_BlueAlliance
    {
        public List<string> dq_team_keys { get; set; }
        public int score { get; set; }
        public List<string> surrogate_team_keys { get; set; }
        public List<string> team_keys { get; set; }

    }

    public class TBA_RedAlliance
    {
        public List<string> dq_team_keys { get; set; }
        public int score { get; set; }
        public List<string> surrogate_team_keys { get; set; }
        public List<string> team_keys { get; set; }

    }

    public class TBA_Alliances
    {
        public TBA_BlueAlliance blue { get; set; }
        public TBA_RedAlliance red { get; set; }

    }

    public class TBA_BlueBreakdown
    {
        public int adjustPoints { get; set; }
        public int autoCellPoints { get; set; }
        public int autoCellsBottom { get; set; }
        public int autoCellsInner { get; set; }
        public int autoCellsOuter { get; set; }
        public int autoInitLinePoints { get; set; }
        public int autoPoints { get; set; }
        public int controlPanelPoints { get; set; }
        public int endgamePoints { get; set; }
        public string endgameRobot1 { get; set; }
        public string endgameRobot2 { get; set; }
        public string endgameRobot3 { get; set; }
        public string endgameRungIsLevel { get; set; }
        public int foulCount { get; set; }
        public int foulPoints { get; set; }
        public string initLineRobot1 { get; set; }
        public string initLineRobot2 { get; set; }
        public string initLineRobot3 { get; set; }
        public int rp { get; set; }
        public bool shieldEnergizedRankingPoint { get; set; }
        public bool shieldOperationalRankingPoint { get; set; }
        public bool stage1Activated { get; set; }
        public bool stage2Activated { get; set; }
        public bool stage3Activated { get; set; }
        public string stage3TargetColor { get; set; }
        public int tba_numRobotsHanging { get; set; }
        public bool tba_shieldEnergizedRankingPointFromFoul { get; set; }
        public int techFoulCount { get; set; }
        public int teleopCellPoints { get; set; }
        public int teleopCellsBottom { get; set; }
        public int teleopCellsInner { get; set; }
        public int teleopCellsOuter { get; set; }
        public int teleopPoints { get; set; }
        public int totalPoints { get; set; }

    }

    public class TBA_RedBreakdown
    {
        public int adjustPoints { get; set; }
        public int autoCellPoints { get; set; }
        public int autoCellsBottom { get; set; }
        public int autoCellsInner { get; set; }
        public int autoCellsOuter { get; set; }
        public int autoInitLinePoints { get; set; }
        public int autoPoints { get; set; }
        public int controlPanelPoints { get; set; }
        public int endgamePoints { get; set; }
        public string endgameRobot1 { get; set; }
        public string endgameRobot2 { get; set; }
        public string endgameRobot3 { get; set; }
        public string endgameRungIsLevel { get; set; }
        public int foulCount { get; set; }
        public int foulPoints { get; set; }
        public string initLineRobot1 { get; set; }
        public string initLineRobot2 { get; set; }
        public string initLineRobot3 { get; set; }
        public int rp { get; set; }
        public bool shieldEnergizedRankingPoint { get; set; }
        public bool shieldOperationalRankingPoint { get; set; }
        public bool stage1Activated { get; set; }
        public bool stage2Activated { get; set; }
        public bool stage3Activated { get; set; }
        public string stage3TargetColor { get; set; }
        public int tba_numRobotsHanging { get; set; }
        public bool tba_shieldEnergizedRankingPointFromFoul { get; set; }
        public int techFoulCount { get; set; }
        public int teleopCellPoints { get; set; }
        public int teleopCellsBottom { get; set; }
        public int teleopCellsInner { get; set; }
        public int teleopCellsOuter { get; set; }
        public int teleopPoints { get; set; }
        public int totalPoints { get; set; }

    }

    public class TBA_ScoreBreakdown
    {
        public TBA_BlueBreakdown blue { get; set; }
        public TBA_RedBreakdown red { get; set; }

    }

    public class TBA_Video
    {
        public string key { get; set; }
        public string type { get; set; }

    }

    public class TBA_Match
    {
        public int actual_time { get; set; }
        public TBA_Alliances alliances { get; set; }
        public string comp_level { get; set; }
        public string event_key { get; set; }
        [Key]
        public string key { get; set; }
        public int match_number { get; set; }
        public int post_result_time { get; set; }
        public int predicted_time { get; set; }
        public TBA_ScoreBreakdown score_breakdown { get; set; }
        public int set_number { get; set; }
        public int time { get; set; }
        public List<TBA_Video> videos { get; set; }
        public string winning_alliance { get; set; }

    }
    public class TBA_DB_Model
    {
        public string rawjson { get; set; }
        public int match_number { get; set; }
        public string event_key { get; set; }
        [Key]
        public string key { get; set; }
    }
}
