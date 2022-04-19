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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Battleship.GUIComponents
{
    /// <summary>
    /// Interaction logic for AttackGridUserControl.xaml
    /// </summary>
    public partial class AttackGridUserControl : UserControl
    {
        public const ushort NUM_ROWS = 10;
        public const ushort NUM_ROW_ENTRIES = 10;

        public AttackGridUserControl()
        {
            this.InitializeComponent();
        }

        // Method that takes in the button ID that was pressed (the table row and entry).
        private void GenericButtonClickEvent(object sender, RoutedEventArgs e, int tr, int td, Button clickedButton)
        {
            Logger.Information("Button Row " + tr.ToString() + " Entry " + td.ToString() + " was pressed!");
            clickedButton.IsEnabled = false;
        }

        private void ButtonTR1TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 1, this.ButtonTR1TD1);
        }

        private void ButtonTR1TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 2, this.ButtonTR1TD2);
        }

        private void ButtonTR1TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 3, this.ButtonTR1TD3);
        }

        private void ButtonTR1TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 4, this.ButtonTR1TD4);
        }

        private void ButtonTR1TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 5, this.ButtonTR1TD5);
        }

        private void ButtonTR1TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 6, this.ButtonTR1TD6);
        }

        private void ButtonTR1TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 7, this.ButtonTR1TD7);
        }

        private void ButtonTR1TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 8, this.ButtonTR1TD8);
        }

        private void ButtonTR1TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 9, this.ButtonTR1TD9);
        }

        private void ButtonTR1TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 10, this.ButtonTR1TD10);
        }

        private void ButtonTR2TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 1, this.ButtonTR2TD1);
        }

        private void ButtonTR2TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 2, this.ButtonTR2TD2);
        }

        private void ButtonTR2TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 3, this.ButtonTR2TD3);
        }

        private void ButtonTR2TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 4, this.ButtonTR2TD4);
        }

        private void ButtonTR2TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 5, this.ButtonTR2TD5);
        }

        private void ButtonTR2TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 6, this.ButtonTR2TD6);
        }

        private void ButtonTR2TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 7, this.ButtonTR2TD7);
        }

        private void ButtonTR2TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 8, this.ButtonTR2TD8);
        }

        private void ButtonTR2TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 9, this.ButtonTR2TD9);
        }

        private void ButtonTR2TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 10, this.ButtonTR2TD10);
        }

        private void ButtonTR3TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 1, this.ButtonTR3TD1);
        }

        private void ButtonTR3TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 2, this.ButtonTR3TD2);
        }

        private void ButtonTR3TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 3, this.ButtonTR3TD3);
        }

        private void ButtonTR3TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 4, this.ButtonTR3TD4);
        }

        private void ButtonTR3TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 5, this.ButtonTR3TD5);
        }

        private void ButtonTR3TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 6, this.ButtonTR3TD6);
        }

        private void ButtonTR3TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 7, this.ButtonTR3TD7);
        }

        private void ButtonTR3TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 8, this.ButtonTR3TD8);
        }

        private void ButtonTR3TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 9, this.ButtonTR3TD9);
        }

        private void ButtonTR3TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 10, this.ButtonTR3TD10);
        }

        private void ButtonTR4TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 1, this.ButtonTR4TD1);
        }

        private void ButtonTR4TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 2, this.ButtonTR4TD2);
        }

        private void ButtonTR4TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 3, this.ButtonTR4TD3);
        }

        private void ButtonTR4TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 4, this.ButtonTR4TD4);
        }

        private void ButtonTR4TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 5, this.ButtonTR4TD5);
        }

        private void ButtonTR4TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 6, this.ButtonTR4TD6);
        }

        private void ButtonTR4TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 7, this.ButtonTR4TD7);
        }

        private void ButtonTR4TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 8, this.ButtonTR4TD8);
        }

        private void ButtonTR4TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 9, this.ButtonTR4TD9);
        }

        private void ButtonTR4TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 10, this.ButtonTR4TD10);
        }

        private void ButtonTR5TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 1, this.ButtonTR5TD1);
        }

        private void ButtonTR5TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 2, this.ButtonTR5TD2);
        }

        private void ButtonTR5TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 3, this.ButtonTR5TD3);
        }

        private void ButtonTR5TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 4, this.ButtonTR5TD4);
        }

        private void ButtonTR5TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 5, this.ButtonTR5TD5);
        }

        private void ButtonTR5TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 6, this.ButtonTR5TD6);
        }

        private void ButtonTR5TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 7, this.ButtonTR5TD7);
        }

        private void ButtonTR5TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 8, this.ButtonTR5TD8);
        }

        private void ButtonTR5TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 9, this.ButtonTR5TD9);
        }

        private void ButtonTR5TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 10, this.ButtonTR5TD10);
        }

        private void ButtonTR6TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 1, this.ButtonTR6TD1);
        }

        private void ButtonTR6TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 2, this.ButtonTR6TD2);
        }

        private void ButtonTR6TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 3, this.ButtonTR6TD3);
        }

        private void ButtonTR6TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 4, this.ButtonTR6TD4);
        }

        private void ButtonTR6TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 5, this.ButtonTR6TD5);
        }

        private void ButtonTR6TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 6, this.ButtonTR6TD6);
        }

        private void ButtonTR6TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 7, this.ButtonTR6TD7);
        }

        private void ButtonTR6TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 8, this.ButtonTR6TD8);
        }

        private void ButtonTR6TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 9, this.ButtonTR6TD9);
        }

        private void ButtonTR6TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 10, this.ButtonTR6TD10);
        }

        private void ButtonTR7TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 1, this.ButtonTR7TD1);
        }

        private void ButtonTR7TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 2, this.ButtonTR7TD2);
        }

        private void ButtonTR7TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 3, this.ButtonTR7TD3);
        }

        private void ButtonTR7TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 4, this.ButtonTR7TD4);
        }

        private void ButtonTR7TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 5, this.ButtonTR7TD5);
        }

        private void ButtonTR7TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 6, this.ButtonTR7TD6);
        }

        private void ButtonTR7TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 7, this.ButtonTR7TD7);
        }

        private void ButtonTR7TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 8, this.ButtonTR7TD8);
        }

        private void ButtonTR7TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 9, this.ButtonTR7TD9);
        }

        private void ButtonTR7TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 10, this.ButtonTR7TD10);
        }

        private void ButtonTR8TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 1, this.ButtonTR8TD1);
        }

        private void ButtonTR8TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 2, this.ButtonTR8TD2);
        }

        private void ButtonTR8TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 3, this.ButtonTR8TD3);
        }

        private void ButtonTR8TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 4, this.ButtonTR8TD4);
        }

        private void ButtonTR8TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 5, this.ButtonTR8TD5);
        }

        private void ButtonTR8TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 6, this.ButtonTR8TD6);
        }

        private void ButtonTR8TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 7, this.ButtonTR8TD7);
        }

        private void ButtonTR8TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 8, this.ButtonTR8TD8);
        }

        private void ButtonTR8TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 9, this.ButtonTR8TD9);
        }

        private void ButtonTR8TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 10, this.ButtonTR8TD10);
        }

        private void ButtonTR9TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 1, this.ButtonTR9TD1);
        }

        private void ButtonTR9TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 2, this.ButtonTR9TD2);
        }

        private void ButtonTR9TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 3, this.ButtonTR9TD3);
        }

        private void ButtonTR9TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 4, this.ButtonTR9TD4);
        }

        private void ButtonTR9TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 5, this.ButtonTR9TD5);
        }

        private void ButtonTR9TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 6, this.ButtonTR9TD6);
        }

        private void ButtonTR9TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 7, this.ButtonTR9TD7);
        }

        private void ButtonTR9TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 8, this.ButtonTR9TD8);
        }

        private void ButtonTR9TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 9, this.ButtonTR9TD9);
        }

        private void ButtonTR9TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 10, this.ButtonTR9TD10);
        }

        private void ButtonTR10TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 1, this.ButtonTR10TD1);
        }

        private void ButtonTR10TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 2, this.ButtonTR10TD2);
        }

        private void ButtonTR10TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 3, this.ButtonTR10TD3);
        }

        private void ButtonTR10TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 4, this.ButtonTR10TD4);
        }

        private void ButtonTR10TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 5, this.ButtonTR10TD5);
        }

        private void ButtonTR10TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 6, this.ButtonTR10TD6);
        }

        private void ButtonTR10TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 7, this.ButtonTR10TD7);
        }

        private void ButtonTR10TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 8, this.ButtonTR10TD8);
        }

        private void ButtonTR10TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 9, this.ButtonTR10TD9);
        }

        private void ButtonTR10TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 10, this.ButtonTR10TD10);
        }
    }
}
