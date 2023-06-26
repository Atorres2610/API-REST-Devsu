using System.Globalization;

namespace Devsu.Util.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime PeruDateTime { get { return DateTime.UtcNow.AddHours(-5); } }
        public static DateTime ToDateTime(this string sDate)
        {
            return DateTime.ParseExact(sDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        public static string ToDateString(this DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy");
        }
        public static string ToDateTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy HH:mm");
        }
        public static string ToTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm");
        }
    }
}
