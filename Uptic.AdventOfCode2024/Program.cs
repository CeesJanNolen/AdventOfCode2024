using System.Diagnostics;
using Uptic.AdventOfCode2024;

Console.WriteLine();

var day = DateTime.Now.Day;
const int testAActualResult = 143;
const int testBActualResult = 123;

var sw = new Stopwatch();
Console.WriteLine($"Day {day}");
sw.Start();
var resultA = Runner.RunA(day, testAActualResult);
if (resultA != null)
{
    Console.WriteLine("A = ");
    Console.WriteLine(resultA);
}
Console.WriteLine($"elapsed: {sw.ElapsedMilliseconds}ms");
sw.Restart();

var resultB = Runner.RunB(day, testBActualResult);
if (resultB != null)
{
    Console.WriteLine("B = ");
    Console.WriteLine(resultB);
}
sw.Stop();
Console.WriteLine($"elapsed: {sw.ElapsedMilliseconds}ms");
