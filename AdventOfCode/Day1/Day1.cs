namespace AdventOfCode.Day1;

public class Day1
{
    // Read all lines from text file
    // Group lines and separate by empty space
    // Add total in each group
    // Find value of highest total
    public int CalculateProblem1()
    {
        var strings = ReadTheFile();
        var groups = SortIntoGroups(strings);
        return GetHighestTotal(groups);
    }
    
    public int CalculateProblem2()
    {
        var strings = ReadTheFile();
        var groups = SortIntoGroups(strings);
        var top3 = groups
            .Select(CalculateSumOfCollection)
            .OrderByDescending(num => num)
            .Take(3);
        return top3.Sum();
    }
    
    public IEnumerable<string> ReadTheFile()
    {
        var filePath = "../../../Day1/Day-One-Input.txt";

        var values = File.ReadAllLines(filePath);
        return values;
    }

    public List<List<string>> SortIntoGroups(IEnumerable<string> input)
    {
        var output = new List<List<string>>();
        // Iterate through the array of strings
        // Add items to inner list, once the iterator reaches empty string, add to next list
        var innerList = new List<string>();
        foreach (var calorie in input)
        {
            if (!string.IsNullOrWhiteSpace(calorie))
            {
                innerList.Add(calorie);
            }
            else
            {
                output.Add(innerList);
                innerList = new List<string>();
            }
        }

        if (innerList.Count > 0)
        {
            output.Add(innerList);
        }

        return output;
    }

    public int GetHighestTotal(List<List<string>> calorieGroups)
    {
        var highestTotal = 0;
        foreach (var group in calorieGroups)
        {
            var groupTotal = CalculateSumOfCollection(group);
            highestTotal = Math.Max(highestTotal, groupTotal);
        }

        return highestTotal;
    }

    public int CalculateSumOfCollection(ICollection<string> input) => input.Sum(int.Parse);
}