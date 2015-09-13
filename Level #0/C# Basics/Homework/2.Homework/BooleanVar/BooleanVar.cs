// Problem 6. Boolean Variable
// Declare a Boolean variable called isFemale and assign an appropriate
// value corresponding to your gender. Print it on the console.

using System;

class BooleanVar
{
    static void Main()
    {
        Console.Title = "Boolean Variable";

        bool isFemale = true;
        Console.WriteLine("My gender is {0}.", isFemale ? "male" : "female");
    }
}

