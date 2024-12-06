﻿namespace Uptic.AdventOfCode2024.Solutions;

public class Day6 : IDay
{
    public string PartA(List<string> lines)
    {
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

        return GuardWalkPath(matrix, startPosition).Count.ToString();
    }

    private static HashSet<(int, int)> GuardWalkPath(char[,] matrix, (int, int) startPosition)
    {
        var currentPos = startPosition;
        var currentDirection = Direction.N;
        var visitedPositions = new HashSet<(int, int)> { (currentPos) };
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

        return visitedPositions;
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

        var firstPath = GuardWalkPath(matrix, startPosition).Distinct().ToList();
        
        foreach (var valueTuple in firstPath)
        {
            var oldChar = matrix[valueTuple.Item1, valueTuple.Item2];
            matrix[valueTuple.Item1, valueTuple.Item2] = '0';
            ans += TryInfiniteLoop(matrix, startPosition) ? 1 : 0;
            matrix[valueTuple.Item1, valueTuple.Item2] = oldChar;
        }

        return ans.ToString();
    }
    
    private static bool TryInfiniteLoop(char[,] matrix, (int, int) startPosition)
    {
        var currentPos = startPosition;
        var currentDirection = Direction.N;
        var visitedPositions = new HashSet<((int, int), Direction)> { (currentPos, currentDirection) };
        while (true)
        {
            var nextPos = GetNextPosition(currentPos, currentDirection);
            try
            {
                if (matrix[nextPos.Item1, nextPos.Item2] == '#' || matrix[nextPos.Item1, nextPos.Item2] == '0')
                {
                    currentDirection = (Direction)(((int)currentDirection + 1) % 4);
                    continue;
                }

                currentPos = nextPos;
                var canAdd = visitedPositions.Add((currentPos, currentDirection));
                if (!canAdd)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                break;
            }
        }

        return false;
    }

    private enum Direction
    {
        N,
        E,
        S,
        W
    }
}