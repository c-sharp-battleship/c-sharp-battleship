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
    class NewAttackGrid : UserControl
    {
        public const ushort NUM_ROWS = 10;
        public const ushort NUM_ROW_ENTRIES = 10;
        public List<List<Button>> Buttons;
        
        public NewAttackGrid(double width, double height, double pixelGridSize)
        {
            // Instantiate the two-dimensional button list.
            this.Buttons = new List<List<Button>>();
            for (int i = 0; i < NUM_ROWS; i++)
            {
                // For each row of buttons, instantiate a list of button entries.
                this.Buttons.Add(new List<Button>());

                for (int j = 0; j < NUM_ROW_ENTRIES; j++)
                {
                    // For each row entry, instantiate a new button object.
                    Button tempButton = new Button();

                    tempButton.Height = pixelGridSize;
                    tempButton.Width = pixelGridSize;
                    tempButton.Visibility = Visibility.Visible;

                    tempButton.Content = "X";

                    // Set the name of the button to the current index (plus 1 for the array offset).
                    tempButton.Name = "TR" + (i + 1).ToString() + "TD" + (j + 1).ToString();

                    // Add a click event handler to the current button index, passing the row and row entry to the eventhandler.
                    tempButton.Click += (sender, e) => GenericButtonClickEvent(sender, e, (i + 1), (j + 1));

                    this.AddChild(tempButton);
                    this.Buttons[i].Add(tempButton);
                }
            }
        }

        // Method that takes in the button ID that was pressed (the table row and entry).
        private void GenericButtonClickEvent(object sender, RoutedEventArgs e, int tr, int td)
        {
            Logger.Information("Button Row " + tr.ToString() + " Entry " + td.ToString() + " was presesed!");
        }
    }
}
