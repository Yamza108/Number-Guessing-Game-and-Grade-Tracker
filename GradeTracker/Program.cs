using GradeTracker;

var students = new List<Student>();
RunMenu(students);

static void RunMenu(List<Student> students)
{
    while (true)
    {
        Console.WriteLine("\n=== Grade Tracker ===\n1) Add student\n2) Show report\n3) Quit");
        Console.Write("Choice: ");
        switch (Console.ReadLine()?.Trim())
        {
            case "1": AddStudent(students); break;
            case "2": ShowReport(students); break;
            case "3": return;
            default: Console.WriteLine("Please enter 1, 2 or 3."); break;
        }
    }
}

static void AddStudent(List<Student> students)
{
    string name = ReadNonEmpty("Student name: ");
    int count = ReadInt("How many scores? ", 1, 20);
    var scores = new int[count];
    for (int i = 0; i < count; i++)
        scores[i] = ReadInt($"Score {i + 1} (0-100): ", 0, 100);
    students.Add(new Student(name, scores));
    Console.WriteLine("Student added.");
}

static void ShowReport(List<Student> students)
{
    if (students.Count == 0) { Console.WriteLine("No students yet."); return; }
    Console.WriteLine($"\n{"Name",-15}{"Avg",8}{"High",6}{"Low",6}{"Grade",7}");
    foreach (var s in students)
        Console.WriteLine($"{s.Name,-15}{s.Average,8:F1}{s.Highest,6}{s.Lowest,6}{s.Grade,7}");
}

static string ReadNonEmpty(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(input)) return input;
        Console.WriteLine("Name cannot be empty.");
    }
}

static int ReadInt(string prompt, int min, int max)
{
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int v) && v >= min && v <= max) return v;
        Console.WriteLine($"Enter a whole number between {min} and {max}.");
    }
}