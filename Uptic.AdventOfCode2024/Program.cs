using System.Diagnostics;
using Uptic.AdventOfCode2024;

Console.WriteLine();

var day = DateTime.Now.Day;
var testResults = new Dictionary<int, Tuple<int, int>>()
{
    { 1, new Tuple<int, int>(11, 31) },
    { 2, new Tuple<int, int>(2, 4) },
    { 3, new Tuple<int, int>(161, 48) },
    { 4, new Tuple<int, int>(18, 9) },
    { 5, new Tuple<int, int>(143, 123) },
    { 6, new Tuple<int, int>(41, 123) },
};

var sw = new Stopwatch();
Console.WriteLine($"Day {day}");
sw.Start();
var resultA = Runner.RunA(day, testResults[day].Item1);
if (resultA != null)
{
    Console.WriteLine("A = ");
    Console.WriteLine(resultA);
}
Console.WriteLine($"elapsed: {sw.ElapsedMilliseconds}ms");
sw.Restart();

var resultB = Runner.RunB(day, testResults[day].Item2);
if (resultB != null)
{
    Console.WriteLine("B = ");
    Console.WriteLine(resultB);
}
sw.Stop();
Console.WriteLine($"elapsed: {sw.ElapsedMilliseconds}ms");
