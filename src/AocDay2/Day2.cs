using Common;
using Spectre.Console;


namespace AocDay2;

public class Day2 : IDay<string>
{
    private List<string> _lines;

    public void Run()
    {
        ParseInput();
        AnsiConsole.Console.Clear();
        AnsiConsole.Write(new FigletText("Day 2").Centered().Color(Color.Green));
        SolvePartOne();
        Console.WriteLine();
        SolvePartTwo();
        Console.WriteLine();
        AnsiConsole.MarkupLine("[bold green]Press [red]Enter[/] to continue...[/]");
        Console.ReadLine();
    }

    public void ParseInput()
    {
        _lines = File.ReadAllLines("Input/input_day2.txt").ToList();
    }

    public void SolvePartOne()
    {
        var count = 0;
        foreach (var line in _lines)
        {
            var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var numbers = parts.Select(int.Parse).ToArray();

            bool isIncreasing = true;
            bool isDecreasing = true;

            for (int i = 1; i < numbers.Length; i++)
            {
                int difference = Math.Abs(numbers[i] - numbers[i - 1]);
                if (difference < 1 || difference > 3)
                {
                    isIncreasing = false;
                    isDecreasing = false;
                    break;
                }

                if (numbers[i] < numbers[i - 1])
                {
                    isIncreasing = false;
                }

                if (numbers[i] > numbers[i - 1])
                {
                    isDecreasing = false;
                }
            }

            bool result = (isIncreasing || isDecreasing) && numbers.Length > 1;

            Console.WriteLine($"Row: {line} - {result}");

            if (result)
            {
                count++;
            }
        }

        Console.WriteLine("Outcome for Day 2 part 1");
        Console.WriteLine($"Number of safe rows: {count}");
    }

    public void SolvePartTwo()
    {
        var reports = _lines.Select(x => new Report
        {
            Numbers = x.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()
        }).ToList();

        var validReposts = reports.Count(x => x.IsValid());
        Console.WriteLine($"Outcome for Day 2 part 2");
        Console.WriteLine($"Number of safe rows: {validReposts}");

        var validDampenedReports = reports.Count(x => x.IsValidDampened());
        Console.WriteLine($"Number of safe rows with dampened: {validDampenedReports}");
    }
}

public class Report
{
    public int[] Numbers { get; init; }
    public string Reason { get; set; }

    public Direction Direction => this.GetDirection(this.Numbers[0], this.Numbers[1]);

    public bool IsValid() => this.IsValid(this.Numbers);

    public bool IsValidDampened()
    {
        if (this.IsValid())
            return true;

        var tempList = new List<int>();
        for (var i = 0; i < this.Numbers.Length; i++)
        {
            tempList.Clear();
            tempList.AddRange(this.Numbers);
            tempList.RemoveAt(i);

            if (this.IsValid(tempList.ToArray()))
                return true;
        }

        return false;
    }

    private bool IsValid(int[] numbers)
    {
        var direction = this.GetDirection(numbers[0], numbers[1]);

        for (var i = 1; i < numbers.Length; i++)
        {
            if (!this.IsValid(direction, numbers[i - 1], numbers[i]))
                return false;
        }

        return true;
    }

    private bool IsValid(Direction initialDir, int a, int b)
    {
        var direction = this.GetDirection(a, b);
        if (direction == Direction.Stale)
            return this.LogReason(false, "Stale direction");

        if (direction != initialDir)
            return this.LogReason(false, $"Invalid direction {direction} {this.Direction} ({a}, {b})");

        var difference = Math.Abs(a - b);
        if (difference > 3)
            return this.LogReason(false, $"Invalid difference {difference} ({a}, {b})");

        return true;
    }

    private Direction GetDirection(int a, int b)
    {
        if (a == b)
            return Direction.Stale;

        if (a < b)
            return Direction.Up;

        return Direction.Down;
    }

    private bool LogReason(bool output, string reason)
    {
        this.Reason = reason;

        return output;
    }
}

public enum Direction
{
    Up,
    Down,
    Stale,
}