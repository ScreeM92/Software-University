using System;
using System.Diagnostics;
using System.Net;

class UsingDotNetClasses
{
    static void Main()
    {
        // Using dates (System.DateTime)
        DateTime today = DateTime.Now;
        Console.WriteLine("Today is: " + today);
        DateTime tomorrow = today.AddDays(1);
        Console.WriteLine("Tomorrow is: " + tomorrow);

        // Calculate cosinus (System.Math)
        double angleDegrees = 60;
        double angleRadians = angleDegrees * Math.PI / 180;
        Console.WriteLine("Cos({0} degrees) = {1}", 
            angleDegrees, Math.Cos(angleRadians));
        
        // Generating random numbers (System.Random)
        Random rnd = new Random();
        Console.WriteLine("Random number in the range [1-99]: " +
            rnd.Next(1,100));

        // Downloading a PDF file from Internet (System.Net.WebClient)
        string url = "http://www.introprogramming.info/wp-content/uploads/2013/07/Books/CSharpEn/Fundamentals-of-Computer-Programming-with-CSharp-Nakov-eBook-v2013.pdf";
        string localFileName = "CSharp-Book-Nakov.pdf";
        Console.WriteLine("Downloading {0}...", url);
        WebClient webClient = new WebClient();
        webClient.DownloadFile(url, localFileName);

        // Open the downloaded PDF file (System.Diagnostics.Process)
        Process.Start(localFileName);
    }
}
