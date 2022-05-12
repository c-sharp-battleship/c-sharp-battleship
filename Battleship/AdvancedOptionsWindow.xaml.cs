using System;
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
    /// <summary>
    /// Interaction logic for AdvancedOptionsWindow.xaml
    /// </summary>
    public partial class AdvancedOptionsWindow : Window
    {
        private AdvancedOptions advancedOptions;

        public AdvancedOptionsWindow(ref AdvancedOptions p_advancedOptions)
        {
            InitializeComponent();

            this.advancedOptions = p_advancedOptions;
        }
    }
}
