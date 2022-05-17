//-----------------------------------------------------------------------
// <copyright file="Logger.cs" company="David Fedchuk, Gerson Eliu Sorto Flores, Lincoln Kaszynski, Sanaaia Okhlopkova, and Samuel Mace">
//     MIT License, 2022 (https://mit-license.org).
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System.Diagnostics;
    using System.Windows;

    /// <summary>
    /// Class that outputs information (GUI and console).
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Static method that outputs information to the screen in the form of a MessageBox.
        /// </summary>
        /// <param name="message">The message to be displayed to the user.</param>
        public static void Information(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            ConsoleInformation("MessageBox: " + message);
        }

        /// <summary>
        /// Static method that outputs error to the screen in the form of a MessageBox.
        /// </summary>
        /// <param name="message">The message to be displayed to the user.</param>
        public static void Error(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            ConsoleInformation("MessageBox: " + message);
        }

        /// <summary>
        /// Static method that outputs information to the console.
        /// </summary>
        /// <param name="message">The message to be displayed to the console.</param>
        public static void ConsoleInformation(string message)
        {
            Trace.WriteLine(message);
        }

        /// <summary>
        /// Static method that outputs information to the console without ending a line in the process.
        /// </summary>
        /// <param name="message">The message to be displayed to the console.</param>
        public static void ConsoleInformationForArray(string message)
        {
            Trace.Write(message);
        }
    }
}
