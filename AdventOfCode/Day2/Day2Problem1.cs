namespace AdventOfCode.Day2;

public class Day2Problem1
{
    // ROCK =       A = X = 1   LOSE = 0
    // PAPER =      B = Y = 2   DRAW = 3
    // SCISSORS =   C = Z = 3   WIN  = 6
    public string[] ProblemInput { get; private set; }

    private void SetProblemInput()
    {
        ProblemInput = File.ReadAllLines("../../../Day2/Input.txt");
    }

    public int CalculateProblemAnswer()
    {
        SetProblemInput();
        return ProblemInput.Select(line => GetTotalGameScore(ParseGameSummary(line))).Sum();
    }

    public int GetTotalGameScore((GameChoice, GameChoice) gameSummary) =>
        GetOutcomeScore(gameSummary) + GetPlayerChoiceScore(gameSummary);

    public int GetOutcomeScore((GameChoice elfChoice, GameChoice playerChoice) gameSummary)
    {
        if (gameSummary.elfChoice == gameSummary.playerChoice) return (int)GameOutcome.Draw;
        
        return gameSummary switch
        {
            (GameChoice.Paper, GameChoice.Rock) => (int)GameOutcome.Lose,
            (GameChoice.Rock, GameChoice.Scissors) => (int)GameOutcome.Lose,
            (GameChoice.Scissors, GameChoice.Paper) => (int)GameOutcome.Lose,
            _ => (int)GameOutcome.Win
        };
    }

    public int GetPlayerChoiceScore((GameChoice elfChoice, GameChoice playerChoice) gameSummary) =>
        (int)gameSummary.playerChoice;

    public (GameChoice elfChoice, GameChoice playerChoice) ParseGameSummary(string gameSummary)
    {
        var elfChoice = gameSummary.First() switch
        {
            'A' => GameChoice.Rock,
            'B' => GameChoice.Paper,
            _ => GameChoice.Scissors
        };
        
        var playerChoice = gameSummary.Last() switch
        {
            'X' => GameChoice.Rock,
            'Y' => GameChoice.Paper,
            _ => GameChoice.Scissors
        };

        return (elfChoice, playerChoice);
    }
}