using System;
    class QuotesInStrings
    {
        static void Main()
        {
            string quoteone = "The \"use\" of quotations causes difficulties.";
            Console.WriteLine(quoteone);
            string quotetwo = @"The ""use"" of quotations causes difficulties.";
            Console.WriteLine(quotetwo);
        }
    }

