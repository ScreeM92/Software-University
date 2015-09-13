using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    static class HTMLDispatcher
    {
        public static string CreateImage(string imgSrc, string alt, string title)
        {

            ElementBuilder img = new ElementBuilder("img");
            img.AddAtribute("src", imgSrc);
            img.AddAtribute("alt", alt);
            img.AddAtribute("title", title);

            return img.ToString();
        }

        public static string CreateURL(string url, string title, string text)
        {
            ElementBuilder anchor = new ElementBuilder("a");
            anchor.AddAtribute("url", url);
            anchor.AddAtribute("title", title);
            anchor.AddContent(text);

            return anchor.ToString();
        }

        public static string CreateInput(string type, string name, string value)
        {
            ElementBuilder input = new ElementBuilder("input");
            input.AddAtribute("type", type);
            input.AddAtribute("name", name);
            input.AddAtribute("value", value);

            return input.ToString();
        }
    }
