using AdventOfCode.Day1;

namespace AdventOfCode.Tests.Day1;

public class Problem1Tests
{
    [Fact]
    public void SortIntoGroups_ShouldReturnGroupedItemsInStringArraySeperatedByEmptyEntriesInArray()
    {
        var sut = new AdventOfCode.Day1.Day1();
        var testInput = new[] {"123", "456", "123", " ", "567", "345", "", "789"};
        var expected = new List<List<string>>
        {
            new() {"123", "456", "123"},
            new() {"567", "345"},
            new() {"789"}
        };

        var actual = sut.SortIntoGroups(testInput);
        
        Assert.Equal(expected, actual);
    }

    [Fact] 
    public void CalculateSumOfCollection_ShouldReturnSumOfGivenStringCollection()
    {
        var sut = new AdventOfCode.Day1.Day1();
        var input = new List<string> {"1", "3", "5"};
        var expected = 9;

        var actual = sut.CalculateSumOfCollection(input);
        
        Assert.Equal(expected, actual);
    }
}