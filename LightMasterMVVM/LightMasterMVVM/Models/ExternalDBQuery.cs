using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LightMasterMVVM.Models
{
    public class ExternalDBQuery
    {
        [JsonProperty("ODR")]
        public List<string> OrderByProperties { get; set; }
        [JsonProperty("RTN")]
        public List<string> ReturnProperties { get; set; }
        [JsonProperty("MAX")]
        public int MaxQuerySize { get; set; }
        [JsonProperty("INC")]
        public List<string> IncludedTeams { get; set; }

    }
    public class ExternalDBQueryResult
    {
        // HOI IM TEMMIE
        // HUMANS... SUCH A- CUTE~~
        [JsonProperty("TEM")]
        public int TeamNumber { get; set; }
        [JsonProperty("RLT")]
        public List<double> CorrespondingResults { get; set; }
    }
}
