using Common;

namespace AocDay3;

public class Day3 : IDay<string>
{
    private List<string> _lines;
    public void ParseInput()
    {
        _lines = File.ReadAllLines("Input/input_day3.txt").ToList();
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
        SolvePartOne();
        SolvePartTwo();
    }
}
