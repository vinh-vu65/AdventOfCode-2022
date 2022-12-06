namespace AdventOfCode.Day3;

public class LetterDataInfo
{
    public char Letter { get; }
    public int Frequency { get; set; }
    public List<int> Indexes { get; }
    public string Rucksack { get; }
    public LetterDataInfo(char letter, int frequency, List<int> indexes, string rucksack)
    {
        Letter = letter;
        Frequency = frequency;
        Indexes = indexes;
        Rucksack = rucksack;
    }
}