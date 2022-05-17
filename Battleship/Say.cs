//-----------------------------------------------------------------------
// <copyright file="Say.cs" company="David Fedchuk, Gerson Eliu Sorto Flores, Lincoln Kaszynski, Sanaaia Okhlopkova, and Samuel Mace">
//     MIT License, 2022 (https://mit-license.org).
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System.Diagnostics;
    using System.Windows;

    /// <summary>
    /// Interaction logic for Say.
    /// </summary>
    public class Say
    {
        /// <summary>
        /// Set a method that show a message box.
        /// </summary>
        /// <param name="say">The message.</param>
        public static void Show(string say)
        {
            MessageBox.Show(say, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Set a method that show a message in console.
        /// </summary>
        /// <param name="say">The message.</param>
        public static void ConsoleShow(string say)
        {
            Trace.WriteLine(say);
        }
    }
}
