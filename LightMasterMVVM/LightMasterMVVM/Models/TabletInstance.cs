using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class TabletInstance
    {
        [Key]
        public string Identifier { get; set; }
        public string TabletName { get; set; }
        public int LastKnownBattery { get; set; }
        public int AuthenticationLevel { get; set; }
        public string ColorId { get; set; }
        public DateTime LastCommunicated { get; set; }
        public DateTime DiagnosticReportReceived { get; set; }
    }
}
