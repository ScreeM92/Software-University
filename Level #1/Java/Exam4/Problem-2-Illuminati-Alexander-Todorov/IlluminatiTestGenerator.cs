using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IlluminatiTestGenerator
{
    class IlluminatiTestGenerator
    {
        static void Main()
        {
            GenerateTests();
        }
        const string ZeroTestsInputFormat = "test.000.{0:000}.in.txt";
        const string TestsInputFormat = "test.{0:000}.in.txt";
        const string ZeroTestsOutputFormat = "test.000.{0:000}.out.txt";
        const string TestsOutputFormat = "test.{0:000}.out.txt";
        static string path = Environment.CurrentDirectory + @"..\..\..\Tests\";
        public static void GenerateTests()
        {

            List<string> inputPhrases = new List<string>() { "Shh!", "Computer says NO!", "I'll be back!",  "Goooood morning, Vietnam", "Houston, we have a problem.",
               "YOU SHALL NOT PASS!!!", "THE POWER OF CHRIST COMPELS YOU!!!", "I love the smell of napalm in the morning","I’m gonna make him an offer he can’t refuse.", "I have come here to chew bubblegum and kick ass, and I’m all out of bubblegum.", };
            List<int> inputPhrasesRepetitions = new List<int>() { 10, 20, 50, 134, 333, 541, 721, 1111, 5027, 10001 };
            List<string> zeroTestsInputPhrases = new List<string>() { "Listen very carefully, I shall say this only once.", "Heeeeeeere’s JOHNNY!", "Don’t ask me about my business!" };

            //generates test according to the input phrases and repetition counts in the lists
            for (int i = 0; i < inputPhrasesRepetitions.Count; i++)
            {
                var currentTestInput = new StringBuilder();
                //writes the input file
                using (var writer = new StreamWriter(path + string.Format(TestsInputFormat, i + 1)))
                {
                    for (int j = 0; j < inputPhrasesRepetitions[i]; j++)
                    {
                        currentTestInput.Append(inputPhrases[i]);
                    }
                    writer.Write(currentTestInput);
                    
                }
                //writes the output file
                using (var writer = new StreamWriter(path + string.Format(TestsOutputFormat, i + 1)))
                {
                    var currentTestResult = GenerateTestResult(currentTestInput.ToString());
                    writer.Write(currentTestResult);
                }
            }

            //generates the zero test as shown in the task description
            for (int i = 0; i < zeroTestsInputPhrases.Count; i++)
            {
                //zero input file
                using (var writer = new StreamWriter(path + string.Format(ZeroTestsInputFormat, i + 1)))
                {
                    writer.Write(zeroTestsInputPhrases[i]);
                }
                //zero output file
                using (var writer = new StreamWriter(path + string.Format(ZeroTestsOutputFormat, i + 1)))
                {
                    var currentTestResult = GenerateTestResult(zeroTestsInputPhrases[i]);
                    writer.Write(currentTestResult);
                }
            }
        }

        static StringBuilder GenerateTestResult(string message)
        {
            var test = new StringBuilder();

            message = message.ToUpper();

            int numberOfVowels = 0;
            int sumOfLetters = 0;

            foreach (char letter in message)
            {
                if (letter == 'A' || letter == 'U' || letter == 'O' || letter == 'E' || letter == 'I')
                {
                    sumOfLetters += letter;
                    numberOfVowels++;
                }
            }
            test.AppendLine(numberOfVowels.ToString());
            test.AppendLine(sumOfLetters.ToString());
            return test;
        }
    }
}
