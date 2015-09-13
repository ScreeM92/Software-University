namespace TravelAgency.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class CommandUtilities
    {
        public static string[] ParseCommandWithParameters(string commandLine)
        {
            if (commandLine == string.Empty)
            {
                return null;
            }

            int firstSpaceIndex = commandLine.IndexOf(' ');
            if (firstSpaceIndex == -1)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            string commandName = commandLine.Substring(0, firstSpaceIndex);
            string commandParametersString = commandLine.Substring(firstSpaceIndex + 1);

            string[] commandParts = GetCommandParameters(commandName, commandParametersString);
            return commandParts;
        }

        private static string[] GetCommandParameters(string commandName, string commandParametersString)
        {
            string[] parameters = commandParametersString.Split(
                new char[] { ';' },
                StringSplitOptions.RemoveEmptyEntries);
            string[] result = new string[parameters.Length + 1];
            result[0] = commandName;
            for (int i = 0; i < parameters.Length; i++)
            {
                result[i + 1] = parameters[i].Trim();
            }

            return result;
        }
    }
}
