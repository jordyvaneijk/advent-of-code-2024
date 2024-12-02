using System;
using System.Collections.Generic;
using AocDay1;
using Common;
using Spectre.Console;

namespace AdventOfCodeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var days = new Dictionary<int, IDay?>
            {
                { 1, new Day1() },
                // Add other days here
            };

            while (true)
            {
                var day = AnsiConsole.Prompt(
                    new SelectionPrompt<int>()
                        .Title("Choose a day in December [green](1-31)[/], or [red]0 to exit[/]:")
                        .PageSize(15)
                        .MoreChoicesText("[grey](Move up and down to reveal more days)[/]")
                        .AddChoices(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31));

                if (day == 0)
                {
                    break;
                }

                if (days.TryGetValue(day, out IDay? selectedDay))
                {
                    selectedDay!.Run();
                }
                else
                {
                    AnsiConsole.MarkupLine($"[red]Day {day} is not implemented yet.[/]");
                }
            }
        }
    }
}