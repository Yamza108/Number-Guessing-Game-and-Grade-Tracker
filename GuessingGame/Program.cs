using GuessingGame;

RunMenu();

static void RunMenu()
{
    while (true)
    {
        Console.WriteLine("\n=== Guessing Game ===\n1) Play\n2) Quit");
        Console.Write("Choice: ");
        switch (Console.ReadLine()?.Trim())
        {
            case "1": PlayRound(); break;
            case "2": return;
            default: Console.WriteLine("Please enter 1 or 2."); break;
        }
    }
}

static void PlayRound()
{
    var game = new GameLogic(min: 1, max: 100, maxTries: 7);
    Console.WriteLine($"I'm thinking of a number from {game.Min} to {game.Max}. You have {game.MaxTries} tries.");

    while (!game.IsOver)
    {
        int guess = ReadInt($"Guess ({game.TriesLeft} left): ", game.Min, game.Max);
        var result = game.Guess(guess);
        Console.WriteLine(result switch
        {
            GuessResult.TooLow => "Too low!",
            GuessResult.TooHigh => "Too high!",
            _ => $"Correct! You needed {game.TriesUsed} tries."
        });
    }
    if (!game.Won) Console.WriteLine($"Out of tries. The number was {game.Secret}.");
}

static int ReadInt(string prompt, int min, int max)
{
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
            return value;
        Console.WriteLine($"Enter a whole number between {min} and {max}.");
    }
}