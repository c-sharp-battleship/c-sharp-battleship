//-----------------------------------------------------------------------
// <copyright file="AttackGrid.xaml.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship.GUIComponents
{
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

    /// <summary>
    /// Interaction logic for AttackGrid.xaml
    /// </summary>
    public partial class AttackGrid : UserControl
    {
        /// <summary>
        /// The number of rows on the <see cref="AttackGrid"/>
        /// </summary>
        public const ushort NUMROWS = 10;

        /// <summary>
        /// The number of entries per <see cref="NUMROWS"/> on the <see cref="AttackGrid"/>
        /// </summary>
        public const ushort NUMROWENTRIES = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttackGrid" /> class.
        /// </summary>
        public AttackGrid()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Method that handles the click events for all of the buttons.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        /// <param name="tr">The table row ID that was clicked.</param>
        /// <param name="td">The entry within the <paramref name="tr"/> row that was clicked.</param>
        /// <param name="clickedButton">The button object that was clicked.</param>
        private void GenericButtonClickEvent(object sender, RoutedEventArgs e, int tr, int td, Button clickedButton)
        {
            Logger.Information("Button Row " + tr.ToString() + " Entry " + td.ToString() + " was pressed!");
            clickedButton.IsEnabled = false;
        }

        /// <summary>
        /// The click event for row 1, position 1.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR1TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 1, this.ButtonTR1TD1);
        }

        /// <summary>
        /// The click event for row 1, position 2.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR1TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 2, this.ButtonTR1TD2);
        }

        /// <summary>
        /// The click event for row 1, position 3.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR1TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 3, this.ButtonTR1TD3);
        }

        /// <summary>
        /// The click event for row 1, position 4.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR1TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 4, this.ButtonTR1TD4);
        }

        /// <summary>
        /// The click event for row 1, position 5.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR1TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 5, this.ButtonTR1TD5);
        }

        /// <summary>
        /// The click event for row 1, position 6.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR1TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 6, this.ButtonTR1TD6);
        }

        /// <summary>
        /// The click event for row 1, position 7.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR1TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 7, this.ButtonTR1TD7);
        }

        /// <summary>
        /// The click event for row 1, position 8.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR1TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 8, this.ButtonTR1TD8);
        }

        /// <summary>
        /// The click event for row 1, position 9.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR1TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 9, this.ButtonTR1TD9);
        }

        /// <summary>
        /// The click event for row 1, position 10.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR1TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 1, 10, this.ButtonTR1TD10);
        }

        /// <summary>
        /// The click event for row 2, position 1.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR2TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 1, this.ButtonTR2TD1);
        }

        /// <summary>
        /// The click event for row 2, position 2.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR2TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 2, this.ButtonTR2TD2);
        }

        /// <summary>
        /// The click event for row 2, position 3.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR2TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 3, this.ButtonTR2TD3);
        }

        /// <summary>
        /// The click event for row 2, position 4.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR2TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 4, this.ButtonTR2TD4);
        }

        /// <summary>
        /// The click event for row 2, position 5.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR2TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 5, this.ButtonTR2TD5);
        }

        /// <summary>
        /// The click event for row 2, position 6.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR2TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 6, this.ButtonTR2TD6);
        }

        /// <summary>
        /// The click event for row 2, position 7.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR2TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 7, this.ButtonTR2TD7);
        }

        /// <summary>
        /// The click event for row 2, position 8.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR2TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 8, this.ButtonTR2TD8);
        }

        /// <summary>
        /// The click event for row 2, position 9.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR2TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 9, this.ButtonTR2TD9);
        }

        /// <summary>
        /// The click event for row 2, position 10.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR2TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 2, 10, this.ButtonTR2TD10);
        }

        /// <summary>
        /// The click event for row 3, position 1.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR3TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 1, this.ButtonTR3TD1);
        }

        /// <summary>
        /// The click event for row 3, position 2.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR3TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 2, this.ButtonTR3TD2);
        }

        /// <summary>
        /// The click event for row 3, position 3.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR3TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 3, this.ButtonTR3TD3);
        }

        /// <summary>
        /// The click event for row 3, position 4.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR3TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 4, this.ButtonTR3TD4);
        }

        /// <summary>
        /// The click event for row 3, position 5.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR3TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 5, this.ButtonTR3TD5);
        }

        /// <summary>
        /// The click event for row 3, position 6.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR3TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 6, this.ButtonTR3TD6);
        }

        /// <summary>
        /// The click event for row 3, position 7.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR3TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 7, this.ButtonTR3TD7);
        }

        /// <summary>
        /// The click event for row 3, position 8.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR3TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 8, this.ButtonTR3TD8);
        }

        /// <summary>
        /// The click event for row 3, position 9.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR3TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 9, this.ButtonTR3TD9);
        }

        /// <summary>
        /// The click event for row 3, position 10.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR3TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 3, 10, this.ButtonTR3TD10);
        }

        /// <summary>
        /// The click event for row 4, position 1.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR4TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 1, this.ButtonTR4TD1);
        }

        /// <summary>
        /// The click event for row 4, position 2.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR4TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 2, this.ButtonTR4TD2);
        }

        /// <summary>
        /// The click event for row 4, position 3.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR4TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 3, this.ButtonTR4TD3);
        }

        /// <summary>
        /// The click event for row 4, position 4.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR4TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 4, this.ButtonTR4TD4);
        }

        /// <summary>
        /// The click event for row 4, position 5.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR4TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 5, this.ButtonTR4TD5);
        }

        /// <summary>
        /// The click event for row 4, position 6.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR4TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 6, this.ButtonTR4TD6);
        }

        /// <summary>
        /// The click event for row 4, position 7.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR4TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 7, this.ButtonTR4TD7);
        }

        /// <summary>
        /// The click event for row 4, position 8.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR4TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 8, this.ButtonTR4TD8);
        }

        /// <summary>
        /// The click event for row 4, position 9.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR4TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 9, this.ButtonTR4TD9);
        }

        /// <summary>
        /// The click event for row 4, position 10.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR4TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 4, 10, this.ButtonTR4TD10);
        }

        /// <summary>
        /// The click event for row 5, position 1.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR5TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 1, this.ButtonTR5TD1);
        }

        /// <summary>
        /// The click event for row 5, position 2.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR5TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 2, this.ButtonTR5TD2);
        }

        /// <summary>
        /// The click event for row 5, position 3.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR5TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 3, this.ButtonTR5TD3);
        }

        /// <summary>
        /// The click event for row 5, position 4.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR5TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 4, this.ButtonTR5TD4);
        }

        /// <summary>
        /// The click event for row 5, position 5.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR5TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 5, this.ButtonTR5TD5);
        }

        /// <summary>
        /// The click event for row 5, position 6.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR5TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 6, this.ButtonTR5TD6);
        }

        /// <summary>
        /// The click event for row 5, position 7.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR5TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 7, this.ButtonTR5TD7);
        }

        /// <summary>
        /// The click event for row 5, position 8.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR5TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 8, this.ButtonTR5TD8);
        }

        /// <summary>
        /// The click event for row 5, position 9.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR5TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 9, this.ButtonTR5TD9);
        }

        /// <summary>
        /// The click event for row 5, position 10.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR5TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 5, 10, this.ButtonTR5TD10);
        }

        /// <summary>
        /// The click event for row 6, position 1.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR6TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 1, this.ButtonTR6TD1);
        }

        /// <summary>
        /// The click event for row 6, position 2.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR6TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 2, this.ButtonTR6TD2);
        }

        /// <summary>
        /// The click event for row 6, position 3.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR6TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 3, this.ButtonTR6TD3);
        }

        /// <summary>
        /// The click event for row 6, position 4.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR6TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 4, this.ButtonTR6TD4);
        }

        /// <summary>
        /// The click event for row 6, position 5.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR6TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 5, this.ButtonTR6TD5);
        }

        /// <summary>
        /// The click event for row 6, position 6.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR6TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 6, this.ButtonTR6TD6);
        }

        /// <summary>
        /// The click event for row 6, position 7.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR6TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 7, this.ButtonTR6TD7);
        }

        /// <summary>
        /// The click event for row 6, position 8.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR6TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 8, this.ButtonTR6TD8);
        }

        /// <summary>
        /// The click event for row 6, position 9.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR6TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 9, this.ButtonTR6TD9);
        }

        /// <summary>
        /// The click event for row 6, position 10.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR6TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 6, 10, this.ButtonTR6TD10);
        }

        /// <summary>
        /// The click event for row 7, position 1.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR7TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 1, this.ButtonTR7TD1);
        }

        /// <summary>
        /// The click event for row 7, position 2.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR7TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 2, this.ButtonTR7TD2);
        }

        /// <summary>
        /// The click event for row 7, position 3.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR7TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 3, this.ButtonTR7TD3);
        }

        /// <summary>
        /// The click event for row 7, position 4.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR7TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 4, this.ButtonTR7TD4);
        }

        /// <summary>
        /// The click event for row 7, position 5.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR7TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 5, this.ButtonTR7TD5);
        }

        /// <summary>
        /// The click event for row 7, position 6.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR7TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 6, this.ButtonTR7TD6);
        }

        /// <summary>
        /// The click event for row 7, position 7.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR7TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 7, this.ButtonTR7TD7);
        }

        /// <summary>
        /// The click event for row 7, position 8.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR7TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 8, this.ButtonTR7TD8);
        }

        /// <summary>
        /// The click event for row 7, position 9.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR7TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 9, this.ButtonTR7TD9);
        }

        /// <summary>
        /// The click event for row 7, position 10.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR7TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 7, 10, this.ButtonTR7TD10);
        }

        /// <summary>
        /// The click event for row 8, position 1.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR8TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 1, this.ButtonTR8TD1);
        }

        /// <summary>
        /// The click event for row 8, position 2.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR8TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 2, this.ButtonTR8TD2);
        }

        /// <summary>
        /// The click event for row 8, position 3.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR8TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 3, this.ButtonTR8TD3);
        }

        /// <summary>
        /// The click event for row 8, position 4.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR8TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 4, this.ButtonTR8TD4);
        }

        /// <summary>
        /// The click event for row 8, position 5.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR8TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 5, this.ButtonTR8TD5);
        }

        /// <summary>
        /// The click event for row 8, position 6.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR8TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 6, this.ButtonTR8TD6);
        }

        /// <summary>
        /// The click event for row 8, position 7.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR8TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 7, this.ButtonTR8TD7);
        }

        /// <summary>
        /// The click event for row 8, position 8.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR8TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 8, this.ButtonTR8TD8);
        }

        /// <summary>
        /// The click event for row 8, position 9.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR8TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 9, this.ButtonTR8TD9);
        }

        /// <summary>
        /// The click event for row 8, position 10.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR8TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 8, 10, this.ButtonTR8TD10);
        }

        /// <summary>
        /// The click event for row 9, position 1.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR9TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 1, this.ButtonTR9TD1);
        }

        /// <summary>
        /// The click event for row 9, position 2.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR9TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 2, this.ButtonTR9TD2);
        }

        /// <summary>
        /// The click event for row 9, position 3.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR9TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 3, this.ButtonTR9TD3);
        }

        /// <summary>
        /// The click event for row 9, position 4.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR9TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 4, this.ButtonTR9TD4);
        }

        /// <summary>
        /// The click event for row 9, position 5.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR9TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 5, this.ButtonTR9TD5);
        }

        /// <summary>
        /// The click event for row 9, position 6.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR9TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 6, this.ButtonTR9TD6);
        }

        /// <summary>
        /// The click event for row 9, position 7.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR9TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 7, this.ButtonTR9TD7);
        }

        /// <summary>
        /// The click event for row 9, position 8.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR9TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 8, this.ButtonTR9TD8);
        }

        /// <summary>
        /// The click event for row 9, position 9.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR9TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 9, this.ButtonTR9TD9);
        }

        /// <summary>
        /// The click event for row 9, position 10.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR9TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 9, 10, this.ButtonTR9TD10);
        }

        /// <summary>
        /// The click event for row 10, position 1.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR10TD1_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 1, this.ButtonTR10TD1);
        }

        /// <summary>
        /// The click event for row 10, position 2.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR10TD2_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 2, this.ButtonTR10TD2);
        }

        /// <summary>
        /// The click event for row 10, position 3.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR10TD3_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 3, this.ButtonTR10TD3);
        }

        /// <summary>
        /// The click event for row 10, position 4.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR10TD4_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 4, this.ButtonTR10TD4);
        }

        /// <summary>
        /// The click event for row 10, position 5.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR10TD5_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 5, this.ButtonTR10TD5);
        }

        /// <summary>
        /// The click event for row 10, position 6.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR10TD6_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 6, this.ButtonTR10TD6);
        }

        /// <summary>
        /// The click event for row 10, position 7.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR10TD7_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 7, this.ButtonTR10TD7);
        }

        /// <summary>
        /// The click event for row 10, position 8.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR10TD8_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 8, this.ButtonTR10TD8);
        }

        /// <summary>
        /// The click event for row 10, position 9.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR10TD9_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 9, this.ButtonTR10TD9);
        }

        /// <summary>
        /// The click event for row 10, position 10.
        /// </summary>
        /// <param name="sender">The object that initialized the event.</param>
        /// <param name="e">The arguments passed to the event handler.</param>
        private void ButtonTR10TD10_Click(object sender, RoutedEventArgs e)
        {
            this.GenericButtonClickEvent(sender, e, 10, 10, this.ButtonTR10TD10);
        }
    }
}
