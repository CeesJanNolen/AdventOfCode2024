namespace Uptic.AdventOfCode2024.Solutions;

public class Day13 : IDay
{
    public string PartA(List<string> lines)
    {
        long ans = 0;

        for (var l = 0; l < lines.Count; l += 4)
        {
            var buttonAString = lines[l];
            var aParts = buttonAString.Split(", Y+");
            var ax = long.Parse(aParts.First().Split("X+").Last());
            var ay = long.Parse(aParts.Last());

            var buttonBString = lines[l + 1];
            var bParts = buttonBString.Split(", Y+");
            var bx = long.Parse(bParts.First().Split("X+").Last());
            var by = long.Parse(bParts.Last());

            var resultString = lines[l + 2];
            var resultParts = resultString.Split(", Y=");
            var px = long.Parse(resultParts.First().Split("X=").Last());
            var py = long.Parse(resultParts.Last());

            var options = int.MaxValue;
            for (var i = 0; i <= 100; i++)
            {
                for (var j = 0; j <= 100; j++)
                {
                    if (px == i * ax + j * bx &&
                        py == i * ay + j * by)
                        options = Math.Min(i * 3 + j * 1, options);
                }
            }

            ans += options != int.MaxValue ? options : 0;
        }

        return ans.ToString();
    }

    public string PartB(List<string> lines)
    {
        long ans = 0;

        for (var l = 0; l < lines.Count; l += 4)
        {
            var buttonAString = lines[l];
            var aParts = buttonAString.Split(", Y+");
            var ax = double.Parse(aParts.First().Split("X+").Last());
            var ay = double.Parse(aParts.Last());

            var buttonBString = lines[l + 1];
            var bParts = buttonBString.Split(", Y+");
            var bx = double.Parse(bParts.First().Split("X+").Last());
            var by = double.Parse(bParts.Last());

            var resultString = lines[l + 2];
            var resultParts = resultString.Split(", Y=");
            var px = double.Parse(resultParts.First().Split("X=").Last());
            var py = double.Parse(resultParts.Last());

            px += 10000000000000;
            py += 10000000000000;
            var aPresses = (px * by - py * bx) / (ax * by - ay * bx);
            var bPresses = (px - ax * aPresses) / bx;

            if (aPresses < 0 || bPresses < 0)
                continue;

            if (aPresses % 1 == 0 && bPresses % 1 == 0)
            {
                ans += (long)aPresses * 3 + (long)bPresses * 1;
            }
        }


        return ans.ToString();
    }
}