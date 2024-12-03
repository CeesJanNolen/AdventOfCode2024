namespace Uptic.AdventOfCode2024;

public static class Input
{
    public static List<string> GetSampleAInput(int currentDay)
    {
        return File.ReadLines(
            "C:\\Users\\Cees-JanNolen\\code\\Uptic.AdventOfCode2024\\Uptic.AdventOfCode2024\\samples\\example_" +
            currentDay + "_A.txt").ToList();
    }

    public static List<string> GetSampleAInput()
    {
        var currentDay = DateTime.Now.Day;

        return GetSampleAInput(currentDay);
    }

    public static List<string> GetSampleBInput(int currentDay)
    {
        var file = "C:\\Users\\Cees-JanNolen\\code\\Uptic.AdventOfCode2024\\Uptic.AdventOfCode2024\\samples\\example_" +
                   currentDay + "_B.txt";
        if (File.Exists(file))
            return File.ReadLines(
                "C:\\Users\\Cees-JanNolen\\code\\Uptic.AdventOfCode2024\\Uptic.AdventOfCode2024\\samples\\example_" +
                currentDay + "_B.txt").ToList();
        return GetSampleAInput(currentDay);
    }

    public static List<string> GetSampleBInput()
    {
        var currentDay = DateTime.Now.Day;
        return GetSampleBInput(currentDay);
    }

    public static List<string> GetInput(int currentDay)
    {
        return File.ReadLines(
            "C:\\Users\\Cees-JanNolen\\code\\Uptic.AdventOfCode2024\\Uptic.AdventOfCode2024\\inputs\\input_" +
            currentDay + ".txt").ToList();
    }

    public static List<string> GetInput()
    {
        var currentDay = DateTime.Now.Day;
        return GetInput(currentDay);
    }
}