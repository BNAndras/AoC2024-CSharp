using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2024.Day03;

class Solution : SolutionBase
{
    private Regex FindMul { get; } = new(@"mul\((\d+),(\d+)\)");

    private Regex FindNewlines { get; } = new(@"\t|\n|\r");
    private Regex FindUndoSections { get; } = new(@"(?:don't\(\).*?(?:(?:do\(\))|$))");
    
    public Solution() : base(03, 2024, "Mull It Over") { }

    protected override string SolvePartOne() =>
        FindMul
            .Matches(Input)
            .Sum(m => int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value))
            .ToString();

    protected override string SolvePartTwo()
    {
        string cleaned = FindNewlines.Replace(Input, "");
        cleaned = FindUndoSections.Replace(cleaned, "");
        return FindMul
            .Matches(cleaned)
            .Sum(m => int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value))
            .ToString();
    }
}
