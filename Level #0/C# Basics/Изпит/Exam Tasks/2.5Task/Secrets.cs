using System;
class Secrets
{
    static void Main()
    {
        //read the input number as a string
        string inputNumber = Console.ReadLine();

        //remove the leading minus if the number is negative
        inputNumber = inputNumber.TrimStart('-');

        //reverse the input to fit task logic
        var inputCharArray = inputNumber.ToCharArray();
        Array.Reverse(inputCharArray);

        long specialSum = 0;

        //calculate the special sum by evaluating the score that each number contributes to the total score
        for (int i = 1; i <= inputCharArray.Length; i++)
        {
            //save the current digit and position in variables to avoid code repetition
            int currentDigit = int.Parse(inputCharArray[i - 1].ToString()); //int currentDigit = inputCharArray[i - 1] - 48;
            int position = i;

            //calculate the sum of the current digit using the formulae given in the task description
            if (i % 2 == 1)
            {
                specialSum += currentDigit * position * position;
            }
            else
            {
                specialSum += currentDigit * currentDigit * position;
            }
        }
        //print the special sum of the input number
        Console.WriteLine(specialSum);

        //determinate the initial letter and the length of the alpha-sequence
        int sequenceLength = (int)specialSum % 10;
        int currentLetter = (int)(specialSum % 26);

        if (sequenceLength == 0)
        {
            Console.WriteLine("{0} has no secret alpha-sequence", inputNumber);
        }
        else
        {
            //print the alpha-sequence using the codes of the Latin letters in the ASCII table
            for (int i = 0; i < sequenceLength; i++)
            {
                Console.Write((char)((currentLetter + i) % 26 + 65)); // Console.Write((char)((currentLetter + i) % 26 + 'A'));
            }
        }

    }
}