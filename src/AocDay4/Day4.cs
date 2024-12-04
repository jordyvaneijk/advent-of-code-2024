using Common;
using Spectre.Console;

namespace AocDay4;

public class Day4 : IDay<string>
{
    private List<string> _lines;
    private Puzzle _puzzle;
    
    public void ParseInput()
    {
        _lines = File.ReadAllLines("Input/input_day4.txt").ToList();
        _lines = File.ReadAllLines("Input/example_day4.txt").ToList();
        int rowCount = _lines.Count;
        int colCount = _lines[0].Length;
        char[][] input = new char[rowCount][];
        
        for (int i = 0; i < rowCount; i++)
        {
            input[i] = _lines[i].ToCharArray();
        }

        // Store the input array in the Puzzle class
        _puzzle = new Puzzle { Input = input };
    }

    public void SolvePartOne()
    {
        Console.WriteLine($"Grid {_puzzle.Input.Length} X {_puzzle.Input[0].Length}");
        var target = "XMAS";
        var countReport = _puzzle.CountOccurrences(target);
        Console.WriteLine($"Occurrences of '{target}': {countReport.TotalCount}");
        Console.WriteLine($"Horizontal: {countReport.HorizontalCount}");
        Console.WriteLine($"Vertical: {countReport.VerticalCount}");
        Console.WriteLine($"Diagonal: {countReport.DiagonalCount}");
    }

    public void SolvePartTwo()
    {
        var target = "XMAS";
        var countReport = _puzzle.CountOccurrences(target);
        Console.WriteLine($"Special pattern: {countReport.SpecialPatternCount}");
    }

    public void Run()
    {
        ParseInput();
        AnsiConsole.Console.Clear();
        AnsiConsole.Write(new FigletText("Day 4").Centered().Color(Color.Green));
        SolvePartOne();
        Console.WriteLine();
        SolvePartTwo();
        Console.WriteLine();
        AnsiConsole.MarkupLine("[bold green]Press [red]Enter[/] to continue...[/]");
        Console.ReadLine();
    }
}