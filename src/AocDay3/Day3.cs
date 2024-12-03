using System.Text.RegularExpressions;
using Common;

namespace AocDay3;

public class Day3 : IDay<string>
{
    private List<string> _lines;
    public void ParseInput()
    {
        //_lines = 
    }

    public void SolvePartOne()
    {
        //string example = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
        string input = File.ReadAllText("Input/input_day3.txt");
        //string pattern = @"\bmul\(\d{1,3},\d{1,3}\)";
        string pattern = @"mul\(\d{1,3},\d{1,3}\)";
        
        // Remove everything between "don't()" and "do()"
        string filteredInput = Regex.Replace(input, @"don't\(\).*?do\(\)", string.Empty, RegexOptions.Singleline);

        // Remove everything from the last "don't()" that does not have a "do()"
        int lastDontIndex = filteredInput.LastIndexOf("don't()");
        if (lastDontIndex != -1 && !filteredInput.Substring(lastDontIndex).Contains("do()"))
        {
            filteredInput = filteredInput.Substring(0, lastDontIndex);
        }
        
        MatchCollection matches = Regex.Matches(filteredInput, pattern);

        var count = 0;
        var totalResult = 0;
        foreach (Match match in matches)
        {
            count++;
            string matchValue = match.Value;
            int openParenIndex = matchValue.IndexOf('(');
            int commaIndex = matchValue.IndexOf(',');
            int closeParenIndex = matchValue.IndexOf(')');

            int firstDigit = int.Parse(matchValue.Substring(openParenIndex + 1, commaIndex - openParenIndex - 1));
            int lastDigit = int.Parse(matchValue.Substring(commaIndex + 1, closeParenIndex - commaIndex - 1));
            int result = firstDigit * lastDigit;
            totalResult += result;
            Console.WriteLine($"{match.Value}: {result}");
        }

        Console.WriteLine($"Count: {count}: Total: {totalResult}");
    }

    public void SolvePartTwo()
    {
        throw new NotImplementedException();
    }

    public void Run()
    {
        //ParseInput();
        SolvePartOne();
        //SolvePartTwo();
    }
}
