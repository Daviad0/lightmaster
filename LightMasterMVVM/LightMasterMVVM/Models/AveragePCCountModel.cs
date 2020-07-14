using System;
using System.Collections.Generic;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class AveragePCCountModel
    {
        public int TeamNumber { get; set; }
        public int AvgInnerPC { get; set; }
        public int AvgOuterPC { get; set; }
        public int AvgLowerPC { get; set; }
        public int AvgTotalPC { get; set; }
        public int Matches { get; set; }
    }
}
