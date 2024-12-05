namespace Uptic.AdventOfCode2024.Solutions;

public class Day4 : IDay
{
    public string PartA(List<string> lines)
    {
        var ans = 0;

        var matrix = new string[lines.Count, lines.First().Length];

        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                matrix[i, j] = line[j].ToString();
            }
        }

        for (var y = 0; y < matrix.GetLength(0); y++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[y, j] == "X")
                {
                    ans += IsXMasWord(matrix, y, j);
                }
            }
        }

        return ans.ToString();
    }

    private static int IsXMasWord(string[,] matrix, int y, int x)
    {
        return Enum.GetValues<Direction>().Sum(direction => VisitXmasWord(matrix, y, x, direction) ? 1 : 0);
    }

    private static bool VisitXmasWord(string[,] matrix, int y, int x, Direction direction)
    {
        int mXIndex;
        int mYIndex;
        int aXIndex;
        int aYIndex;
        int sXIndex;
        int sYIndex;
        switch (direction)
        {
            case Direction.N:
                mYIndex = y - 1;
                aYIndex = y - 2;
                sYIndex = y - 3;
                mXIndex = sXIndex = aXIndex = x;
                break;
            case Direction.W:
                mXIndex = x - 1;
                aXIndex = x - 2;
                sXIndex = x - 3;
                mYIndex = sYIndex = aYIndex = y;

                break;
            case Direction.E:
                mXIndex = x + 1;
                aXIndex = x + 2;
                sXIndex = x + 3;
                mYIndex = sYIndex = aYIndex = y;
                break;
            case Direction.S:
                mYIndex = y + 1;
                aYIndex = y + 2;
                sYIndex = y + 3;
                mXIndex = sXIndex = aXIndex = x;

                break;
            case Direction.NW:
                mYIndex = y - 1;
                mXIndex = x - 1;
                aYIndex = y - 2;
                aXIndex = x - 2;
                sYIndex = y - 3;
                sXIndex = x - 3;
                break;
            case Direction.NE:
                mYIndex = y - 1;
                mXIndex = x + 1;
                aYIndex = y - 2;
                aXIndex = x + 2;
                sYIndex = y - 3;
                sXIndex = x + 3;
                break;

            case Direction.SW:
                mYIndex = y + 1;
                mXIndex = x - 1;
                aYIndex = y + 2;
                aXIndex = x - 2;
                sYIndex = y + 3;
                sXIndex = x - 3;
                break;
            case Direction.SE:
                mYIndex = y + 1;
                mXIndex = x + 1;
                aYIndex = y + 2;
                aXIndex = x + 2;
                sYIndex = y + 3;
                sXIndex = x + 3;
                break;
            default:
                return false;
        }

        try
        {
            return matrix[mYIndex, mXIndex] == "M" && matrix[aYIndex, aXIndex] == "A" &&
                   matrix[sYIndex, sXIndex] == "S";
        }
        catch (Exception)
        {
            return false;
        }
    }

    public string PartB(List<string> lines)
    {
        var ans = 0;

        var matrix = new string[lines.Count, lines.First().Length];

        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                matrix[i, j] = line[j].ToString();
            }
        }

        for (var y = 0; y < matrix.GetLength(0); y++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[y, j] == "A")
                {
                    ans += IsXMas(matrix, y, j) ? 1 : 0;
                }
            }
        }

        return ans.ToString();
    }

    private static bool IsXMas(string[,] matrix, int y, int x)
    {
        try
        {
            var mYIndex = y - 1;
            var mXIndex = x - 1;
            bool topLeftM;
            switch (matrix[mYIndex, mXIndex])
            {
                case "M":
                    topLeftM = true;
                    break;
                case "S":
                    topLeftM = false;
                    break;
                default:
                    return false;
            }


            mYIndex = y - 1;
            mXIndex = x + 1;
            bool topRightM;
            switch (matrix[mYIndex, mXIndex])
            {
                case "M":
                    topRightM = true;
                    break;
                case "S":
                    topRightM = false;
                    break;
                default:
                    return false;
            }

            mYIndex = y + 1;
            mXIndex = x - 1;
            switch (topRightM)
            {
                case true when matrix[mYIndex, mXIndex] != "S":
                case false when matrix[mYIndex, mXIndex] != "M":
                    return false;
            }

            mYIndex = y + 1;
            mXIndex = x + 1;
            switch (topLeftM)
            {
                case true when matrix[mYIndex, mXIndex] != "S":
                case false when matrix[mYIndex, mXIndex] != "M":
                    return false;
                default:
                    return true;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }

    private enum Direction
    {
        NW,
        N,
        NE,
        W,
        E,
        SW,
        S,
        SE
    }
}