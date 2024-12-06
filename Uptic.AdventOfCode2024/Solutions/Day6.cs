namespace Uptic.AdventOfCode2024.Solutions;

public class Day6 : IDay
{
    public string PartA(List<string> lines)
    {
        var ans = 0;

        var matrix = new char[lines.Count, lines.First().Length];

        var startPosition = (0, 0);
        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                matrix[i, j] = line[j];
                if (line[j].Equals('^'))
                {
                    startPosition = (i, j);
                }
            }
        }

        ans = GuardWalk(matrix, startPosition);


        return ans.ToString();
    }

    private static int GuardWalk(char[,] matrix, (int, int) startPosition)
    {
        var currentPos = startPosition;
        var currentDirection = Direction.N;
        var visitedPositions = new HashSet<(int, int)>();
        visitedPositions.Add(currentPos);
        while (true)
        {
            var nextPos = GetNextPosition(currentPos, currentDirection);
            try
            {
                if (matrix[nextPos.Item1, nextPos.Item2] == '#')
                {
                    currentDirection = (Direction)(((int)currentDirection + 1) % 4);
                    continue;
                }

                currentPos = nextPos;
                visitedPositions.Add(currentPos);
            }
            catch (Exception)
            {
                break;
            }
        }

        // foreach (var visitedPosition in visitedPositions)
        // {
        //     matrix[visitedPosition.Item1, visitedPosition.Item2] = 'X';    
        // }
        // for (var y = 0; y < matrix.GetLength(0); y++)
        // {
        //     for (var i = 0; i < matrix.GetLength(1); i++)
        //     {
        //         Console.Write(matrix[y, i]);
        //     }
        //
        //     Console.WriteLine();
        // }

        return visitedPositions.Count;
    }

    private static (int, int) GetNextPosition((int, int) currentPosition, Direction direction)
    {
        var nextPosition = currentPosition;
        switch (direction)
        {
            case Direction.N:
                nextPosition = (currentPosition.Item1 - 1, currentPosition.Item2);
                break;
            case Direction.E:
                nextPosition = (currentPosition.Item1, currentPosition.Item2 + 1);
                break;
            case Direction.S:
                nextPosition = (currentPosition.Item1 + 1, currentPosition.Item2);
                break;
            case Direction.W:
                nextPosition = (currentPosition.Item1, currentPosition.Item2 - 1);
                break;
        }

        return nextPosition;
    }

    public string PartB(List<string> lines)
    {
        var ans = 0;

        return ans.ToString();
    }

    private enum Direction
    {
        N,
        E,
        S,
        W
    }
}