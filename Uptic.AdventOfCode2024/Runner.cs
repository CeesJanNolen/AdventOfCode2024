using System.Reflection;
using Uptic.AdventOfCode2024.Solutions;

namespace Uptic.AdventOfCode2024;

public static class Runner
{
    public static string? RunA(int day, int testResult)
    {
        var data = Input.GetInput(day);
        var sampleData = Input.GetSampleAInput(day);

        var assembly = Assembly.GetExecutingAssembly();

        var className = $"Uptic.AdventOfCode2024.Solutions.Day{day}";
        var classType = assembly.GetType(className);
        
        if (classType == null) return null;
        if (Activator.CreateInstance(classType) is not IDay dayRunner) return null;
        var sampleResult = dayRunner.PartA(sampleData);
        if (sampleResult.Equals(testResult.ToString()))
        {
            return dayRunner.PartA(data);
        }

        Console.WriteLine("Test A failed!");
        Console.WriteLine($"Result was: {sampleResult}");
        Console.WriteLine($"Should have been: {testResult}");

        return null;
    }

    public static string? RunB(int day, int testResult)
    {
        var data = Input.GetInput(day);
        var sampleData = Input.GetSampleBInput(day);

        var assembly = Assembly.GetExecutingAssembly();

        var className = $"Uptic.AdventOfCode2024.Solutions.Day{day}";
        var classType = assembly.GetType(className);
        
        if (classType == null) return null;
        if (Activator.CreateInstance(classType) is not IDay dayRunner) return null;
        var sampleResult = dayRunner.PartB(sampleData);
        if (sampleResult.Equals(testResult.ToString()))
        {
            return dayRunner.PartB(data);
        }

        Console.WriteLine("Test B failed!");
        Console.WriteLine($"Result was: {sampleResult}");
        Console.WriteLine($"Should have been: {testResult}");

        return null;
    }
}