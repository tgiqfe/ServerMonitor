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
        public CPUMonitorSetting CPU { get; set; }
        public MemoryMonitorSetting Memory { get; set; }
        public DiskMonitorSetting Disk { get; set; }
        public WebMonitorSetting Web { get; set; }
        public MailMonitorSetting Mail { get; set; }
    }
}
