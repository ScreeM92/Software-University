namespace Ex04.HTMLDispatcher
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class HTMLDispatcher
    {
        public static string CreateImage(string imageSource, string alt, string title)
        {
            ElementBuilder image = new ElementBuilder("img");
            image.AddAttribute("src", imageSource);
            image.AddAttribute("alt", alt);
            image.AddAttribute("title", title);
            return image.Result(false);
        }

        public static string CreateURL(string url, string title, string text)
        {
            ElementBuilder link = new ElementBuilder("a");
            link.AddAttribute("href", url);
            link.AddAttribute("title", title);
            link.AddContent(text);
            return link.Result(true);
        }

        public static string CreateInput(string inputType, string name, string value)
        {
            ElementBuilder input = new ElementBuilder("input");
            input.AddAttribute("type", inputType);
            input.AddAttribute("name", name);
            input.AddAttribute("value", value);
            return input.Result(false);
        }
    }
}
