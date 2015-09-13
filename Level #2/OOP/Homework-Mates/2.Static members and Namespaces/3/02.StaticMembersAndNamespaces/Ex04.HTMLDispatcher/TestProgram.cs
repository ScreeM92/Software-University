namespace Ex04.HTMLDispatcher
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TestProgram
    {
        public static void Main(string[] args)
        {
            ElementBuilder div = new ElementBuilder("div");

            //div.AddAttribute("id", "Page");
            //div.AddAttribute("class", "big");
            //div.AddContent("<p>Hello</p>");

            //Console.WriteLine(div * 2);

            //Console.WriteLine(HTMLDispatcher.CreateImage("hi.jpeg", "hello", "I say hello"));
            //Console.WriteLine(HTMLDispatcher.CreateURL("http://www.w3schools.com/html/", "W3C", "Visit our HTML tutorial"));
            //Console.WriteLine(HTMLDispatcher.CreateInput("submit", "fname", "Submit"));
        }
    }
}
