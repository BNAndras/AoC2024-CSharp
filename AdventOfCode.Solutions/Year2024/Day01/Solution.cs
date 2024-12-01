namespace AdventOfCode.Solutions.Year2024.Day01;

class Solution : SolutionBase
{
    private List<int> List1 { get; } = [];
    private List<int> List2 {get;} = [];

    public Solution() : base(01, 2024, "Historian Hysteria")
    {
        List<(int, int)> items = Input
            .SplitByNewline()
            .Select(line =>
                line.Split("   ")
                    .Select(int.Parse)
                    .ToArray())
            .Select(nums => (nums[0], nums[1]))
            .ToList();
        foreach ( (int num1, int num2) in items)
        {
            List1.Add(num1);
            List2.Add(num2);
        }
        
        List1.Sort();
        List2.Sort(); 
    }
    
    protected override string SolvePartOne() =>
        List1
            .Zip(List2, (a, b) => Math.Abs(a - b))
            .Sum()
            .ToString();

    protected override string SolvePartTwo() =>
        List1
            .Sum(n1 => n1 * List2.Count(n2 => n2 == n1))
            .ToString();
}
