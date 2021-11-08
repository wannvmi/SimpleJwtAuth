namespace SimpleJwtAuth.Core.Extensions;
public class TimeStampHelper
{
    public static double ConvertUnixTimeStamp(DateTime time)
    {
        //create Timespan by subtracting the value provided from
        //the Unix Epoch
        TimeSpan span = (time - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

        //return the total seconds (which is a UNIX timestamp)
        return (double)span.TotalSeconds;
    }

    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        return dtDateTime;
    }

    public static double ConvertJavaTimeStamp(DateTime time)
    {
        //create Timespan by subtracting the value provided from
        //the Unix Epoch
        TimeSpan span = (time - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

        //return the total Milliseconds (which is a Java timestamp)
        return (double)span.TotalMilliseconds;
    }

    public static double? ConvertJavaTimeStamp(DateTime? time)
    {
        if (!time.HasValue) return null;

        //create Timespan by subtracting the value provided from
        //the Unix Epoch
        TimeSpan span = (time.Value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

        //return the total Milliseconds (which is a Java timestamp)
        return (double)span.TotalMilliseconds;
    }

    public static DateTime JavaTimeStampToDateTime(double javaTimeStamp)
    {
        // Java timestamp is milliseconds past epoch
        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddMilliseconds(javaTimeStamp).ToLocalTime();
        return dtDateTime;
    }
}
