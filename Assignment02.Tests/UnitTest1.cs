using GradeTracker;
using GuessingGame;

public class GameLogicTests
{
    [Fact]
    public void Guess_LowHighCorrect()
    {
        var g = new GameLogic(1, 100, 5, secret: 50);
        Assert.Equal(GuessResult.TooLow, g.Guess(10));
        Assert.Equal(GuessResult.TooHigh, g.Guess(90));
        Assert.Equal(GuessResult.Correct, g.Guess(50));
        Assert.True(g.Won);
        Assert.True(g.IsOver);
    }

    [Fact]
    public void GameEnds_WhenTriesRunOut()
    {
        var g = new GameLogic(1, 10, 2, secret: 5);
        g.Guess(1); g.Guess(2);
        Assert.True(g.IsOver);
        Assert.False(g.Won);
        Assert.Throws<InvalidOperationException>(() => g.Guess(3));
    }

    [Fact]
    public void Secret_HiddenUntilOver()
    {
        var g = new GameLogic(1, 10, 3, secret: 5);
        Assert.Throws<InvalidOperationException>(() => g.Secret);
    }

    [Fact]
    public void InvalidSettings_Throw()
    {
        Assert.Throws<ArgumentException>(() => new GameLogic(10, 1, 3));
        Assert.Throws<ArgumentException>(() => new GameLogic(1, 10, 0));
    }
}

public class GradingTests
{
    [Fact]
    public void Statistics_AreCorrect()
    {
        int[] scores = { 70, 90, 80 };
        Assert.Equal(80, Grading.Average(scores));
        Assert.Equal(90, Grading.Highest(scores));
        Assert.Equal(70, Grading.Lowest(scores));
    }

    [Theory]
    [InlineData(95, 'A')] [InlineData(90, 'A')] [InlineData(89.9, 'B')]
    [InlineData(75, 'C')] [InlineData(60, 'D')] [InlineData(59, 'F')]
    public void ToGrade_Boundaries(double avg, char expected)
        => Assert.Equal(expected, Grading.ToGrade(avg));

    [Fact]
    public void Student_RequiresScores()
        => Assert.Throws<ArgumentException>(() => new Student("Ann", Array.Empty<int>()));
}