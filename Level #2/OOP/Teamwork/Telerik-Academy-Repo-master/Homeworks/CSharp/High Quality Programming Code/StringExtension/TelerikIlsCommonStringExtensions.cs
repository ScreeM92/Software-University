/// <summary>
/// .NET Common Types Extensions
/// </summary>
namespace Telerik.Ils.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using log4net;

    /// <summary>
    /// Extend the String class by adding converting methods
    /// </summary>
    public static class TelerikIlsCommonStringExtensions
    {
        private static readonly ILog debug = LogManager.GetLogger("Debug");
        private static readonly ILog exceptions = LogManager.GetLogger("Exceptions");
        

        /// <summary> 
        /// By given string value create MD5 Hash Table than converts it back to string.
        /// </summary>
        /// <param name="input">A string value to convert</param>
        /// <returns>MD5 Hash Table as String value</returns>
        public static string ToMd5Hash(this string input)
        {
            debug.Info("");
            exceptions.Info("");
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string .
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Converts given string to a Boolean value
        /// </summary>
        /// <param name="input">A string containing the bool value to convert</param>
        /// <returns>'True' if <param name="input"/> is contained in the method's string array and 'False' if else</returns>
        public static bool ToBoolean(this string input)
        {   
            //Create a new string array to keep the different "true" values
            var stringTrueValues = new string[] { "true", "ok", "yes", "1", "да" };
         
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts given string to a Int16 (16 bit signed integer) value
        /// </summary>
        /// <param name="input">A string containing the number to convert</param>
        /// <returns>A 16 bit signed integer that is equivalent to <paramref name="input"/>,
        /// or zero if <paramref name="input"/> is null.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts given string to a Int32 (32 bit signed integer) value
        /// </summary>
        /// <param name="input">A string containing the number to convert</param>
        /// <returns>A 32 bit signed integer that is equivalent to <paramref name="input"/>,
        /// or zero if <paramref name="input"/> is null.</returns>
        public static int ToInteger(this string input)
        {   
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts given string to a Int64 (64 bit signed integer) value
        /// </summary>
        /// <param name="input">A string containing the number to convert</param>
        /// <returns>A 64 bit signed integer that is equivalent to <paramref name="input"/>,
        /// or zero if <paramref name="input"/> is null.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts given string to a DateTime value
        /// </summary>
        /// <param name="input">A string containing the DateTime to convert</param>
        /// <returns>A DateTime that is equivalent to <paramref name="input"/>,
        /// or computer's initial date and time if <paramref name="input"/> is null.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitilize the first letter of given string
        /// </summary>
        /// <param name="input">A string value</param>
        /// <returns>A string with captilize first character if possible</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            //Returns the first char from the input(input[0]) capitalized and concatenated with the rest of the input 
            //if the string is not empty, otherwise returns the same string
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Gets the string between two strings in given string
        /// </summary>
        /// <param name="input">A string value containing text</param>
        /// <param name="startString">A string value containing part of <param name="input"/></param>
        /// <param name="endString">A string value containing part of <param name="input"/></param>
        /// <returns>Substring of <param name="input"/></returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Convert the letters in given string in cyrillic to their latin representations
        /// </summary>
        /// <param name="input">A string value containing string in latin</param>
        /// <returns>A string value in cyrillic</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                    {
                        "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                        "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                    };

            var latinRepresentationsOfBulgarianLetters = new[]
                    {
                        "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                        "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                        "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                    };

            //Iterate through the array with the bulgarian letters and replace every occurance of cyrillic letter
            //in the input string with it's corresponding latin representation
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Convert the letters in given string in latin to their cyrillic representations
        /// </summary>
        /// <param name="input">A string value containing string in cyrillic</param>
        /// <returns>A string value in latin</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                    {
                        "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                        "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                    };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                    {
                        "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                        "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                        "в", "ь", "ъ", "з"
                    };

            //Iterate through the array with the bulgarian letters and replace every occurance of latin letter
            //in the input string with it's corresponding cyrillic representation
            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Convert given user name as string to valid user name - remove bad characters from the string
        /// </summary>
        /// <param name="input">User name as string value to be validated</param>
        /// <returns>Valid user name as string (removed bad charactes)</returns>
        public static string ToValidUsername(this string input)
        {
            //If the input is not in latin letters, convert it, than
            //remove symbols different than letters, numbers, '_', '\', '.' and all empty spaces
            //than return the result
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Convert given file name as string to valid file name - remove bad characters from the string
        /// </summary>
        /// <param name="input">File name as string value to be validated</param>
        /// <returns>Valid file name as string (removed bad charactes)</returns>
        public static string ToValidLatinFileName(this string input)
        {
            //If the input is not in latin letters, convert it and remove empty spaces, and '-', than
            //remove symbols different than letters, numbers, '_', '\', '.' and all empty spaces
            //than return the result
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Gets first few characters of given string
        /// </summary>
        /// <param name="input">A string value to take first few characters from</param>
        /// <param name="charsCount">A signed integer value for the number of characters</param>
        /// <returns>String value with the wanted substring</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Gets file extension by given file name as string
        /// </summary>
        /// <param name="fileName">A string value containing the file name</param>
        /// <returns>The file extension as string value</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            //Split the file name by dots and if the size of the obtained array is bigger than 1
            //return the last element
            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Converts given file extension as string to a content type also as string
        /// </summary>
        /// <param name="fileExtension">A string value containing file extension</param>
        /// <returns>String containing content type</returns>
        public static string ToContentType(this string fileExtension)
        {
            //Checks if the file extension is contained in the collection (dictionary) of content types.
            //If so get the wanted content type, otherwise return default value
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };

            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Copies the characters ASCII codes of given string in byte numbers array
        /// </summary>
        /// <param name="input">A string containing the characters to convert</param>
        /// <returns>Array of byte numbers</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
