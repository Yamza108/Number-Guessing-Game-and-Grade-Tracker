namespace GuessingGame;

public enum GuessResult { TooLow, TooHigh, Correct }

public class GameLogic
{
    private readonly int _secret;

    public int Min { get; }
    public int Max { get; }
    public int MaxTries { get; }
    public int TriesUsed { get; private set; }
    public bool Won { get; private set; }
    public bool IsOver => Won || TriesUsed >= MaxTries;
    public int TriesLeft => MaxTries - TriesUsed;

    public GameLogic(int min, int max, int maxTries, int? secret = null)
    {
        if (min >= max) throw new ArgumentException("min must be less than max");
        if (maxTries < 1) throw new ArgumentException("maxTries must be at least 1");
        Min = min; Max = max; MaxTries = maxTries;
        _secret = secret ?? Random.Shared.Next(min, max + 1);
    }

    public int Secret => IsOver ? _secret : throw new InvalidOperationException("Game still running");

    public GuessResult Guess(int number)
    {
        if (IsOver) throw new InvalidOperationException("Game is over");
        TriesUsed++;
        if (number == _secret) { Won = true; return GuessResult.Correct; }
        return number < _secret ? GuessResult.TooLow : GuessResult.TooHigh;
    }
}