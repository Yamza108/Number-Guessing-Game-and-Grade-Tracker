namespace GradeTracker;

public class Student
{
    public string Name { get; }
    public int[] Scores { get; }   // scores stored in an array, as required

    public Student(string name, int[] scores)
    {
        if (scores.Length == 0) throw new ArgumentException("At least one score required");
        Name = name; Scores = scores;
    }

    public double Average => Grading.Average(Scores);
    public int Highest => Grading.Highest(Scores);
    public int Lowest => Grading.Lowest(Scores);
    public char Grade => Grading.ToGrade(Average);
}

public static class Grading
{
    public static double Average(int[] scores)
    {
        int sum = 0;
        foreach (int s in scores) sum += s;
        return (double)sum / scores.Length;
    }

    public static int Highest(int[] scores)
    {
        int max = scores[0];
        foreach (int s in scores) if (s > max) max = s;
        return max;
    }

    public static int Lowest(int[] scores)
    {
        int min = scores[0];
        foreach (int s in scores) if (s < min) min = s;
        return min;
    }

    public static char ToGrade(double average) => average switch
    {
        >= 90 => 'A',
        >= 80 => 'B',
        >= 70 => 'C',
        >= 60 => 'D',
        _ => 'F'
    };
}