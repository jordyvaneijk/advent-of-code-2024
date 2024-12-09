using Common;
using Spectre.Console;

namespace AocDay9;

public class Day9 : IDay<string>
{
    private List<string> _lines;

    public void ParseInput()
    {
        _lines = File.ReadAllLines("Input/input_day6.txt").ToList();
        //_lines = File.ReadAllLines("Input/example_day6.txt").ToList();
    }

    public void SolvePartOne()
    {
        throw new NotImplementedException();
    }

    public void SolvePartTwo()
    {
        throw new NotImplementedException();
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