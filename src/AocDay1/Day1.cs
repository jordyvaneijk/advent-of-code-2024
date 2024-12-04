using Common;
using Spectre.Console;

namespace AocDay1;

public class Day1 : IDay<string>
{
    List<string> _lines = new();
    
    public void Run()
    {
        
        ParseInput();
        AnsiConsole.Console.Clear();
        AnsiConsole.Write(new FigletText("Day 1").Centered().Color(Color.Green));
        SolvePartOne();
        Console.WriteLine();
        SolvePartTwo();
        Console.WriteLine();
        AnsiConsole.MarkupLine("[bold green]Press [red]Enter[/] to continue...[/]");
        Console.ReadLine();
    }
    
    public void ParseInput()
    {
        var lines = File.ReadAllLines("Input/input_day1.txt");
        _lines = lines.ToList();
    }

    public void SolvePartOne()
    {
        var leftNumbers = new List<int>();
        var rightNumbers = new List<int>();

        foreach (var line in _lines)
        {
            var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int left = int.Parse(parts[0]);
            int right = int.Parse(parts[1]);

            leftNumbers.Add(left);
            rightNumbers.Add(right);
        }

        leftNumbers = leftNumbers.Order().ToList();
        rightNumbers = rightNumbers.Order().ToList();
        var totalDistance = FindDistance(leftNumbers, rightNumbers);

        AnsiConsole.MarkupLine("[bold green]Outcome for Day 1 part 1[/]");
        AnsiConsole.MarkupLine($"[bold green]Total distance: {totalDistance}[/]");
    }

    public void SolvePartTwo()
    {
        var leftNumbers = new List<int>();
        var rightNumbers = new List<int>();

        foreach (var line in _lines)
        {
            var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int left = int.Parse(parts[0]);
            int right = int.Parse(parts[1]);

            leftNumbers.Add(left);
            rightNumbers.Add(right);
        }

        leftNumbers = leftNumbers.Order().ToList();
        rightNumbers = rightNumbers.Order().ToList();
        var totalSimilarity = FindSimilarity(leftNumbers, rightNumbers);
        
        AnsiConsole.MarkupLine("[bold green]Outcome for Day 1 part 2[/]");
        AnsiConsole.MarkupLine($"[bold green]Total similarity: {totalSimilarity}[/]");
    }
    
    private static int FindDistance(List<int> leftNumbers, List<int> rightNumbers)
    {
        int totalDistance = 0;
        for (int i = 0; i < leftNumbers.Count; i++)
        {
            int left = leftNumbers[i];
            int right = rightNumbers[i];
            int distance;

            if (left > right)
            {
                distance = left - right;
            }
            else
            {
                distance = right - left;
            }

            totalDistance += distance;
        }

        return totalDistance;
    }

    private static long FindSimilarity(List<int> leftNumbers, List<int> rightNumbers)
    {
        long totalSimilarity = 0L;
        for (int i = 0; i < leftNumbers.Count; i++)
        {
            int left = leftNumbers[i];
            int countedRight = rightNumbers.Count(x => x == left);
            int similarity = left * countedRight;

            totalSimilarity += similarity;
        }

        return totalSimilarity;
    }
}