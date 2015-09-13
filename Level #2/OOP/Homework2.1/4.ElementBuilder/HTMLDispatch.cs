using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class HTMLDispatch
    {
        static void Main() 
        {
            ElementBuilder asd = new ElementBuilder("div");
            Console.WriteLine(asd);
            asd.AddAtribute("class", "asd");
            Console.WriteLine(asd);
            asd.AddContent("<p>Hello></p>");
            Console.WriteLine(asd);
            asd.AddAtribute("id", "main");
            Console.WriteLine(asd);
            asd.AddContent("<h1>My world></h1>");
            Console.WriteLine(asd);

            Console.WriteLine(asd * 2);

            string myImage = HTMLDispatcher.CreateImage("../img/mnoo_qk.jpg", "selfi", "me on the beech");
            Console.WriteLine(myImage);

            string myLink = HTMLDispatcher.CreateURL("http://www.w3schools.com/html/", "this is my title", "Visit our HTML tutorial");
            Console.WriteLine(myLink);

            string myInput = HTMLDispatcher.CreateInput("number", "quantity", "230");
            Console.WriteLine(myInput);
        }
    }