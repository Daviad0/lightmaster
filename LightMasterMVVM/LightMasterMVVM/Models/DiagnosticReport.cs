using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class DiagnosticReport
    {
        public Connectivity currentConnection { get; set; }
        public string TabletId { get; set; }
        public bool EnergySaver { get; set; }
        public bool Charging { get; set; }
    }
    public enum Connectivity
    {
        None = 0,
        Local = 1,
        LimitedInternet = 2,
        FullInternet = 3,
    }
}
