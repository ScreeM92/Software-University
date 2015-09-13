namespace StringEditor
{
    using System;
    using Wintellect.PowerCollections;

    public class StringEditor
    {
        private const string SuccessMessage = "=> OK";
        private const string ErrorMessage = "=> ERROR";
        private const string Menu =
            "1. APPEND {some_string}\n" +
            "2. INSERT {some_string} {position}\n" +
            "3. DELETE {start_index} {count}\n" +
            "4. REPLACE {start_index} {count} {some_string}\n" +
            "5. PRINT\n" +
            "6. END";

        private static readonly string Delimiter = new string('-', 70);
        private static BigList<char> data;

        public static void Main()
        {
            Console.WriteLine(Menu);
            Console.WriteLine(Delimiter);

            data = new BigList<char>();
            var line = Console.ReadLine().Trim();

            while (line.ToLower() != "end")
            {
                try
                {
                    var command = line;
                    var parameters = string.Empty;
                    var delimiterIndex = line.IndexOf(' ');

                    if (delimiterIndex != -1)
                    {
                        command = line.Substring(0, delimiterIndex);
                        parameters = line.Substring(delimiterIndex, line.Length - delimiterIndex).Trim();
                    }

                    var result = ParseCommand(command, parameters);
                    Console.WriteLine("{0}\n{1}", result, Delimiter);
                   
                }
                catch (Exception)
                {
                    Console.WriteLine("{0}\n{1}", ErrorMessage, Delimiter);
                }

                line = Console.ReadLine().Trim();
            }
        }

        private static string ParseCommand(string command, string parameters)
        {
            string result;

            switch (command.ToLower())
            {
                case "append":
                    result = ProcessAppendCommand(parameters);
                    break;

                case "insert":
                    result = ProcessInsertCommand(parameters);
                    break;

                case "delete":
                    result = ProcessDeleteCommand(parameters);
                    break;

                case "replace":
                    result = ProcessReplaceCommand(parameters);
                    break;

                case "print":
                    result = ProcessPrintCommand();
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return result;
        }

        private static string[] ParseParameters(string parametersLine)
        {
            var parameters = parametersLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return parameters;
        }

        private static string ProcessAppendCommand(string parameter)
        {
            data.AddRange(parameter.ToCharArray());

            return SuccessMessage;
        }

        private static string ProcessInsertCommand(string parametersString)
        {
            var parameters = ParseParameters(parametersString);
            var insertData = parameters[0].ToCharArray();
            var possition = int.Parse(parameters[1]);
            
            if (possition > data.Count || possition < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            data.InsertRange(possition, insertData);
            
            return SuccessMessage;
        }

        private static string ProcessDeleteCommand(string parametersString)
        {
            var parameters = ParseParameters(parametersString);
            var startIndex = int.Parse(parameters[0]);
            var count = int.Parse(parameters[1]);

            if (startIndex < 0 || startIndex + count > data.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            data.RemoveRange(startIndex, count);

            return SuccessMessage;
        }

        private static string ProcessReplaceCommand(string parametersString)
        {
            var parameters = ParseParameters(parametersString);
            var startPossition = int.Parse(parameters[0]);
            var replaceCount = int.Parse(parameters[1]);
            var replaceString = parameters[2].ToCharArray();

            if (startPossition < 0 || startPossition + replaceCount > data.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            data.RemoveRange(startPossition, replaceCount);
            data.InsertRange(startPossition, replaceString);

            return SuccessMessage;
        }

        private static string ProcessPrintCommand()
        {
            return "=> " + string.Join("", data);
        }
    }
}