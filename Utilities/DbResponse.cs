using System.Data;

namespace MssqlMonitorLib.Utilities
{
    public class DBresponse
    {
        public bool isValid { get; set; } = true;
        public string exception { get; set; }
        public DataTable table { get; set; }
    }
}
