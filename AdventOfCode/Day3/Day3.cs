using System.Text.RegularExpressions;

namespace AdventOfCode.Day3;

public class Day3
{
    public string[] ProblemInput { get; private set; }
    public Regex Regex { get; }

    public Day3()
    {
        Regex = new Regex("[a-z]");
    }

    public int CalculateProblem1()
    {
        SetProblemInput();
        var priorityLetters = ProblemInput.Select(GetPriorityLetter);
        return priorityLetters.Select(GetPriorityScore).Sum();
    }

    public int CalculateProblem2()
    {
        SetProblemInput();
        var priorityList = new List<char>();
        for (var i = 0; i < ProblemInput.Length / 3; i++)
        {
            var elfGroup = ProblemInput.Skip(i * 3).Take(3).ToList();
            priorityList.Add(GetPriorityGroupLetter(elfGroup));
        }

        return priorityList.Select(GetPriorityScore).Sum();
    }

    private void SetProblemInput()
    {
        ProblemInput = File.ReadAllLines("../../../Day3/Input.txt");
    }

    public char GetPriorityGroupLetter(List<string> input)
    {
        var hashy = new HashSet<char>(input.First());
        hashy.IntersectWith(input[1]);
        hashy.IntersectWith(input[2]);

        return hashy.Single();
    }
    
    public char GetPriorityLetter(string input)
    {
        var halfLength = input.Length / 2;
        var firstHalf = input.Substring(0, halfLength);
        var sececondHalf = input.Substring(halfLength, halfLength);

        return firstHalf.Intersect(sececondHalf).Single();
    }

    public int GetPriorityScore(char letter) =>
        Regex.IsMatch(letter.ToString()) ? letter - 96 : letter - 38;
}