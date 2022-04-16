//-----------------------------------------------------------------------
// <copyright file="SetWindow.xaml.cs" company="Team">
//     Company copyright tag.
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
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for SetWindow.xaml
    /// </summary>
    public partial class SetWindow : Window
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="SetWindow" /> class.
        /// </summary>
        public SetWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Performs when button is clicked.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param> 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Variables
            double gameBoardWidth; // Create a game board width game size
            double gameBoardHeight; // craete a game board height size
            double rowsQty; // Create a row qty check variable
            double colsQty; // create a column qty
            double mygridsquaresize; // size for each square in grid
            int inches = 96; // 1 inch to pixels
            double boardTolerance_H; // tolerance for board height
            boardTolerance_H = 15; // Add Board tolerance at load to display even number of squares
            int boardTolerance_V = 40; // tolerance for board width

            // Missing validation for row qty and colqty Please check!!!!!!!!!
            // Validate table grid input to be numeric only
            if ((MWtb_gridtablewidth.Text != string.Empty) && (RowQtyInputTxtbox.Text != string.Empty))
            {
                // Create a check for row qty and colqty!!!!!!!!!!!!!
                if (double.TryParse(MWtb_gridtablewidth.Text, out gameBoardWidth) && double.TryParse(RowQtyInputTxtbox.Text, out rowsQty)
                    && double.TryParse(MWtxt_gridheight.Text, out gameBoardHeight))
                {
                    // define grid square sizes for main squares
                    mygridsquaresize = gameBoardHeight / rowsQty; // each square measures this
                    colsQty = Convert.ToInt32(gameBoardWidth) / mygridsquaresize; // define the number of columns

                    // check if number of columns is divisible by two
                    if (colsQty % 2 != 0) 
                    {
                        colsQty++; // will add one square to make it even all the time
                    }

                    gameBoardWidth = colsQty * mygridsquaresize; // redefine the play board size

                    if (gameBoardWidth >= 4 && gameBoardWidth <= 13)
                    {
                        // Create instance of grid window
                        WindowCreateGrid mygridwindow = new WindowCreateGrid();
                        mygridwindow.Title = "GridScreen";
                        mygridwindow.Width = (gameBoardWidth * inches) + boardTolerance_H;
                        mygridwindow.Height = (gameBoardHeight * inches) + boardTolerance_V;

                        //// Attack grid
                        // Create the Grid without gridlines, elements will apply border as gridlines
                        Grid playerOneGrid = new Grid();
                        playerOneGrid.Width = gameBoardWidth / 2 * inches;
                        playerOneGrid.Height = gameBoardHeight * inches;
                        playerOneGrid.HorizontalAlignment = HorizontalAlignment.Left;
                        playerOneGrid.VerticalAlignment = VerticalAlignment.Top;

                        // PlayerOneGrid.ShowGridLines = true;

                        // Define PlayerOneGrid Columns, iterte new columns to user request
                        for (int gridcol = 0; gridcol < colsQty / 2; gridcol++)
                        {
                            ColumnDefinition colDef = new ColumnDefinition();
                            playerOneGrid.ColumnDefinitions.Add(colDef);
                        }

                        // Define PlayerOneGrid rows,iterate new rows to user request
                        for (int gridrow = 0; gridrow < rowsQty; gridrow++)
                        {
                            RowDefinition rowDef = new RowDefinition();
                            playerOneGrid.RowDefinitions.Add(rowDef);
                        }

                        // Add the TextBlock elements to the Grid Children collection 
                        int count = 1;

                        // iterate thru counter to set row location loader for this button
                        //// Rows Button loader 
                        for (int i = 0; i < rowsQty; i++) 
                        {
                            // iterate thru counter to set column nlocation loader for this button
                            //// Columns button loader

                            for (int j = 0; j < colsQty / 2; j++)
                            {
                                // will create a colored grid
                                if (MainGridChckbox.IsChecked == true)
                                {
                                    CustomButton myButton = new CustomButton(count, 1, "Button" + count.ToString());
                                    myButton.Content = count.ToString();
                                    Grid.SetColumn(myButton, j);
                                    Grid.SetRow(myButton, i);
                                    playerOneGrid.Children.Add(myButton); // Add This button to my grid location
                                }
                                else
                                {
                                    CustomButton myButton = new CustomButton(count, 1, "Button" + count.ToString());
                                    myButton.Background = Brushes.Transparent; // 1new
                                    myButton.BorderBrush = Brushes.White; // 2new
                                    myButton.BorderThickness = new Thickness(2); // 3new
                                    Grid.SetColumn(myButton, j);
                                    Grid.SetRow(myButton, i);
                                    playerOneGrid.Children.Add(myButton); // Add This button to my grid location
                                }

                                count++;
                            }
                        }

                        //// Attack grid
                        //// Defense grid grid

                        Grid playerTwoGrid = new Grid();
                        playerTwoGrid.Width = gameBoardWidth / 2 * inches;
                        playerTwoGrid.Height = gameBoardHeight * inches;
                        playerTwoGrid.HorizontalAlignment = HorizontalAlignment.Right;
                        playerTwoGrid.VerticalAlignment = VerticalAlignment.Top;
                        playerTwoGrid.ShowGridLines = true;

                        // Define PlayerTwoGrid Columns, iterte new columns to user request
                        for (int gridcol = 0; gridcol < colsQty / 2; gridcol++)
                        {
                            ColumnDefinition colDef = new ColumnDefinition();
                            playerTwoGrid.ColumnDefinitions.Add(colDef);
                        }

                        // Define PlayerTwoGrid rows,iterate new rows to user request
                        for (int gridrow = 0; gridrow < rowsQty; gridrow++)
                        {
                            RowDefinition rowDef = new RowDefinition();
                            playerTwoGrid.RowDefinitions.Add(rowDef);
                        }

                        // Add the TextBlock elements to the Grid Children collection 
                        int countOpponent = 1;
                        int reversemygrid = playerOneGrid.Children.Count;

                        // iterate thru counter to set row location loader for this button
                        //// Rows Button loader 
                        for (int i = 0; i < rowsQty; i++) 
                        {
                            // iterate thru counter to set column nlocation loader for this button
                            //// Columns button loader
                            for (int j = 0; j < colsQty / 2; j++)
                            {
                                //// will create a colored grid
                                if (MainGridChckbox.IsChecked == true)
                                {
                                    CustomButton myButton = new CustomButton(reversemygrid, 2, "Button" + reversemygrid.ToString());
                                    myButton.Content = reversemygrid.ToString();
                                    Grid.SetColumn(myButton, j);
                                    Grid.SetRow(myButton, i);
                                    playerTwoGrid.Children.Add(myButton); // Add This button to my grid location
                                }
                                else
                                {
                                    CustomButton myButton = new CustomButton(reversemygrid, 2, "Button" + reversemygrid.ToString());
                                    myButton.Name = "Button" + reversemygrid.ToString();
                                    myButton.Background = Brushes.Transparent; // 1new
                                    myButton.BorderBrush = Brushes.White; // 2new
                                    myButton.BorderThickness = new Thickness(2); // 3new
                                    Grid.SetColumn(myButton, j);
                                    Grid.SetRow(myButton, i);
                                    playerTwoGrid.Children.Add(myButton); // Add This button to my grid location
                                }

                                countOpponent++;
                                reversemygrid--;
                            }
                        }

                        // Add Exit Button to my grid window
                        Button mygridExitButton = new Button();
                        mygridExitButton.Click += new RoutedEventHandler(this.Button_Click);

                        // Add the Grid as the Content of the Parent Window Object
                        if (Radioplayer1.IsChecked == true)
                        {
                            mygridwindow.Content = playerOneGrid;
                        }

                        if (Radioplayer2.IsChecked == true)
                        {
                            mygridwindow.Content = playerTwoGrid;
                        }

                        mygridwindow.Show(); // show my window
                    }
                    else
                    {
                        MessageBox.Show("Board size can't be less than 4 or over 10 inches, Please try again", "No Data", MessageBoxButton.OK, MessageBoxImage.Information);
                        MWtb_gridtablewidth.Clear();
                        MWtb_gridtablewidth.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Input must be numeric value, Please try again", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                    MWtb_gridtablewidth.Clear();
                    MWtb_gridtablewidth.Focus();
                }
            }
            else
            {
                MessageBox.Show("Board size can't be zero, Please try again", "No Data", MessageBoxButton.OK, MessageBoxImage.Information);
                MWtb_gridtablewidth.Clear();
                MWtb_gridtablewidth.Focus();
            }
        }

        /// <summary>
        /// Performs the exit.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param> 
        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Performs the entering of the board width.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param> 
        private void MWtb_gridtablewidth_MouseEnter(object sender, MouseEventArgs e)
        {
            // Create the ToolTip and associate with the Form container.
            ToolTip boardWidthTip = new ToolTip();
            boardWidthTip.Content = "Enter Value In inches no greater than 10";
            MWtb_gridtablewidth.ToolTip = boardWidthTip;
        }
    }
}
