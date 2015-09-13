using System;
using System.ComponentModel;

class TestStudent
{
    public static void Main()
    {
        Student student = new Student("Georgi", 18);
        student.handleEvent += (sender, EventArgs) =>
        {
            Console.WriteLine("Property {0} is changed from {1} to {2}",
                EventArgs.ChangedPropName, EventArgs.OldValue, EventArgs.NewValue);
        };
        student.StudentName = "Minka";
        student.StudentAge = 19;
    }
}