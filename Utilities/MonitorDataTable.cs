using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Text;

namespace MssqlMonitorLib.Utilities
{
    public class MonitorTable
    {
        public DataRow rowUser { get; set; }
        public DataRow [] rowConnections { get; set; } 
        public DataRow[] rowSessions { get; set; }

    }
}
