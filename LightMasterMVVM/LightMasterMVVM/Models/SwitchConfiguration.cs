using System;
using System.Collections.Generic;
using System.Text;

namespace LightMasterMVVM.Models
{
    public class SwitchConfiguration
    {
        public int TeamNumber { get; set; }
        public string EventCode { get; set; }
        public string KeyScouter { get; set; }
        public DBConfiguraton Database { get; set; }
        public int AuthLockLevel { get; set; }
    }
    public class DBConfiguraton
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public string DatabaseName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Confirmed { get; set; }
    }
}
