public static class Extensions
{
    public static string ToShortTimeString(this TimeSpan t)
    {
        string ret = "";
        if (t.Hours > 0)
            ret = $"{t.Hours}:";

        if (t.TotalMinutes > 0)
        {
            if (t.Hours == 0)
                ret += $"{t.Minutes}:";
            else
                ret += $"{t.Minutes.ToString("D2")}:";
        }

        if (t.TotalSeconds > 0)
            ret += $"{t.Seconds.ToString("D2")}";
        else
            ret += "00";

        return ret;
    }
}