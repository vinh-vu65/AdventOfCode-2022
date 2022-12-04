namespace AdventOfCode.Day1;

public class Day1Problem2
{
    public Day1Problem1 Day1Problem1 { get; set; } = new();

    public int PutErAllTogether()
    {
        var strings = Day1Problem1.ReadTheFile();
        var groups = Day1Problem1.SortIntoGroups(strings);
        var top3 = groups
            .Select(g => Day1Problem1.CalculateSumOfCollection(g))
            .OrderByDescending(num => num)
            .Take(3);
        return top3.Sum();
    }
}