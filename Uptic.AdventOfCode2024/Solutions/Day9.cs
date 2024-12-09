namespace Uptic.AdventOfCode2024.Solutions;

public class Day9 : IDay
{
    public string PartA(List<string> lines)
    {
        var line = lines.First();
        var idNumber = 0;
        var diskMap = new List<int?>();
        for (var i = 0; i < line.Length; i++)
        {
            var number = int.Parse(line[i].ToString());
            if (i % 2 == 0)
            {
                for (var j = 0; j < number; j++)
                {
                    diskMap.Add(idNumber);
                }

                idNumber++;
            }
            else
            {
                for (var j = 0; j < number; j++)
                {
                    diskMap.Add(null);
                }
            }
        }

        for (var i = diskMap.Count - 1; i >= 0; i--)
        {
            var indexFirstDot = diskMap.IndexOf(null);
            if (indexFirstDot == -1)
            {
                break;
            }

            if (indexFirstDot > i)
            {
                break;
            }

            diskMap[indexFirstDot] = diskMap[i];
            diskMap[i] = null;
        }

        var ans = diskMap.Where(x => x != null).Select((t, i) => (long)i * t ?? 0).Sum();

        return ans.ToString();
    }

    public string PartB(List<string> lines)
    {
        var line = lines.First();
        var idNumber = 0;
        var diskMap = new List<List<int?>>();
        for (var i = 0; i < line.Length; i++)
        {
            var number = int.Parse(line[i].ToString());
            if (i % 2 == 0)
            {
                var list = new List<int?>(number); // Preallocate list capacity
                for (var j = 0; j < number; j++)
                {
                    list.Add(idNumber); 
                }
                
                diskMap.Add(list);
                idNumber++;
            }
            else
            {
                diskMap.Add([..new int?[number]]);
            }
        }
        
        for (var i = diskMap.Count - 1; i >= 0; i--)
        {
            var chunk = diskMap[i];
            if (chunk.Count == 0 || chunk.First() == null)
            {
                continue;
            }

            var chunkSize = chunk.Count;
            // Find a suitable chunk for swapping
            var indexFirstDot = -1;
            for (var j = 0; j < i; j++)
            {
                if (diskMap[j].Count < chunkSize || diskMap[j][0] != null) continue;
                indexFirstDot = j;
                break;
            }
            
            if (indexFirstDot == -1)
            {
                continue;
            }

            var temp = diskMap[indexFirstDot];
            var tempSize = temp.Count;
            diskMap[indexFirstDot] = diskMap[i];
            if (tempSize == chunkSize)
            {
                diskMap[i] = temp;
            }
            else
            {
                diskMap[i] = [..new int?[chunkSize]];
                diskMap.Insert(indexFirstDot + 1, [..new int?[tempSize - chunkSize]]);
            }
        }

        long ans = 0;
        var completeList = diskMap.SelectMany(x => x).ToList();
        for (var i = 0; i < completeList.Count; i++)
        {
            var t = completeList[i];
            ans += i * (t ?? 0);
        }

        return ans.ToString();
    }

    private static void PrintDiskMap(List<int?> diskMap)
    {
        foreach (var t in diskMap)
        {
            Console.Write(t);
        }

        Console.WriteLine();
    }

    private static void PrintDiskMap(List<List<int?>> diskMap)
    {
        foreach (var t in diskMap)
        {
            foreach (var i in t)
            {
                if (i == null)
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write(i);
                }
            }
        }

        Console.WriteLine();
    }
}