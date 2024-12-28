namespace Uptic.AdventOfCode2024.Solutions;

public class Day12 : IDay
{
    public string PartA(List<string> lines)
    {
        var matrix = new char[lines.Count, lines.First().Length];

        for (var r = 0; r < lines.Count; r++)
        {
            for (var c = 0; c < lines.First().Length; c++)
            {
                matrix[r, c] = lines[r][c];
            }
        }

        var results = new List<(char, HashSet<(int, int)>)>();
        var visitedPoints = new HashSet<(int, int)>();
        for (var rIndex = 0; rIndex < matrix.GetLength(0); rIndex++)
        {
            for (var cIndex = 0; cIndex < matrix.GetLength(1); cIndex++)
            {
                var currentChar = matrix[rIndex, cIndex];

                if (visitedPoints.Contains((rIndex, cIndex)))
                {
                    continue;
                }

                var set = new HashSet<(int, int)>();
                FindRelated(matrix, rIndex, cIndex, visitedPoints, currentChar, set);
                results.Add((currentChar, set));
            }
        }

        var ans = results.Sum(i => GetEdges(i.Item2) * i.Item2.Count);

        return ans.ToString();
    }

    private void FindRelated(char[,] matrix, int r, int c, HashSet<(int, int)> visitedPoints, char checkingChar,
        HashSet<(int, int)> setItems)
    {
        if (r < 0 || c < 0 || r >= matrix.GetLength(0) || c >= matrix.GetLength(1))
            return;

        if (matrix[r, c] != checkingChar)
            return;

        if (!visitedPoints.Add((r, c)))
            return;

        setItems.Add((r, c));

        FindRelated(matrix, r - 1, c, visitedPoints, checkingChar, setItems);
        FindRelated(matrix, r + 1, c, visitedPoints, checkingChar, setItems);
        FindRelated(matrix, r, c - 1, visitedPoints, checkingChar, setItems);
        FindRelated(matrix, r, c + 1, visitedPoints, checkingChar, setItems);
    }

    private void FindRelated(char[,] matrix, int r, int c, HashSet<(int, int)> visitedPoints, char checkingChar,
        List<(int, int)> setItems)
    {
        if (r < 0 || c < 0 || r >= matrix.GetLength(0) || c >= matrix.GetLength(1))
            return;

        if (matrix[r, c] != checkingChar)
            return;

        if (!visitedPoints.Add((r, c)))
            return;

        setItems.Add((r, c));

        FindRelated(matrix, r, c - 1, visitedPoints, checkingChar, setItems);
        FindRelated(matrix, r, c + 1, visitedPoints, checkingChar, setItems);
        FindRelated(matrix, r - 1, c, visitedPoints, checkingChar, setItems);
        FindRelated(matrix, r + 1, c, visitedPoints, checkingChar, setItems);
    }

    private static int GetEdges(HashSet<(int, int)> points)
    {
        var sides = 0;

        foreach (var point in points)
        {
            var r = point.Item1;
            var c = point.Item2;

            if (!points.Contains((r - 1, c)))
                sides++;
            if (!points.Contains((r + 1, c)))
                sides++;
            if (!points.Contains((r, c - 1)))
                sides++;
            if (!points.Contains((r, c + 1)))
                sides++;
        }

        return sides;
    }


    public string PartB(List<string> lines)
    {
        var matrix = new char[lines.Count, lines.First().Length];

        for (var r = 0; r < lines.Count; r++)
        {
            for (var c = 0; c < lines.First().Length; c++)
            {
                matrix[r, c] = lines[r][c];
            }
        }

        var results = new List<(char, List<(int, int)>)>();
        var visitedPoints = new HashSet<(int, int)>();
        for (var rIndex = 0; rIndex < matrix.GetLength(0); rIndex++)
        {
            for (var cIndex = 0; cIndex < matrix.GetLength(1); cIndex++)
            {
                var currentChar = matrix[rIndex, cIndex];

                if (visitedPoints.Contains((rIndex, cIndex)))
                {
                    continue;
                }

                var set = new List<(int, int)>();
                FindRelated(matrix, rIndex, cIndex, visitedPoints, currentChar, set);
                results.Add((currentChar, set));
            }
        }

        Console.WriteLine("----");
        foreach (var valueTuple in results)
        {
            var sides = GetSides(valueTuple.Item2, matrix.GetLength(1), matrix.GetLength(0));
            Console.WriteLine(
                $"{valueTuple.Item1} - {sides} - {valueTuple.Item2.Count} - {sides * valueTuple.Item2.Count}");
            Console.WriteLine();
        }

        Console.WriteLine("----");

        var ans = results.Sum((x) => GetSides(x.Item2, matrix.GetLength(1), matrix.GetLength(0)) * x.Item2.Count);

        return ans.ToString();
    }


    private static int GetSides(List<(int, int)> points, int maxC, int maxR)
    {
        var visitedTop = new List<(int, int)>();
        var allVisitedTop = new List<(int, int)>();
        var visitedRight = new List<(int, int)>();
        var allVisitedRight = new List<(int, int)>();
        var visitedBottom = new List<(int, int)>();
        var allVisitedBottom = new List<(int, int)>();
        var visitedLeft = new List<(int, int)>();
        var allVisitedLeft = new List<(int, int)>();

        foreach (var point in points)
        {
            var r = point.Item1;
            var c = point.Item2;

            Console.WriteLine($"Checking {r}, {c}");
            if (!points.Contains((r - 1, c)))
            {
                Console.WriteLine($"TOP: Adding {r}, {c} because {r - 1}, {c} is not in points");
                if (InBounds(r, c - 1, maxR, maxC) && InBounds(r, c + 1, maxR, maxC))
                {
                    if (!allVisitedTop.Contains((r, c - 1)) && !allVisitedTop.Contains((r, c + 1)))
                    {
                        Console.WriteLine(
                            $"TOP: Adding {r}, {c} because {r - 1}, {c} is not in points and {r}, {c - 1} and {r}, {c + 1} are not visited");
                        visitedTop.Add((r, c));
                    }
                }
                else if (InBounds(r, c - 1, maxR, maxC))
                {
                    if (!allVisitedTop.Contains((r, c - 1)))
                    {
                        Console.WriteLine(
                            $"TOP: Adding {r}, {c} because {r - 1}, {c} is not in points and {r}, {c - 1} is not visited");
                        visitedTop.Add((r, c));
                    }
                }
                else if (InBounds(r, c + 1, maxR, maxC))
                {
                    if (!allVisitedTop.Contains((r, c + 1)))
                    {
                        Console.WriteLine(
                            $"TOP: Adding {r}, {c} because {r - 1}, {c} is not in points and {r}, {c + 1} is not visited");
                        visitedTop.Add((r, c));
                    }
                }


                allVisitedTop.Add((r, c));
            }

            if (!points.Contains((r + 1, c)))
            {
                Console.WriteLine($"BOTTOM: Adding {r}, {c} because {r + 1}, {c} is not in points");
                if (InBounds(r, c + 1, maxR, maxC) && InBounds(r, c - 1, maxR, maxC))
                {
                    if (!allVisitedBottom.Contains((r, c + 1)) &&
                        !allVisitedBottom.Contains((r, c - 1)))
                    {
                        Console.WriteLine(
                            $"BOTTOM: Adding {r}, {c} because {r + 1}, {c} is not in points and {r}, {c + 1} and {r}, {c - 1} are not visited");
                        visitedBottom.Add((r, c));
                    }
                }
                else if (InBounds(r, c + 1, maxR, maxC))
                {
                    if (!allVisitedBottom.Contains((r, c + 1)))
                    {
                        Console.WriteLine(
                            $"BOTTOM: Adding {r}, {c} because {r + 1}, {c} is not in points and {r}, {c + 1} is not visited");
                        visitedBottom.Add((r, c));
                    }
                }
                else if (InBounds(r, c - 1, maxR, maxC))
                {
                    if (!allVisitedBottom.Contains((r, c - 1)))
                    {
                        Console.WriteLine(
                            $"BOTTOM: Adding {r}, {c} because {r + 1}, {c} is not in points and {r}, {c - 1} is not visited");
                        visitedBottom.Add((r, c));
                    }
                }

                allVisitedBottom.Add((r, c));
            }

            if (!points.Contains((r, c - 1)))
            {
                Console.WriteLine($"LEFT: Adding {r}, {c} because {r}, {c - 1} is not in points");
                if (InBounds(r + 1, c, maxR, maxC) && InBounds(r - 1, c, maxR, maxC))
                {
                    if (!allVisitedLeft.Contains((r + 1, c)) &&
                        !allVisitedLeft.Contains((r - 1, c)))
                    {
                        Console.WriteLine(
                            $"LEFT: Adding {r}, {c} because {r}, {c - 1} is not in points and {r + 1}, {c} and {r - 1}, {c} are not visited");
                        visitedLeft.Add((r, c - 1));
                    }
                }
                else if (InBounds(r + 1, c, maxR, maxC))
                {
                    if (!allVisitedLeft.Contains((r + 1, c)))
                    {
                        Console.WriteLine(
                            $"LEFT: Adding {r}, {c} because {r}, {c - 1} is not in points and {r + 1}, {c} is not visited");
                        visitedLeft.Add((r, c));
                    }
                }
                else if (InBounds(r - 1, c, maxR, maxC))
                {
                    if (!allVisitedLeft.Contains((r - 1, c)))
                    {
                        Console.WriteLine(
                            $"LEFT: Adding {r}, {c} because {r}, {c - 1} is not in points and {r - 1}, {c} is not visited");
                        visitedLeft.Add((r, c));
                    }
                }


                allVisitedLeft.Add((r, c));
            }

            if (!points.Contains((r, c + 1)))
            {
                Console.WriteLine($"RIGHT: Adding {r}, {c} because {r}, {c + 1} is not in points");
                if (InBounds(r - 1, c, maxR, maxC) && InBounds(r + 1, c, maxR, maxC))
                {
                    if (!allVisitedRight.Contains((r - 1, c)) &&
                        !allVisitedRight.Contains((r + 1, c)))
                    {
                        Console.WriteLine(
                            $"RIGHT: Adding {r}, {c} because {r}, {c + 1} is not in points and {r - 1}, {c} and {r + 1}, {c} are not visited");
                        visitedRight.Add((r, c));
                    }
                }
                else if (InBounds(r - 1, c, maxR, maxC))
                {
                    if (!allVisitedRight.Contains((r - 1, c)))
                    {
                        Console.WriteLine(
                            $"RIGHT: Adding {r}, {c} because {r}, {c + 1} is not in points and {r - 1}, {c} is not visited");
                        visitedRight.Add((r, c));
                    }
                }
                else if (InBounds(r + 1, c, maxR, maxC))
                {
                    if (!allVisitedRight.Contains((r + 1, c)))
                    {
                        Console.WriteLine(
                            $"RIGHT: Adding {r}, {c} because {r}, {c + 1} is not in points and {r + 1}, {c} is not visited");
                        visitedRight.Add((r, c));
                    }
                }


                allVisitedRight.Add((r, c));
            }
        }

        Console.WriteLine($"Top: {visitedTop.Count}");
        Console.WriteLine($"Right: {visitedRight.Count}");
        Console.WriteLine($"Bottom: {visitedBottom.Count}");
        Console.WriteLine($"Left: {visitedLeft.Count}");

        return visitedTop.Count + visitedRight.Count + visitedBottom.Count + visitedLeft.Count;
    }

    private static bool InBounds(int r, int c, int maxR, int maxC)
    {
        return r >= 0 && c >= 0 && r < maxR && c < maxC;
    }
}