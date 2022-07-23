using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitor.Config
{
    public class CPUMonitorSetting : SettingBase
    {
        protected override int IndentLength { get { return 2; } }

        public int? Threshold { get; set; }
        public int? MaxFailedCount { get; set; }
        public int? MinRestoreCount { get; set; }
    }
}
