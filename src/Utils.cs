namespace NorbitBugTracker.Utils;

public static class IDManager
{
    private const long NBTEpoch = 1687802390000;
    private static long LastTime = 0;
    private static int Increment = 0;

    public static long GetID()
    {
        long unixTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long milliseconds = unixTime - NBTEpoch;
        if (milliseconds < LastTime)
            milliseconds = LastTime;
        if (milliseconds > LastTime)
        {
            LastTime = milliseconds;
            Increment = 0;
        }
        else
            Increment++;
        long id = (milliseconds << 22) + Increment;
        return id;
    }

    public static long IDtoTime(long id)
    {
        return ((id >> 22) + NBTEpoch) / 1000;
    }
}
