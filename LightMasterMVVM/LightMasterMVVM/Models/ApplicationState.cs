using LightMasterMVVM.Scripts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightMasterMVVM.Models
{
    public static class ApplicationState
    {
        public static string DBUsernameUsed { get; set; }
        public static string DBPasswordUsed { get; set; }
        public static Dictionary<string, DBAuthorizationToken> DBAuthTokens { get; set; }
        public static void PushDBCreds()
        {
            var configdatafile = new ConfigurationData();
            configdatafile.SaveData("Database.Username", DBUsernameUsed);
            configdatafile.SaveData("Database.Password", DBPasswordUsed);
        }
    }
    public class DBAuthorizationToken
    {
        public Guid Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Assigned { get; set; }
        public int TimesAccessed { get; set; }
    }
}
