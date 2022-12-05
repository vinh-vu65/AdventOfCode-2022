using AdventOfCode.Day2;

namespace AdventOfCode.Tests.Day2;

public class Day2Tests
{
    private readonly AdventOfCode.Day2.Day2 _sut = new();
    
    [Theory]
    [InlineData(GameChoice.Paper, GameChoice.Scissors, GameOutcome.Win)]
    [InlineData(GameChoice.Paper, GameChoice.Rock, GameOutcome.Lose)]
    [InlineData(GameChoice.Paper, GameChoice.Paper, GameOutcome.Draw)]
    public void GetOutcome_ShouldOutcomeOfGame_WhenGivenElfChoiceAndPlayerChoice(GameChoice elfChoice, GameChoice playerChoice, GameOutcome expected)
    {
        var gameSummary = (elfChoice, playerChoice);
        
        var result = _sut.GetOutcomeScore(gameSummary);
        
        Assert.Equal((int)expected, result);
    }

    [Fact]
    public void ParseGameSummaryProblem1_ShouldReturnTupleOfGameChoice_WhenGivenString()
    {
        var inputString = "A X";
        var expected = (GameChoice.Rock, GameChoice.Rock);
        
        var actual = _sut.ParseGameSummaryProblem1(inputString);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetPlayerChoiceScore_ShouldReturnScore_WhenGivenGameSummaryTuple()
    {
        var game = (GameChoice.Paper, GameChoice.Rock);

        var actual = _sut.GetPlayerChoiceScore(game);
        
        Assert.Equal(1, actual);
    }

    [Fact]
    public void GetTotalGameScore_ShouldReturnSumOfGameScoreAndPlayerChoiceScore_WhenGivenGameSummary()
    {
        var game = (GameChoice.Scissors, GameChoice.Rock);
        var expected = 7;

        var actual = _sut.GetTotalGameScore(game);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ParseGameSummaryProblem2_ShouldReturnElfChoiceAndGameOutcome_WhenGivenString()
    {
        var input = "B Y";
        var expected = (GameChoice.Paper, GameOutcome.Draw);

        var actual = _sut.ParseGameSummaryProblem2(input);
        
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(GameChoice.Scissors, GameOutcome.Win, GameChoice.Rock)]
    [InlineData(GameChoice.Scissors, GameOutcome.Lose, GameChoice.Paper)]
    [InlineData(GameChoice.Scissors, GameOutcome.Draw, GameChoice.Scissors)]
    public void FindPlayerInput_ShouldReturnCorrectGameChoice_WhenGivenElfChoiceAndGameOutcome(GameChoice elfChoice,
        GameOutcome outcome, GameChoice expected)
    {
        var input = (elfChoice, outcome);

        var actual = _sut.FindPlayerInput(input);
        
        Assert.Equal(expected, actual);
    }
}