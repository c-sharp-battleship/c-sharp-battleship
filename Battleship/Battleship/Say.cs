﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Battleship
{
    class Say
    {
        public void show(string Say)
        {
            MessageBox.Show(Say, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}