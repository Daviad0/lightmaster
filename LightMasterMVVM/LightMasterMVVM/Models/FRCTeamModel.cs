using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class FRCTeamModel
    {
        [Key]
        public int team_instance_id { get; set; }
        public string event_key { get; set; }
        public int team_number { get; set; }
        public string rated_tier { get; set; }
        public string notes { get; set; }

        public virtual ICollection<TeamMatch> TeamMatches { get; set; }
    }
}
