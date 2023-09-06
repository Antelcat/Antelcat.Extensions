using System.Runtime.CompilerServices;

namespace Antelcat.Extensions; 

public static class TimeExtension
{
    public static DateTime Timebase { get; } = new (1970, 1, 1);
    
    public static DateTime UtcTimebase { get; } = new (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    public static long CurrentUnixTimestamp => DateTimeOffset.Now.ToUnixTimeMilliseconds();
    public static DateTime ToLocalTime(this long timestamp) => DateTimeOffset.FromUnixTimeMilliseconds(timestamp).LocalDateTime;
    
    public static DateTime ToUtcTime(this long timestamp) => DateTimeOffset.FromUnixTimeMilliseconds(timestamp).UtcDateTime;
    
    public static long ToUnixTimestamp(this DateTime dateTime) => new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
    
    public static TaskAwaiter GetAwaiter(this int millionSeconds) => Task.Delay(millionSeconds).GetAwaiter();
}