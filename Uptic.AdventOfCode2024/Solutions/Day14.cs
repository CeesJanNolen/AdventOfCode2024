using System.Text.RegularExpressions;

namespace Uptic.AdventOfCode2024.Solutions;

public partial class Day14 : IDay
{
    public string PartA(List<string> lines)
    {
        int ans;

        var xMax = 101;
        var yMax = 103;

        var topLeftCount = 0;
        var topRightCount = 0;
        var bottomLeftCount = 0;
        var bottomRightCount = 0;

        foreach (var line in lines)
        {
            var resultString = Digits().Matches(line).Select(x => int.Parse(x.Value)).ToList();
            var px = resultString[0];
            var py = resultString[1];
            var vx = resultString[2];
            var vy = resultString[3];

            var times = 100;

            px += vx * times;
            py += vy * times;


            while (px >= xMax)
            {
                px -= xMax;
            }

            while (px < 0)
            {
                px += xMax;
            }

            while (py >= yMax)
            {
                py -= yMax;
            }

            while (py < 0)
            {
                py += yMax;
            }

            var centerX = xMax / 2;
            var centerY = yMax / 2;

            if (px < centerX)
            {
                if (py < centerY)
                    topLeftCount++;
                else if (py > centerY)
                    topRightCount++;
            }
            else if (px > centerX)
            {
                if (py < centerY)
                    bottomLeftCount++;
                else if (py > centerY)
                    bottomRightCount++;
            }
        }

        ans = bottomRightCount * bottomLeftCount * topRightCount * topLeftCount;

        return ans.ToString();
    }

    public string PartB(List<string> lines)
    {
        const int xMax = 101;
        const int yMax = 103;

        var robots = new List<(int px, int py, int vx, int vy)>();
        foreach (var line in lines)
        {
            var resultString = Digits().Matches(line).Select(x => int.Parse(x.Value)).ToList();
            robots.Add((resultString[0], resultString[1], resultString[2], resultString[3]));
        }

        for (var i = 0; i < xMax * yMax; i++)
        {
            var finalPositions = new HashSet<(int, int)>();

            var robotCount = 0;
            var valid = true;

            while (robotCount < robots.Count && valid)
            {
                var valueTuple = robots[robotCount];
                var px = valueTuple.px;
                var py = valueTuple.py;
                var vx = valueTuple.vx;
                var vy = valueTuple.vy;

                px += vx * i;
                py += vy * i;

                while (px >= xMax)
                {
                    px -= xMax;
                }

                while (px < 0)
                {
                    px += xMax;
                }

                while (py >= yMax)
                {
                    py -= yMax;
                }

                while (py < 0)
                {
                    py += yMax;
                }

                if (!finalPositions.Add((px, py)))
                    valid = false;

                robotCount++;
            }

            if (!valid)
                continue;

            return i.ToString();
            //check if we get max spread. This worked somehow. not sure why, but hey happy :)
            // it makes sense to have max spread as it's the most obvious option to make a tree or other figure
            //max spread try. if this returns, then we got a match!?
        }

        return 0.ToString();
    }

    [GeneratedRegex(@"-?\d+")]
    private static partial Regex Digits();
}