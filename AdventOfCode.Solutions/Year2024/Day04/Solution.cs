namespace AdventOfCode.Solutions.Year2024.Day04;

class Solution : SolutionBase
{
    
    private List<List<char>> Grid { get; }

    private (string name, int x, int y)[] P1Directions =>
    [
        ("N", 0, 1),
        ("S", 0, -1),
        ("E", 1, 0),
        ("W", -1, 0),
        ("NE", 1, 1),
        ("NW", -1, 1),
        ("SE", 1, -1),
        ("SW", -1, -1),
    ];
    
    public Solution() : base(04, 2024, "Ceres Search")
    {
        Grid = Input.SplitByNewline().Select(x => x.ToCharArray().ToList()).ToList();
    }

    protected override string SolvePartOne()
    {
        int count = 0;
        int maxY = Grid.Count - 1;
        int maxX = Grid[0].Count - 1;
        for (var y = 0; y <= maxY; y++)
        {
            for (var x = 0; x <= maxX; x++)
            {
                if (Grid[y][x] is not 'X') continue;
                foreach (var (_, dx, dy) in P1Directions)
                {
                    if (0 > (y + dy * 3) || (y + dy * 3) > maxY) continue;
                    if (0 > (x + dx * 3) || (x + dx * 3) > maxX) continue;

                    if (Grid[y + dy][x + dx] is 'M' && Grid[y + dy * 2][x + dx * 2] is 'A' &&
                        Grid[y + dy * 3][x + dx * 3] is 'S')
                    {
                        count++;
                    }
                }
            }
        }
        
        return count.ToString();
    }

    protected override string SolvePartTwo()
    {
        int count = 0;
        int maxY = Grid.Count - 1;
        int maxX = Grid[0].Count - 1;
        for (var y = 1; y < maxY; y++)
        {
            for (var x = 1; x < maxX; x++)
            {
                if (Grid[y][x] is not 'A') continue;
                
                char upperLeft = Grid[y - 1][x - 1];
                char upperRight = Grid[y - 1][x + 1];
                char lowerLeft = Grid[y + 1][x - 1];
                char lowerRight = Grid[y + 1][x + 1];

                if (((upperLeft is 'M' && lowerRight is 'S') || (upperLeft is 'S' && lowerRight is 'M')) &&
                    ((upperRight is 'M' && lowerLeft is 'S') || (upperRight is 'S' && lowerLeft is 'M')))
                {
                    count++;
                }
            }
        }
        
        return count.ToString();
    }
}
