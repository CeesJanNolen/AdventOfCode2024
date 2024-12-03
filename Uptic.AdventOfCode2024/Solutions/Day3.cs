using System.Text.RegularExpressions;

namespace Uptic.AdventOfCode2024.Solutions;

public class Day3 : IDay
{
    public string PartA(List<string> lines)
    {
        var ans = 0;

        const string regex = "mul\\(\\d+\\,\\d+\\)";
        foreach (var line in lines)
        {
            var matches = Regex.Matches(line, regex);

            foreach (Match match in matches)
            {
                var firstDigits = match.Value.Split("(")[1].Split(",")[0].ToInt();
                var secondDigits = match.Value.Split(",")[1].Split(")")[0].ToInt();

                ans += firstDigits * secondDigits;
            }
        }

        return ans.ToString();
    }

    public string PartB(List<string> lines)
    {
        var ans = 0;

        const string mulRegex = "mul\\(\\d+\\,\\d+\\)";
        const string doRegex = "do\\(\\)";
        const string dontRegex = "don't\\(\\)";
        var startForbidden = false;
        foreach (var line in lines)
        {
            var forbiddenAreas = new List<Tuple<int, int>>();

            var mulMatches = Regex.Matches(line, mulRegex);
            var doMatches = Regex.Matches(line, doRegex);

            if (startForbidden)
            {
                forbiddenAreas.Add(new Tuple<int, int>(0, doMatches.FirstOrDefault()?.Index ?? int.MaxValue));
            }

            var dontMatches = Regex.Matches(line, dontRegex);
            foreach (Match dontMatch in dontMatches)
            {
                var startIndex = dontMatch.Index;
                var endIndex = int.MaxValue;
                foreach (Match doMatch in doMatches)
                {
                    if (doMatch.Index > startIndex && doMatch.Index < endIndex)
                    {
                        endIndex = doMatch.Index;
                        break;
                    }
                }

                forbiddenAreas.Add(new Tuple<int, int>(startIndex, endIndex));
            }

            foreach (Match match in mulMatches)
            {
                if (forbiddenAreas.Any(t => match.Index >= t.Item1 && match.Index <= t.Item2))
                {
                    continue;
                }

                var firstDigits = match.Value.Split("(")[1].Split(",")[0].ToInt();
                var secondDigits = match.Value.Split(",")[1].Split(")")[0].ToInt();

                ans += firstDigits * secondDigits;
            }

            startForbidden = forbiddenAreas.Last().Item2 == int.MaxValue;
        }

        return ans.ToString();
    }
}