using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text.Json;

namespace ServerMonitor.Config
{
    public class Setting : SettingBase
    {
        public string LogsPath { get; set; }
        public Ping Ping { get; set; }
        public CPU CPU { get; set; }
        public Memory Memory { get; set; }
        public Disk Disk { get; set; }
        public Web Web { get; set; }
        public Mail Mail { get; set; }





        public void Init()
        {

        }

        public static Setting Load(string filePath)
        {
            Setting setting = null;
            try
            {
                JsonSerializer.Deserialize<Setting>(File.ReadAllText(filePath), new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    IgnoreReadOnlyProperties = true,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                });
            }
            catch { }
            if (setting == null)
            {
                setting = new Setting();
                setting.Init();
            }
            return setting;
        }

        public void Save(string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(this, new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    IgnoreReadOnlyProperties = true,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                });
                File.WriteAllText(filePath, json);
            }
            catch { }
        }
    }
}
