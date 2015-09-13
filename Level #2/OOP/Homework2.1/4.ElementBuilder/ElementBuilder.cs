using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
class ElementBuilder
{
    public string ElementName { get; set; }
    public string ElementValue { get; set; }
    public Dictionary<string, string> Atributes { get; set; }
    private string value { get; set; }

    public ElementBuilder(string elementName)
    {
        this.ElementName = elementName;
        this.Atributes = new Dictionary<string, string>();
    }

    public void AddAtribute(string name, string value)
    {
        //string pattern = @"<\w+\s*(.*?)>(.+>)*[\s]*<.+";
        //this.ElementName = Regex.Replace(this.ElementName, pattern, "<" + this.ElementValue + " $1 " + elementName +
        //    "=\"" + value + "\"" + ">" + "$2" + "</" + this.ElementValue + ">");
        this.Atributes.Add(name, value);
    }

    public void AddContent(string text)
    {
        //string pattern = @"<\w+\s*(.*?)>(.+>)*[\s]*<.+";
        //this.ElementName = Regex.Replace(this.ElementName, pattern, "<" + this.ElementValue + " $1" + ElementName +
        //    ">" + "$2" + text + "</" + this.ElementValue + ">");
        this.ElementValue += text;
    }

    public static string operator *(ElementBuilder ElementName, int time)
    {
        string result = "";
        for (int i = 0; i < time; i++)
        {
             result += ElementName.ToString();
        }
        return result;
    }


    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<" + this.ElementName);
        foreach (var attribute in this.Atributes)
        {
            builder.Append(" " + attribute.Key + "=\"" + attribute.Value + "\"");
        }
        builder.Append(">");
        builder.Append(this.ElementValue);
        builder.Append("</" + this.ElementName + ">");
        return builder.ToString();
    }
}

