using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitor.Config
{
    public class MailMonitorSetting : SettingBase
    {
        protected override int IndentLength { get { return 2; } }

        public string Server { get; set; }
        public int? Port { get; set; }
        public string[] To { get; set; }
        public string From { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
