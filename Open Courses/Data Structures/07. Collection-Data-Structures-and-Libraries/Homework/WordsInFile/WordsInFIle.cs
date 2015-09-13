namespace WordsInFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class WordsInFIle
    {
        private const string pathUrl = "http://dox.bg/files/dw?a=1c7f33c33d";
        private const string filePath = @"..\..\..\import\input.txt";
        private static Dictionary<string, int> textWords;
        private static Dictionary<string, int> matches;  

        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            textWords = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            matches = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            if (!File.Exists(filePath))
            {
                Console.WriteLine("To work this app you must download 100MB txt file from url: {0} \n" +
                                  "Paste the file in:\n{1}", pathUrl, Path.GetFullPath(filePath));
                Console.WriteLine(new string('-', 70));
                return;
            }
            
            Console.WriteLine("reading file...");
            ProcessTextEntries();
            ProcessSearchQueries();
            PrintResult();
        }

        private static void ProcessTextEntries()
        {
            using (StreamReader file = new StreamReader(filePath))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    var words = line.Split(new char[] { ' ', ',', '.', '?', '!', ':' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        if (!textWords.ContainsKey(word))
                        {
                            textWords[word] = 1;
                        }
                        else
                        {
                            textWords[word]++;
                        }
                    }
                }
            }
        }

        private static void ProcessSearchQueries()
        {
            Console.WriteLine(new string('-', 70));
            Console.Write("Enter search words count: ");
            var wordsSearch = int.Parse(Console.ReadLine());

            for (int i = 0; i < wordsSearch; i++)
            {
                Console.Write("word: ");
                var word = Console.ReadLine();

                if (!string.IsNullOrEmpty(word))
                {
                    if (textWords.ContainsKey(word))
                    {
                        matches[word] = textWords[word];
                    }
                    else
                    {
                        matches[word] = 0;
                    }
                    
                }
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine(new String('-', 70));
            foreach (var match in matches)
            {
                Console.WriteLine("{0} -> {1}", match.Key, match.Value);
            }
        }
    }
}