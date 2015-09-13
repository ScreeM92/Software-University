using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

class AnchorTagsInserter
{
	static void Main(string[] args)
	{   
		List<string> allLines = new List<string>();

		ArrayFiller(allLines);
		allLines.Sort();
		WriteToFile(allLines);
	}

	public static void ArrayFiller(List<string> allLines)
	{
		string path = "text.txt";
		StreamReader readFile = new StreamReader(path);

		using (readFile)
		{
			while (true)
			{
				string line = readFile.ReadLine();
				if (line == null)
				{
					break;
				}
				line = InsertIntoTags(line);
				allLines.Add(line);
			}
		}
	}

	public static void WriteToFile(List<string> allLines)
	{
		StreamWriter writeToFile = new StreamWriter("ouput.txt");

		using (writeToFile)
		{
			foreach (var line in allLines)
			{
				writeToFile.WriteLine(line);
			}
		}
	}

	public static string InsertIntoTags(string line)
	{
		string pattern = @"<a href="""" target=""_blank""></a>";
		string link = line.Substring(line.IndexOf("http"));
		string name = line.Substring(0, line.IndexOf(" -"));
		line = line.Remove(line.IndexOf("http"));
		line = line.Insert(line.IndexOf("- ") + 2, pattern);
		line = line.Insert(line.IndexOf(@"href=""") + 6, link);
		line = line.Insert(line.LastIndexOf("<"), link);
		return line;
	}
}
