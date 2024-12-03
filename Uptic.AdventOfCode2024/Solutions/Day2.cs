namespace Uptic.AdventOfCode2024.Solutions;

public class Day2 : IDay
{
    public string PartA(List<string> lines)
    {
        var ans = 0;

        foreach (var line in lines)
        {
            var parts = line.Split(" ").Select(int.Parse).ToList();

            var correct = IsCorrect(parts);
            if (correct)
            {
                ans++;
            }
        }

        return ans.ToString();
    }

    public string PartB(List<string> lines)
    {
        var ans = 0;

        foreach (var line in lines)
        {
            var parts = line.Split(" ").Select(int.Parse).ToList();

            var correct = IsCorrect(parts);

            if (correct)
            {
                ans++;
                continue;
            }

            var currentIndex = 0;
            while (!correct && currentIndex < parts.Count)
            {
                var newParts = parts.ToList();
                newParts.RemoveAt(currentIndex);

                correct = IsCorrect(newParts);

                currentIndex++;
            }

            if (correct)
            {
                ans++;
            }
        }

        return ans.ToString();
    }

    private static bool IsCorrect(List<int> input)
    {
        var validInc2 = input.Select((x, index) =>
            index == 0 || (x - input[index - 1] <= 3 && x - input[index - 1] > 0));
        if (validInc2.All(x => x))
        {
            return true;
        }

        var validDec2 = input.Select((x, index) =>
            index == 0 || (input[index - 1] - x <= 3 && input[index - 1] - x > 0));
        if (validDec2.All(x => x))
        {
            return true;
        }

        return false;
    }
}