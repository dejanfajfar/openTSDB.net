using System;

namespace openTSDB.net
{
    /// <summary>
    /// Extens the
    /// </summary>
    public static class DateTimeExtentions
    {
        public static int ToUnixEpoch(this DateTime dateTime)
        {
            var timeSinceDisco = TimeZoneInfo.ConvertTimeToUtc(dateTime.ToUniversalTime()) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return (int) timeSinceDisco.TotalSeconds;
        }
    }
}