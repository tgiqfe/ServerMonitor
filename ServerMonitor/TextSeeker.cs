using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ServerMonitor
{
    public class TextSeeker
    {
        private string[] _contentLines { get; set; }
        public int Position { get; set; }

        public TextSeeker(string content)
        {
            _contentLines = Regex.Split(content, @"\r?\n");
        }

        public string ReadLine()
        {
            if (Position == _contentLines.Length - 1)
            {
                return null;
            }
            return _contentLines[Position++];
        }

        public string PreviousLine()
        {
            if (Position == 0)
            {
                return _contentLines[0];
            }
            return _contentLines[Position - 1];
        }
    }
}
