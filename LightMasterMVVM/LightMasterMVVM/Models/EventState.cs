using System;
using System.ComponentModel.DataAnnotations;

namespace LightMasterMVVM.Models
{
    public class EventState
    {
        [Key]
        public string event_key { get; set; }
        public int event_state { get; set; }
        public int matches_complete { get; set; }
        public int[] avg_a_pc { get; set; }
        public int[] avg_t_pc { get; set; }
        public int[] avg_endgame { get; set; }
    }
}
