using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using LightMasterMVVM.Models;
using System.Reflection;
using SharpDX;

namespace LightMasterMVVM.Scripts
{
    public class ConfigurationData
    {
        public void SaveData(string propertyName, object value)
        {
            var docpath = Environment.SpecialFolder.ApplicationData.ToString();
            try
            {
                System.IO.Directory.CreateDirectory(Path.Combine(docpath, "LightSwitch"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            docpath = Path.Combine(docpath, "LightSwitch");
            var finalPath = Path.Combine(docpath, "currentconfig.txt");
            var prevresult = "";

            try
            {
                prevresult = System.IO.File.ReadAllText(finalPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                prevresult = JsonConvert.SerializeObject(new SwitchConfiguration() { AuthLockLevel = 1, EventCode = "", KeyScouter = "", TeamNumber = 0, Database = new DBConfiguraton() { Address = "localhost", Confirmed = false, DatabaseName = "lightscoutx", Port = 5432, Password = "strategy", Username = "strategy_member" } });
            }
            var previousobject = JsonConvert.DeserializeObject<SwitchConfiguration>(prevresult);
            PropertyInfo propertyInfo = previousobject.GetType().GetProperty(propertyName);
            propertyInfo.SetValue(previousobject, Convert.ChangeType(value, propertyInfo.PropertyType), null);


            try
            {
                System.IO.File.WriteAllText(finalPath,JsonConvert.SerializeObject(previousobject));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public SwitchConfiguration LoadData()
        {
            var docpath = Environment.SpecialFolder.ApplicationData.ToString();
            try
            {
                System.IO.Directory.CreateDirectory(Path.Combine(docpath, "LightSwitch"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            docpath = Path.Combine(docpath, "LightSwitch");
            var finalPath = Path.Combine(docpath, "currentconfig.txt");
            var result = "";

            try
            {
                result = System.IO.File.ReadAllText(finalPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                result = JsonConvert.SerializeObject(new SwitchConfiguration() { AuthLockLevel = 1, EventCode = "2020mijac", KeyScouter = "Imaex Ample", TeamNumber = 862, Database = new DBConfiguraton() { Address = "localhost", Confirmed = false, DatabaseName = "lightscoutx", Port = 5432, Password = "strategy", Username = "strategy_member" } });
            }
            return JsonConvert.DeserializeObject<SwitchConfiguration>(result);
        }
    }
}
