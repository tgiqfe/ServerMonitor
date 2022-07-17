using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text.Json;

namespace ServerMonitor
{
    public class Setting
    {
        public string LogsPath { get; set; }
        public PingMonitorSetting Ping { get; set; }
        public CPUMonitorSetting CPU { get; set; }
        public MemoryMonitorSetting Memory { get; set; }
        public DiskMonitorSetting Disk { get; set; }
        public WebMonitorSetting Web { get; set; }
        public MailSenderSetting Mail { get; set; }

        public class PingMonitorSetting
        {
            public string ListPath { get; set; }
            public int? Interval { get; set; }
            public int? Count { get; set; }
            public int? MaxFailedCount { get; set; }
            public int? MinRestoreCount { get; set; }
        }

        public class CPUMonitorSetting
        {
            public int? Threshold { get; set; }
            public int? MaxFailedCount { get; set; }
            public int? MinRestoreCount { get; set; }
        }

        public class MemoryMonitorSetting
        {
            public int? Threshold { get; set; }
            public int? MaxFailedCount { get; set; }
            public int? MinRestoreCount { get; set; }
        }

        public class DiskMonitorSetting
        {
            public int? Threshold { get; set; }
            public int? MaxFailedCount { get; set; }
            public int? MinRestoreCount { get; set; }
        }

        public class WebMonitorSetting
        {
            public string Id { get; set; }
            public string Password { get; set; }
        }

        public class MailSenderSetting
        {
            public string Server { get; set; }
            public int? Port { get; set; }
            public string[] To { get; set; }
            public string From { get; set; }
        }

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
            if(setting == null)
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
