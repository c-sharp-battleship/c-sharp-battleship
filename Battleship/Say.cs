//-----------------------------------------------------------------------
// <copyright file="Say.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System.Diagnostics;
    using System.Windows;

    /// <summary>
    /// Interaction logic for Say
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
