namespace Uptic.AdventOfCode2024.Solutions;

public class Day11 : IDay
{
    public string PartA(List<string> lines)
    {
        var stones = lines.First().Split(" ").Select(long.Parse).ToList();

        for (var i = 0; i < 25; i++)
        {
            Console.WriteLine(i);
            for (var i1 = stones.Count - 1; i1 >= 0; i1--)
            {
                var stone = stones[i1];
                if (stone == 0)
                {
                    stones[i1] = 1;
                }else if (stone.ToString().Length % 2 == 0)
                {
                    stones[i1] = long.Parse(stone.ToString()[..(stone.ToString().Length/2)]);
                    stones.Insert(i1 + 1, long.Parse(stone.ToString()[(stone.ToString().Length / 2)..]));
                }
                else
                {
                    stones[i1] *= 2024;
                }
            }
        }

        Console.WriteLine(stones);

        return stones.Count.ToString();
    }

    public string PartB(List<string> lines)
    {
        var stones = lines.First().Split(" ").Select(long.Parse).ToList();

        for (var i = 0; i < 75; i++)
        {
            Console.WriteLine(i);
            for (var i1 = stones.Count - 1; i1 >= 0; i1--)
            {
                var stone = stones[i1];
                if (stone == 0)
                {
                    stones[i1] = 1;
                }else if (stone.ToString().Length % 2 == 0)
                {
                    stones[i1] = long.Parse(stone.ToString()[..(stone.ToString().Length/2)]);
                    stones.Insert(i1 + 1, long.Parse(stone.ToString()[(stone.ToString().Length / 2)..]));
                }
                else
                {
                    stones[i1] *= 2024;
                }
            }
        }

        Console.WriteLine(stones);

        return stones.Count.ToString();
        
        return 81.ToString();
    }
}