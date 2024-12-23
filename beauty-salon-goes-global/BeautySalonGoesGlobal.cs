using System;
using System.Globalization;
using System.Runtime.InteropServices;

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        string timeZoneId = GetTimeZoneId(location);
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        var localTime = DateTime.Parse(appointmentDateDescription, CultureInfo.InvariantCulture);
        return TimeZoneInfo.ConvertTimeToUtc(localTime, timeZone);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) => alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddMinutes(-105),
            AlertLevel.Late => appointment.AddMinutes(-30),
            _ => throw new ArgumentOutOfRangeException(nameof(alertLevel), "Invalid alert level")
        };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        string timeZoneId = GetTimeZoneId(location);
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        var oneWeekAgo = dt.AddDays(-7);
        bool currentIsDst = timeZone.IsDaylightSavingTime(dt);
        bool previousIsDst = timeZone.IsDaylightSavingTime(oneWeekAgo);
        return currentIsDst != previousIsDst;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        try
        {
            var cultureInfo = GetCultureInfo(location);
            return DateTime.Parse(dtStr, cultureInfo);
        }
        catch
        {
            return new DateTime(1, 1, 1);
        }
    }

    private static string GetTimeZoneId(Location location)
    {
        bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        return location switch
        {
            Location.NewYork => isWindows ? "Eastern Standard Time" : "America/New_York",
            Location.London => isWindows ? "GMT Standard Time" : "Europe/London",
            Location.Paris => isWindows ? "W. Europe Standard Time" : "Europe/Paris",
            _ => throw new ArgumentOutOfRangeException(nameof(location), "Invalid location")
        };
    }

    private static CultureInfo GetCultureInfo(Location location) => location switch
        {
            Location.NewYork => new CultureInfo("en-US"),
            Location.London => new CultureInfo("en-GB"),
            Location.Paris => new CultureInfo("fr-FR"),
            _ => throw new ArgumentOutOfRangeException(nameof(location), "Invalid location")
        };
}

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}
