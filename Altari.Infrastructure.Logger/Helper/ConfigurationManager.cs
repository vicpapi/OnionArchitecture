namespace Onion.Infrastructure.ApplicationLog.Helper
{
    public class ConfigurationManager
    {
        public static string LOG4NET_PATH { get; set; }
        public static string LOG4NET_ELEMENTNAME { get; set; }
        public static string LOG4NET_EMAIL_TO { get; set; }
        public static string LOG4NET_EMAIL_FROM { get; set; }
        public static string LOG4NET_EMAIL_SUBJECT { get; set; }
        public static string LOG4NET_EMAIL_BODY { get; set; }        
        public static string LOG4NET_EMAIL_SMTPHOST { get; set; }
        public static int LOG4NET_EMAIL_PORT { get; set; }
        public static string LOG4NET_EMAIL_USERNAME { get; set; }
        public static string LOG4NET_EMAIL_PASSWORD { get; set; }
        public static bool LOG4NET_EMAIL_ENABLEDSSL { get; set; }
    }
}
