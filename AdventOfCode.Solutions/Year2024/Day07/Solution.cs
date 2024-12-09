namespace AdventOfCode.Solutions.Year2024.Day07;

class Solution : SolutionBase
{
    private List<List<long>> Equations {get; }
    public Solution() : base(07, 2024, "Bridge Repair") {
        Equations = Input
            .SplitByNewline()
            .Select(l => l.Replace(":", "")
                          .Split(" ")
                          .Select(n => long.Parse(n))
                          .ToList())
            .ToList();
    }

    protected override string SolvePartOne() =>
        Equations.Where(ValidP1Equation).Sum(l => l[0]).ToString();

    private bool ValidP1Equation(List<long> values) =>
        DoValidP1Equation(values[1..], values[0], 0L);

    private bool DoValidP1Equation(List<long> values, long target, long acc)
    {
        if (values.Count == 0) {
            return acc == target;
        }

        if (DoValidP1Equation(values[1..], target, acc + values[0])) {
            return true;
        }

        if (DoValidP1Equation(values[1..], target, acc * values[0])) {
            return true;
        }
        
        return false;
    }

    protected override string SolvePartTwo() =>
        Equations.Where(ValidP2Equation).Sum(l => l[0]).ToString();

      private bool ValidP2Equation(List<long> values) =>
        DoValidP2Equation(values[1..], values[0], 0L);
    private bool DoValidP2Equation(List<long> values, long target, long acc)
    {
        if (values.Count == 0) {
            return acc == target;
        }

        if (DoValidP2Equation(values[1..], target, acc + values[0])) {
            return true;
        }

        if (DoValidP2Equation(values[1..], target, acc * values[0])) {
            return true;
        }

        long new_acc = long.Parse(acc.ToString() + values[0].ToString());
        if (DoValidP2Equation(values[1..], target, new_acc)) {
            return true;
        }
        
        return false;
    }
}
