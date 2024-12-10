namespace Uptic.AdventOfCode2024.Solutions;

public class Day10 : IDay
{
    public string PartA(List<string> lines)
    {
        var ans = 0;

        var matrix = new int[lines.Count, lines.First().Length];

        var starterPoints = new List<(int, int)>();
        for (var i = 0; i < lines.Count; i++)
        {
            for (var j = 0; j < lines.First().Length; j++)
            {
                matrix[i, j] = int.Parse(lines[i][j].ToString());
                if (lines[i][j] == '0')
                {
                    starterPoints.Add((i, j));
                }
            }
        }

        foreach (var starterPoint in starterPoints)
        {
            var endPoints = new HashSet<(int, int)>();
            VisitPoint(starterPoint, matrix, endPoints);
            
            ans += endPoints.Count;
        }

        return ans.ToString();
    }

    private static void VisitPoint((int, int) point, int[,] matrix, HashSet<(int, int)> endPoints)
    {
        var cur = matrix[point.Item1, point.Item2];
        if (cur == 9)
        {
            endPoints.Add(point);
            return;
        }

        var x = point.Item1;
        var y = point.Item2;

        // Console.WriteLine($"Visiting {x}, {y} with cur {cur}");

        if (x - 1 >= 0 && matrix[x - 1, y] == cur + 1)
        {
            VisitPoint((x - 1, y), matrix, endPoints);
        }

        if (y - 1 >= 0 && matrix[x, y - 1] == cur + 1)
        {
            VisitPoint( (x, y - 1), matrix, endPoints);
        }

        if (x + 1 < matrix.GetLength(0) && matrix[x + 1, y] == cur + 1)
        {
            VisitPoint((x + 1, y), matrix, endPoints);
        }

        if (y + 1 < matrix.GetLength(1) && matrix[x, y + 1] == cur + 1)
        {
            VisitPoint((x, y + 1), matrix, endPoints);
        }
    }

    public string PartB(List<string> lines)
    {
        var ans = 0;

        var matrix = new int[lines.Count, lines.First().Length];

        var starterPoints = new List<(int, int)>();
        for (var i = 0; i < lines.Count; i++)
        {
            for (var j = 0; j < lines.First().Length; j++)
            {
                matrix[i, j] = int.Parse(lines[i][j].ToString());
                if (lines[i][j] == '0')
                {
                    starterPoints.Add((i, j));
                }
            }
        }

        foreach (var starterPoint in starterPoints)
        {
            var endPoints = new List<(int, int)>();
            VisitPoint(starterPoint, matrix, endPoints);

            ans += endPoints.Count;
        }

        return ans.ToString();
    }
    
    private static void VisitPoint((int, int) point, int[,] matrix, List<(int, int)> endPoints)
    {
        var cur = matrix[point.Item1, point.Item2];
        if (cur == 9)
        {
            endPoints.Add(point);
            return;
        }

        var x = point.Item1;
        var y = point.Item2;

        // Console.WriteLine($"Visiting {x}, {y} with cur {cur}");

        if (x - 1 >= 0 && matrix[x - 1, y] == cur + 1)
        {
            VisitPoint((x - 1, y), matrix, endPoints);
        }

        if (y - 1 >= 0 && matrix[x, y - 1] == cur + 1)
        {
            VisitPoint( (x, y - 1), matrix, endPoints);
        }

        if (x + 1 < matrix.GetLength(0) && matrix[x + 1, y] == cur + 1)
        {
            VisitPoint((x + 1, y), matrix, endPoints);
        }

        if (y + 1 < matrix.GetLength(1) && matrix[x, y + 1] == cur + 1)
        {
            VisitPoint((x, y + 1), matrix, endPoints);
        }
    }
}