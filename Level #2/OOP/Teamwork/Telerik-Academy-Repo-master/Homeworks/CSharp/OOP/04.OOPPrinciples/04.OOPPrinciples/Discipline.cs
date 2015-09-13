using System;
class Discipline : School, ICommentable
{
    private int numberOfLectures;
    private int numberOfExercises;
    private string name;

    public string Comment { get; set; }

    public string Name
    {
        get
        { return this.name; }
        set
        {
            if (value.Length < 3 && value.Length > 60)
            {
                throw new FormatException("The name must be between 3 and 60 symbols");
            }
            this.name = value;
        }
    }

    public int NumberOfLectures
    {
        get { return numberOfLectures; }
        set
        {
            if (value < 0)
            {
                throw new FormatException("Must be positive integer!");
            }
            numberOfLectures = value;
        }
    }

    public int NumberOfExercises
    {
        get { return this.numberOfExercises; }
        set
        {
            if (value < 0)
            {
                throw new FormatException("Must be positive integer!");
            }
            this.numberOfExercises = value;
        }
    }

    public Discipline(string name, int numberOfLectures, int numberOfExercises)
    {
        this.name = name;
        this.numberOfExercises = numberOfExercises;
        this.numberOfLectures = numberOfLectures;
    }
}
