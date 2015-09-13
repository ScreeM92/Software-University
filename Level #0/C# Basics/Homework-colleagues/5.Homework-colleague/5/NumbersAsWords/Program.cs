using System;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        string[] oneToTwenty = new string[] { "", " One ", " Two ", " Three ", " Four ", " Five ", " Six ", " Seven ", " Eight ", " Nine ", " Ten ", " Eleven ", " Twelve ", " Thirteen ", " Fourteen ", " Fifteen ", " Sixteen ", " Seventeen ", " Eighteen ", " Nineteen " };
        string[] twentyToNinety = new string[] { "","","T wenty ", " Thirty ", " Fourty ", " Fifty ", " Sixty ", " Seventy ", " Eighty ", " Ninety " };
        while (true)
        {
            Console.WriteLine("Enter your number.[0-999]");
            string enteredString = Console.ReadLine();
            int enteredNumber = int.Parse(enteredString);
            StringBuilder finalPhrase = new StringBuilder();
            for (int i = enteredString.Length; i > 0 ; i--)
            {
                char actualDigit = enteredString[3-i];
                int currentIndex = int.Parse(actualDigit.ToString());
                if (i == 3)
                {
                    finalPhrase.Append(oneToTwenty[currentIndex]);
                    finalPhrase.Append("Hundred");
                }
                int checkAndAdd = int.Parse(enteredString[0].ToString());
                if (enteredString.Length == 3)
                {

                    if (i == 2 && enteredNumber - checkAndAdd * 100 < 20)
                    {
                        finalPhrase.Append(oneToTwenty[enteredNumber - checkAndAdd * 100]);
                        break;
                    }
                    else if (i == 2)
                    {
                        finalPhrase.Append(twentyToNinety[currentIndex]);
                    }
                }
                if (i == 1)
                {
                    finalPhrase.Append(oneToTwenty[currentIndex]);
                }
            }
            Console.WriteLine("The result is: {0}", finalPhrase);
            Console.ReadKey();
            Console.Clear();

        }
    }
}