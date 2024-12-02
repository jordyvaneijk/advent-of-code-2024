namespace Common;

public interface IDay<T>
    where T : class
{
    void ParseInput();
    void SolvePartOne();
    void SolvePartTwo();

    void Run();
}