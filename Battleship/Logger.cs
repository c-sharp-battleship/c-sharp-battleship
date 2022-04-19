using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Battleship
{
    public class Logger
    {
        public static void Information(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
