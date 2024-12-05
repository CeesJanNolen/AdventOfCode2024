namespace Uptic.AdventOfCode2024.Solutions;

public class Day5 : IDay
{
    public string PartA(List<string> lines)
    {
        var ans = 0;

        var rules = new Dictionary<int, List<int>>();

        var parsingRules = true;
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                parsingRules = false;
                continue;
            }

            if (parsingRules)
            {
                rules.TryAdd(int.Parse(line.Split("|")[0]), new List<int>());
                rules[int.Parse(line.Split("|")[0])].Add(int.Parse(line.Split("|")[1]));
            }
            else
            {
                var numbers = line.Split(",").Select(int.Parse).ToList();
                var isValid = IsValidLine(numbers, rules);
                if (isValid)
                {
                    ans += numbers.GetMiddle();
                }
            }
        }

        return ans.ToString();
    }

    private static bool IsValidLine(List<int> numbers, Dictionary<int, List<int>> rules)
    {
        for (var i = 0; i < numbers.Count; i++)
        {
            var number = numbers[i];

            var relatedRules = rules.TryGetValue(number, out var relatedRulesList) ? relatedRulesList : new List<int>();
            foreach (var relatedRule in relatedRules)
            {
                var indexOfRelatedBeforeAfterNumber = numbers.IndexOf(relatedRule);
                if (indexOfRelatedBeforeAfterNumber != -1 && indexOfRelatedBeforeAfterNumber < i)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public string PartB(List<string> lines)
    {
        var ans = 0;

        var rules = new Dictionary<int, List<int>>();

        var parsingRules = true;
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                parsingRules = false;
                continue;
            }

            if (parsingRules)
            {
                rules.TryAdd(int.Parse(line.Split("|")[0]), new List<int>());
                rules[int.Parse(line.Split("|")[0])].Add(int.Parse(line.Split("|")[1]));
            }
            else
            {
                var numbers = line.Split(",").Select(int.Parse).ToList();
                var isValid = IsValidLine(numbers, rules);
                if (isValid) continue;

                MakeValid(numbers, rules);

                ans += numbers.GetMiddle();
            }
        }

        return ans.ToString();
    }

    private static void MakeValid(List<int> numbers, Dictionary<int, List<int>> rules)
    {
        for (var i = 0; i < numbers.Count; i++)
        {
            var relatedRules = rules.TryGetValue(numbers[i], out var relatedRulesList)
                ? relatedRulesList
                : new List<int>();
            foreach (var relatedRule in relatedRules)
            {
                var indexOfRelatedBeforeAfterNumber = numbers.IndexOf(relatedRule);
                if (indexOfRelatedBeforeAfterNumber == -1 || indexOfRelatedBeforeAfterNumber >= i) continue;

                var number = numbers[i];
                numbers[i] = numbers[indexOfRelatedBeforeAfterNumber];
                numbers[indexOfRelatedBeforeAfterNumber] = number;
                i = 0;
            }
        }
    }
}