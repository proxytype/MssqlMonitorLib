namespace MssqlMonitorLib.Utilities
{
    public class DBresponse
    {
        public bool isValid { get; set; }
        public string exception { get; set; }
        public object data { get; set; }
    }
}
