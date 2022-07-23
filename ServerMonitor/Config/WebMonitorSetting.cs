using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitor.Config
{
    public class WebMonitorSetting : SettingBase
    {
        protected override int IndentLength { get { return 2; } }

        public string Id { get; set; }
        public string Password { get; set; }
    }
}
