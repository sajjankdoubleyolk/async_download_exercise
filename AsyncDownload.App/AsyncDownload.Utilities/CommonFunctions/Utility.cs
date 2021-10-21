using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AsyncDownload.Utilities.CommonFunctions
{
	/// <summary>
	/// Utility function class for common functions of the application.
	/// </summary>
	public static class Utility
	{

        /// <summary>
        /// Print message to the user screen.
        /// </summary>
        /// <param name="message">Custom message for user.</param>
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Create a random alphanumeric string.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// This method is used to validate the string for phone and fax number
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool CheckPhoneFaxNumber(string value)
        {
            string s = @"^[\d\-\+]*$";
            Regex rg = new Regex(s);
            if (value != null)
            {
                return rg.IsMatch(value);
            }
            else
                return false;
        }
    }
}
