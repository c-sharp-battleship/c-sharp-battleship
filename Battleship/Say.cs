//-----------------------------------------------------------------------
// <copyright file="Say.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

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
