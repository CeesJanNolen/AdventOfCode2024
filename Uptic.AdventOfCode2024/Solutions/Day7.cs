namespace Uptic.AdventOfCode2024.Solutions;

public class Day7 : IDay
{
    public string PartA(List<string> lines)
    {
        long ans = 0;

        foreach (var line in lines)
        {
            var total = long.Parse(line.Split(":")[0]);
            var numbers = line.Split(":", StringSplitOptions.TrimEntries)[1].Split(" ").Select(long.Parse).ToList();

            var possibleOperators = GetOperators(numbers.Count);
            foreach (var possibleOperator in possibleOperators)
            {
                var posT = numbers[0];
                for (var i = 0; i < possibleOperator.Count; i++)
                {
                    var op = possibleOperator[i];
                    switch (op)
                    {
                        case Operator.Add:
                            posT += numbers[i + 1];
                            break;
                        case Operator.Multiply:
                            posT *= numbers[i + 1];
                            break;
                    }
                }

                if (posT != total) continue;
                ans += total;
                break;
            }
        }

        return ans.ToString();
    }

    private static List<List<Operator>> GetOperators(int length, int baseNumber  =2 )
    {
        if (length <= 1)
            return [];

        var res = new List<List<Operator>>();

        length--;
        var max = Math.Pow(baseNumber, length);
        for (var i = 0; i < max; i++)
        {
            var numb = i;

            List<Operator> operators = [];
            for (int j = length - 1; j >= 0; j--)
            {
                var toAdd = numb % baseNumber;
                numb /= baseNumber;
                operators.Add((Operator)toAdd);                
            }
            
            res.Add(operators);
        }

        return res;
    }

    public string PartB(List<string> lines)
    {
        long ans = 0;
        
        foreach (var line in lines)
        {
            var total = long.Parse(line.Split(":")[0]);
            var numbers = line.Split(":", StringSplitOptions.TrimEntries)[1].Split(" ").Select(long.Parse).ToList();

            var possibleOperators = GetOperators(numbers.Count, 3);
            foreach (var possibleOperator in possibleOperators)
            {
                var posT = numbers[0];
                for (var i = 0; i < possibleOperator.Count; i++)
                {
                    var op = possibleOperator[i];
                    switch (op)
                    {
                        case Operator.Add:
                            posT += numbers[i + 1];
                            break;
                        case Operator.Multiply:
                            posT *= numbers[i + 1];
                            break;
                        case Operator.Combine:
                            var cur = posT + numbers[i + 1].ToString();
                            posT = long.Parse(cur);
                            break;
                    }

                }

                if (posT != total) continue;
                ans += total;
                break;
            }

        }
        return ans.ToString();
    }

    private enum Operator
    {
        Add = 0,
        Multiply = 1,
        Combine = 2,
    }
}