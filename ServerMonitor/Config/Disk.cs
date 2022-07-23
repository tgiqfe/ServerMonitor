using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMonitor.Config
{
    public class Disk : SettingBase
    {
        public int? Threshold { get; set; }
        public int? MaxFailedCount { get; set; }
        public int? MinRestoreCount { get; set; }

        protected override int IndentLength { get { return 2; } }
    }
}
