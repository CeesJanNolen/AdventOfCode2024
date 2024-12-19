namespace Uptic.AdventOfCode2024.Solutions;

public class Day11 : IDay
{
    public string PartA(List<string> lines)
    {
        var stones = lines.First().Split(" ").Select(long.Parse).ToList();

        // long ans = 0;
        // foreach (var stone in stones)
        // {
        //     ans += CalculateStones(stone, 25);
        // }
        //
        // return ans.ToString();
        for (var i = 0; i < 25; i++)
        {
            for (var i1 = stones.Count - 1; i1 >= 0; i1--)
            {
                var stone = stones[i1];
                if (stone == 0)
                {
                    stones[i1] = 1;
                }
                else if (stone.ToString().Length % 2 == 0)
                {
                    stones[i1] = long.Parse(stone.ToString()[..(stone.ToString().Length / 2)]);
                    stones.Insert(i1 + 1, long.Parse(stone.ToString()[(stone.ToString().Length / 2)..]));
                }
                else
                {
                    stones[i1] *= 2024;
                }
            }
        }

        return stones.Count.ToString();
    }

    public string PartB(List<string> lines)
    {
        var stones = lines.First().Split(" ").Select(long.Parse).ToList();

        long ans = 0;
        foreach (var stone in stones)
        {
            ans += CalculateStones(stone, 75);
        }

        // for (var i = 0; i < 75; i++)
        // {
        //     Console.WriteLine(i);
        //     for (var i1 = stones.Count - 1; i1 >= 0; i1--)
        //     {
        //         var stone = stones[i1];
        //         if (stone == 0)
        //         {
        //             stones[i1] = 1;
        //         }else if (stone.ToString().Length % 2 == 0)
        //         {
        //             stones[i1] = long.Parse(stone.ToString()[..(stone.ToString().Length/2)]);
        //             stones.Insert(i1 + 1, long.Parse(stone.ToString()[(stone.ToString().Length / 2)..]));
        //         }
        //         else
        //         {
        //             stones[i1] *= 2024;
        //         }
        //     }
        // }

        return ans.ToString();
    }

    private static readonly Dictionary<(long, int), long> _stonesDepth = new();

    private static long CalculateStones(long stone, int depth)
    {
        if (_stonesDepth.TryGetValue((stone, depth), out var stoneCount))
        {
            return stoneCount;
        }

        if (depth == 0)
        {
            _stonesDepth.Add((stone, depth), 1);
            return 1;
        }

        if (stone == 0)
        {
            var totalStones = CalculateStones(1, depth - 1);
            _stonesDepth.Add((stone, depth), totalStones);
            return totalStones;
        }

        if (stone.ToString().Length % 2 == 0)
        {
            var firstPart = long.Parse(stone.ToString()[..(stone.ToString().Length / 2)]);
            var firstPartStones = CalculateStones(firstPart, depth - 1);
            var secondPart = long.Parse(stone.ToString()[(stone.ToString().Length / 2)..]);
            var secondPartStones = CalculateStones(secondPart, depth - 1);
            _stonesDepth.Add((stone, depth), firstPartStones + secondPartStones);
            return firstPartStones + secondPartStones;
        }

        {
            var totalStones = CalculateStones(stone * 2024, depth - 1);
            _stonesDepth.Add((stone, depth), totalStones);
            return totalStones;
        }
    }
}