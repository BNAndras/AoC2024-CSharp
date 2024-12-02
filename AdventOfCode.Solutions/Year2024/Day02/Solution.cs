namespace AdventOfCode.Solutions.Year2024.Day02;

class Solution : SolutionBase
{

    private List<List<int>> Reports { get; }
    
    public Solution() : base(02, 2024, "Red-Nosed Reindeer")
    {
        Reports = Input
            .SplitByNewline()
            .Select(line =>
                line.Split()
                    .Select(int.Parse)
                    .ToList()
            ).ToList();
    }

    private bool IsSorted(List<int> levels) => IsDescending(levels) || IsAscending(levels);
    
    private bool IsDescending(List<int> levels) =>
        Enumerable
            .Range(0, levels.Count - 1)
            .All(i => levels[i] >= levels[i + 1] && levels[i] - levels[i + 1] is >= 1 and <= 3);
    
    private bool IsAscending(List<int> levels) =>
        Enumerable
            .Range(0, levels.Count - 1)
            .All(i => levels[i] <= levels[i + 1] && levels[i + 1] - levels[i] is >= 1 and <= 3);

    private bool IHaveAHeadache(List<int> levels)
    {
        if (IsSorted(levels)) return true;

       return Enumerable.Range(0, levels.Count)
            .Select(i => levels.Where((_, index) => i != index)).Any(x => IsSorted(x.ToList()));
    }
        
    protected override string SolvePartOne() =>
        Reports.Count(IsSorted).ToString();
    
    protected override string SolvePartTwo() =>
        Reports
            .Count(IHaveAHeadache)
            .ToString();
}
