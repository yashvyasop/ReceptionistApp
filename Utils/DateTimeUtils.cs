using System;

namespace ReceptionistApp.Utils
{
    public static class DateTimeUtils
    {
        public static string FormatDateTime(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static DateTime ParseDateTime(string dateTimeString)
        {
            return DateTime.ParseExact(dateTimeString, "yyyy-MM-dd HH:mm:ss", null);
        }
    }
}