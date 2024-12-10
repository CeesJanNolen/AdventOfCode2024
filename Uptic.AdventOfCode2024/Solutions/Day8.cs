namespace Uptic.AdventOfCode2024.Solutions;

public class Day8 : IDay
{
    public string PartA(List<string> lines)
    {
        var matrix = new char[lines.Count, lines.First().Length];
        var antennaTypes = new Dictionary<char, List<(int, int)>>();
        for (var i = 0; i < lines.Count; i++)
        {
            for (var j = 0; j < lines.First().Length; j++)
            {
                matrix[i, j] = lines[i][j];
                if (matrix[i, j] == '.')
                    continue;

                antennaTypes.TryAdd(matrix[i, j], []);
                antennaTypes[matrix[i, j]].Add((i, j));
            }
        }

        var antiNodeLocations = new HashSet<(int, int)>();
        foreach (var antennas in antennaTypes)
        {
            for (var i = 0; i < antennas.Value.Count; i++)
            {
                var antennaToCheck = antennas.Value[i];
                for (var i1 = 0; i1 < antennas.Value.Count; i1++)
                {
                    if (i == i1)
                        continue;

                    var antennaToCheck2 = antennas.Value[i1];
                    var xDir = antennaToCheck.Item1 - antennaToCheck2.Item1;
                    var yDir = antennaToCheck.Item2 - antennaToCheck2.Item2;
                    var antiNodeLocation = (antennaToCheck.Item1 + xDir, antennaToCheck.Item2 + yDir);

                    if (antiNodeLocation.Item1 < 0 || antiNodeLocation.Item2 < 0 ||
                        antiNodeLocation.Item1 >= matrix.GetLength(0) || antiNodeLocation.Item2 >= matrix.GetLength(1))
                    {
                        continue;
                    }

                    antiNodeLocations.Add(antiNodeLocation);
                    //if we want debugging mode
                    // matrix[antiNodeLocation.Item1, antiNodeLocation.Item2] = '#';
                }
            }
        }

        return antiNodeLocations.Count.ToString();
    }

    public string PartB(List<string> lines)
    {
        var matrix = new char[lines.Count, lines.First().Length];
        var antennaTypes = new Dictionary<char, List<(int, int)>>();
        for (var i = 0; i < lines.Count; i++)
        {
            for (var j = 0; j < lines.First().Length; j++)
            {
                matrix[i, j] = lines[i][j];
                if (matrix[i, j] == '.')
                    continue;

                antennaTypes.TryAdd(matrix[i, j], []);
                antennaTypes[matrix[i, j]].Add((i, j));
            }
        }

        foreach (var antennas in antennaTypes)
        {
            for (var i = 0; i < antennas.Value.Count; i++)
            {
                var antennaToCheck = antennas.Value[i];
                for (var i1 = 0; i1 < antennas.Value.Count; i1++)
                {
                    if (i == i1)
                        continue;

                    var antennaToCheck2 = antennas.Value[i1];
                    var xDir = antennaToCheck.Item1 - antennaToCheck2.Item1;
                    var yDir = antennaToCheck.Item2 - antennaToCheck2.Item2;

                    var antiNodeLocation = (antennaToCheck.Item1 + xDir, antennaToCheck.Item2 + yDir);
                    if (antiNodeLocation.Item1 < 0 || antiNodeLocation.Item2 < 0 ||
                        antiNodeLocation.Item1 >= matrix.GetLength(0) || antiNodeLocation.Item2 >= matrix.GetLength(1))
                    {
                        continue;
                    }

                  
                    while (antiNodeLocation is { Item1: >= 0, Item2: >= 0 } &&
                           antiNodeLocation.Item1 < matrix.GetLength(0) &&
                           antiNodeLocation.Item2 < matrix.GetLength(1))
                    {
                        matrix[antiNodeLocation.Item1, antiNodeLocation.Item2] = '#';
                        
                        antiNodeLocation = (antiNodeLocation.Item1 + xDir, antiNodeLocation.Item2 + yDir);
                    }

                }
            }
        }

        var ans = 0;
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] != '.')
                {
                    ans++;
                }
            }

        }

        return ans.ToString();
    }
}