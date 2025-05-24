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

        var ans = results.Sum((x) => GetCorners(x.Item2) * x.Item2.Count);

        return ans.ToString();
    }

    private static int GetCorners(List<(int, int)> points)
    {
        var cornerCandidates = new HashSet<(double, double)>();
        foreach (var (r, c) in points)
        {
            cornerCandidates.Add((r - 0.5, c - 0.5));
            cornerCandidates.Add((r + 0.5, c - 0.5));
            cornerCandidates.Add((r + 0.5, c + 0.5));
            cornerCandidates.Add((r - 0.5, c + 0.5));
        }

        var cornerCount = 0;
        foreach (var (cr, cc) in cornerCandidates)
        {
            var foundPoints = new HashSet<(int, int)>();
            var topLeft = ((int)(cr - 0.5), (int)(cc - 0.5));
            if (points.Contains(topLeft))
                foundPoints.Add(topLeft);

            var bottomLeft = ((int)(cr + 0.5), (int)(cc - 0.5));
            if (points.Contains(bottomLeft))
                foundPoints.Add(bottomLeft);

            var bottomRight = ((int)(cr + 0.5), (int)(cc + 0.5));
            if (points.Contains(bottomRight))
                foundPoints.Add(bottomRight);

            var topRight = ((int)(cr - 0.5), (int)(cc + 0.5));
            if (points.Contains(topRight))
                foundPoints.Add(topRight);

            switch (foundPoints.Count)
            {
                case 1:
                case 3:
                    cornerCount += 1;
                    break;
                case 2:
                {
                    if (foundPoints.Contains(topLeft) && foundPoints.Contains(bottomRight))
                        cornerCount += 2;

                    if (foundPoints.Contains(topRight) && foundPoints.Contains(bottomLeft))
                        cornerCount += 2;

                    break;
                }
            }
        }

        return cornerCount;
    }
}