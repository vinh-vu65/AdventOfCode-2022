namespace AdventOfCode.Day1;

public class Problem2
{
    public Problem1 Problem1 { get; set; } = new();

    public int PutErAllTogether()
    {
        var strings = Problem1.ReadTheFile();
        var groups = Problem1.SortIntoGroups(strings);
        var top3 = groups
            .Select(g => Problem1.CalculateSumOfCollection(g))
            .OrderByDescending(num => num)
            .Take(3);
        return top3.Sum();
    }
}