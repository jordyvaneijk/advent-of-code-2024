using Common;
using Spectre.Console;

namespace AocDay5;

public class Day5 : IDay<string>
{
    private List<string> _lines;
    private PrintQueue _printQueue = new();
    public void ParseInput()
    {
        _lines = File.ReadAllLines("Input/input_day5.txt").ToList();
        //_lines = File.ReadAllLines("Input/example_day5.txt").ToList();

        foreach (var line in _lines)
        {
            // PageOrder
            if (line.Contains("|"))
            {
                var rules = line.Split("|").Select(int.Parse).ToList();
                _printQueue.PageOrderingRules.Add(new PageOrderingRule(rules[0], rules[1]));
            }

            // Pages
            if (line.Contains(","))
            {
                _printQueue.PagesToProduce.Add(line.Split(",").Select(int.Parse).ToList());
            }
        }
    }

    public void SolvePartOne()
    {
        int sumOfMiddlePages = 0;
        
        foreach (var pages in _printQueue.PagesToProduce)
        {
            if (_printQueue.IsValid(pages))
            {
                _printQueue.ValidPagesToProduce.Add(pages);
            }
        }

        foreach (var validPages in _printQueue.ValidPagesToProduce)
        {
            Console.WriteLine(string.Join(",", validPages));
            int middleIndex = validPages.Count / 2;
            int middlePage = validPages[middleIndex];
            sumOfMiddlePages += middlePage;
        }

        Console.WriteLine($"Sum of middle pages: {sumOfMiddlePages}");
        
    }

    public void SolvePartTwo()
    {
        int sumOfMiddlePages = 0;

        foreach (var pages in _printQueue.PagesToProduce)
        {
            if (!_printQueue.IsValid(pages))
            {
                var orderedPages = _printQueue.OrderPages(pages);
                int middleIndex = orderedPages.Count / 2;
                int middlePage = orderedPages[middleIndex];
                sumOfMiddlePages += middlePage;
            }
        }

        Console.WriteLine($"Sum of middle pages after ordering: {sumOfMiddlePages}");
    }

    public void Run()
    {
        ParseInput();
        AnsiConsole.Console.Clear();
        AnsiConsole.Write(new FigletText("Day 5").Centered().Color(Color.Green));
        SolvePartOne();
        Console.WriteLine();
        SolvePartTwo();
        Console.WriteLine();
        AnsiConsole.MarkupLine("[bold green]Press [red]Enter[/] to continue...[/]");
        Console.ReadLine();
    }
}