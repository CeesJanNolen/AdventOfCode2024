namespace Uptic.AdventOfCode2024.Solutions;

public class Day1 : IDay
{
    public string PartA(List<string> lines)
    {
        var list1 = new List<int>();
        var list2 = new List<int>();
        foreach (var line in lines)
        {
            list1.Add(line.Split("   ")[0].ToInt());
            list2.Add(line.Split("   ")[1].ToInt());
        }

        list1.Sort();
        list2.Sort();

        var ans = list1.Select((t, i) => Math.Abs(t - list2[i])).Sum();

        return ans.ToString();
    }

    public string PartB(List<string> lines)
    {
        var list1 = new List<int>();
        var list2 = new List<int>();
        foreach (var line in lines)
        {
            list1.Add(line.Split("   ")[0].ToInt());
            list2.Add(line.Split("   ")[1].ToInt());
        }

        var ans = list1.Select(t => t * list2.Count(y => t == y)).Sum();

        return ans.ToString();
    }
}