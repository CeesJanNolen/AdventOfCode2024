namespace Uptic.AdventOfCode2024;

public static class Utils
{
    public static bool IsDigit(this char c)
    {
        return int.TryParse(c.ToString(), out _);
    }
    
    public static int ToInt(this string s)
    {
        return int.Parse(s);
    }
}