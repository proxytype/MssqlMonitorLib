using System;
using System.Collections.Generic;
using System.Text;

namespace MssqlMonitorLib.Utilities
{
    public class DBresponse
    {
        public bool isValid { get; set; }
        public string exception { get; set; }
        public object data { get; set; }
    }
}
