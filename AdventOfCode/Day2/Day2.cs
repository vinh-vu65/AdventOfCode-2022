namespace AdventOfCode.Day2;

public class Day2
{
    // ROCK =       A = X = 1   LOSE = 0
    // PAPER =      B = Y = 2   DRAW = 3
    // SCISSORS =   C = Z = 3   WIN  = 6
    public string[] ProblemInput { get; private set; }

    private void SetProblemInput()
    {
        ProblemInput = File.ReadAllLines("../../../Day2/Input.txt");
    }

    public int CalculateProblem1()
    {
        SetProblemInput();
        return ProblemInput.Select(line => GetTotalGameScore(ParseGameSummaryProblem1(line))).Sum();
    }

    public int CalculateProblem2()
    {
        SetProblemInput();
        return ProblemInput.Select(line => GetTotalScoreProblem2(ParseGameSummaryProblem2(line))).Sum();
    }

    public int GetTotalGameScore((GameChoice, GameChoice) gameSummary) =>
        GetOutcomeScore(gameSummary) + GetPlayerChoiceScore(gameSummary);

    public int GetTotalScoreProblem2((GameChoice elfChoice, GameOutcome outcome) gameSummary) =>
        (int) gameSummary.outcome + (int) FindPlayerInput(gameSummary);

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

    public (GameChoice elfChoice, GameChoice playerChoice) ParseGameSummaryProblem1(string gameSummary)
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

    public (GameChoice, GameOutcome) ParseGameSummaryProblem2(string gameSummary)
    {
        var elfChoice = gameSummary.First() switch
        {
            'A' => GameChoice.Rock,
            'B' => GameChoice.Paper,
            _ => GameChoice.Scissors
        };
        
        var gameOutcome = gameSummary.Last() switch
        {
            'X' => GameOutcome.Lose,
            'Y' => GameOutcome.Draw,
            _ => GameOutcome.Win
        };

        return (elfChoice, gameOutcome);
    }

    public GameChoice FindPlayerInput((GameChoice elfChoice, GameOutcome outcome) input)
    {
        if (input.outcome == GameOutcome.Draw) return input.elfChoice;

        if (input.outcome == GameOutcome.Win)
        {
            return input.elfChoice switch
            {
                GameChoice.Rock => GameChoice.Paper,
                GameChoice.Paper => GameChoice.Scissors,
                _ => GameChoice.Rock
            };
        }
        
        if (input.outcome == GameOutcome.Lose)
        {
            return input.elfChoice switch
            {
                GameChoice.Rock => GameChoice.Scissors,
                GameChoice.Paper => GameChoice.Rock,
                _ => GameChoice.Paper
            };
        }

        return GameChoice.Rock;
    }
}