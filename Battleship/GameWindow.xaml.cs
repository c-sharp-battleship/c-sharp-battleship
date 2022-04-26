using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private bool ScreenPlayerOne_ = true;
        
        public double Cellsize = 25;
        public int RowRep = 10;
        
        public List<GridCell> PlayersCellRecords;

        private bool isLocked = false;
        private bool isLocked2 = false;

        private Player Player_1;
        private Player Player_2;

        private Canvas PlayerWindow_1;
        private Canvas PlayerWindow_2;

        /// <summary>
        /// initiallize the game
        /// </summary>
        public GameWindow()
        {
            this.PlayersCellRecords = new List<GridCell>();

            InitializeComponent();

            this.isLocked = false;
            this.isLocked2 = false;
        }

        public void StartGame()
        {
            //start player one label visible
            PlayerOnelabel.Visibility = Visibility.Visible;
            PlayerTwolabel.Visibility = Visibility.Hidden;

            //Create Players with their cells and their ships and grids colors
            // 1 = Black,2=dark blue,3=magenta,4=lightseagreen,5=purple,6=white,standard cadet blue
            this.Player_1 = new Player(1, "PlayerOne", Cellsize, RowRep, 1, 3);
            this.Player_2 = new Player(2, "PlayerOne", Cellsize, RowRep, 3, 6);

            //Create two Canvas to place the player elements on them 
            this.PlayerWindow_1 = new Canvas();
            this.PlayerWindow_1.HorizontalAlignment = HorizontalAlignment.Left;
            this.PlayerWindow_1.VerticalAlignment = VerticalAlignment.Center;
            this.PlayerWindow_1.Uid = "Player1Canvas";
            this.PlayerWindow_1.Width = (Cellsize * RowRep)*2;

            this.PlayerWindow_2 = new Canvas();
            this.PlayerWindow_2.HorizontalAlignment = HorizontalAlignment.Left;
            this.PlayerWindow_2.VerticalAlignment = VerticalAlignment.Center;
            this.PlayerWindow_2.Uid = "Player2Canvas";
            this.PlayerWindow_2.Width = (Cellsize * RowRep) * 2;
            this.PlayerWindow_2.Visibility = Visibility.Hidden;// load this canvas hidden for player 2

            //////Offense buttons for player one actions
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Load all cells from player one to the player one canvas
            foreach (GridCell Player_1_Offense_button in this.Player_1.Playergridsquarecollection)
            {
               PlayersCellRecords.Add(Player_1_Offense_button);

                ///add a click event for all cells in Player 1 grid only if the button is attack type
                if (Player_1_Offense_button.OffenseButton == true)
                {
                    //add click event
                    
                    Player_1_Offense_button.Click += new RoutedEventHandler(button_Click);//base
                    void button_Click(object sender, System.EventArgs e)
                    {
                        //go check the list of buttons for player two and change the status for them
                        foreach (GridCell Player_2_deffense_button in this.Player_2.Playergridsquarecollection)
                        {
                            // turn off buttons on the enemy grid(player two left side)only if it is a defense button
                            if (Player_1_Offense_button.Uid == Player_2_deffense_button.Uid && Player_2_deffense_button.OffenseButton == false)
                            {
                                //make changes to player two grid
                                Player_2_deffense_button.Background = Brushes.Red;
                                Player_2_deffense_button.Content = "X";
                                Player_2_deffense_button.Stricked_ = 1;
                                Player_2_deffense_button.AllowDrop = false;

                                //make changes to player one grid
                                Player_1_Offense_button.Visibility = Visibility.Hidden;
                            }
                        }
                        //Swicth windows between players 
                        SwitchPlayerWindows();
                    }
                }
                else  ///add the drag over event for when ships are dragged over the cells only if the cell is deffense type
                {
                    //Create a method when an object is drag over this left button
                    Player_1_Offense_button.DragOver += new DragEventHandler(Onbuttondragover);
                    void Onbuttondragover(object sender, DragEventArgs e)
                    {
                        // find the sender uid extracting the date of the event
                        string MyWarshipUid = e.Data.GetData(DataFormats.StringFormat).ToString();

                        //iterate thru the collection of ships to find the sender element with matching uid
                        foreach (Ship ship in this.Player_1.Playershipcollection)
                        {
                            //if the sender element uid matches then this is my element, then move it with the mouse
                            if (MyWarshipUid == ship.Uid)
                            {
                                Point GrabPos = e.GetPosition(this.PlayerWindow_1);//find the position of the mouse compared to the canvas for player one
                                double ShipmaxX = (this.PlayerWindow_1.Width/2)-ship.Width+ Cellsize;
                                double ShipmaxY = (this.PlayerWindow_1.Width)/2-ship.Height+ Cellsize;
                                 if(GrabPos.X < ShipmaxX && GrabPos.Y < ShipmaxY)
                                 {
                                   Canvas.SetTop(ship, Player_1_Offense_button.Top_Comp_ParentTop);
                                    ship.Top_Comp_ParentTop = Player_1_Offense_button.Top_Comp_ParentTop;
                                   Canvas.SetLeft(ship, Player_1_Offense_button.Left_Comp_ParentLeft);
                                    ship.Left_Comp_ParentLeft = Player_1_Offense_button.Left_Comp_ParentLeft;

                                    Coordinate shipStartCoords = this.ConvertCanvasCoordinatesToGridCoordinates(GrabPos.X, GrabPos.Y);
                                    Coordinate shipEndCoords = this.ConvertCanvasCoordinatesToGridCoordinates(GrabPos.X, GrabPos.Y);


                                    if (ship.h_direction == true)
                                    {
                                        shipEndCoords.XCoordinate += (short)((ship.Width / Cellsize) - 1);
                                    }
                                    else if (ship.h_direction == false)
                                    {
                                        shipEndCoords.YCoordinate += (short)((ship.Height / Cellsize) - 1);
                                    }

                                    UpdateShipCoords(ship, shipStartCoords, shipEndCoords);
                                }
                            }
                        }
                    }
                }
                //Add player 1 cells to the window grid
                this.PlayerWindow_1.Children.Add(Player_1_Offense_button);
            }

            ///Ships for player one actions
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Load all ships from player one to the player one canvas
            
                foreach (Ship ship_1 in this.Player_1.Playershipcollection)
                {
                    //create a move move event for player 1 ships to attacch the rectangle to the mouse
                    ship_1.MouseMove += new MouseEventHandler(Warship_MouseMove);
                    ship_1.MouseRightButtonDown += new MouseButtonEventHandler(Warship_MouseRightButtonDown);

                    void Warship_MouseMove(object sender, MouseEventArgs e)
                    {
                        if (isLocked == false)
                        {
                            if (e.LeftButton == MouseButtonState.Pressed)
                            {
                            string ObjectUniqueID = ship_1.Uid;
                            Point GrabPos = e.GetPosition(ship_1);
                            Canvas.SetTop(ship_1, GrabPos.Y);
                            Canvas.SetLeft(ship_1, GrabPos.X);
                            DragDrop.DoDragDrop(ship_1, ObjectUniqueID, DragDropEffects.Move);
                            }
                        }
                    }

                    //Rotate ships for player one with rigth click(refer to ship class constructor)
                    void Warship_MouseRightButtonDown(object sender, System.EventArgs e)
                    {
                        if (isLocked == false)
                        {
                           if (ship_1.h_direction == true)
                           {
                              double ShipmaxY = (this.PlayerWindow_1.Width) / 2 - (Cellsize*2);
                              double ShipmaxX = (this.PlayerWindow_1.Width / 2);
                              if (ship_1.Top_Comp_ParentTop < ShipmaxY && ship_1.Left_Comp_ParentLeft < ShipmaxX)
                              {
                                ship_1.Rotateship(true);
                              }
                           }
                           else 
                           {
                              double ShipmaxY = (this.PlayerWindow_1.Width) / 2;
                              double ShipmaxX = (this.PlayerWindow_1.Width / 2) - (Cellsize * 2);
                              if (ship_1.Top_Comp_ParentTop < ShipmaxY && ship_1.Left_Comp_ParentLeft < ShipmaxX)
                              {
                                ship_1.Rotateship(true);
                              }
                           }
                        }
                    }

                    //Add player 1 Ships to the window grid
                    this.PlayerWindow_1.Children.Add(ship_1);
                }
            

            ///offense buttons for player two actions 
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Load all cells from player two to the player two canvas
            foreach (GridCell Player_2_Offense_button in this.Player_2.Playergridsquarecollection)
            {
                PlayersCellRecords.Add(Player_2_Offense_button);

                ///add a click event for all cells in Player 1 grid only if the button is attack type
                if (Player_2_Offense_button.OffenseButton == true)
                {
                    //add click event
                    Player_2_Offense_button.Click += new RoutedEventHandler(button_Click);//base
                    void button_Click(object sender, System.EventArgs e)
                    {
                        //go check the list of buttons for player one and change the status for them
                        foreach (GridCell Player_1_deffense_button in this.Player_1.Playergridsquarecollection)
                        {
                            // turn off buttons on the enemy grid(player two left side)only if it is a defense button
                            if (Player_2_Offense_button.Uid == Player_1_deffense_button.Uid && Player_1_deffense_button.OffenseButton == false)
                            {
                                //make changes to player two grid
                                Player_1_deffense_button.Background = Brushes.Red;
                                Player_1_deffense_button.Content = "X";
                                Player_1_deffense_button.Stricked_ = 1;
                                Player_1_deffense_button.AllowDrop = false;

                                //make changes to player one grid
                                Player_2_Offense_button.Visibility = Visibility.Hidden;
                            }
                        }

                        Coordinate attackedGridSpace = new Coordinate((short)Player_2_Offense_button.ColNum, (short)Player_2_Offense_button.RowNum);

                        Logger.ConsoleInformation("Row Number: " + Player_2_Offense_button.RowNum);
                        Logger.ConsoleInformation("Column Number: " + Player_2_Offense_button.ColNum);

                        foreach (Ship testShip in this.Player_1.Playershipcollection)
                        {
                            AttackCoordinate tempCoordainte = testShip.AttackGridSpace(attackedGridSpace);
                        }

                        //Swicth windows between players
                        SwitchPlayerWindows();
                    }
                }
                else  ///add the drag over event for when ships are dragged over the cells only if the cell is deffense type
                {
                    //Create a method when an object is drag over this left button
                    Player_2_Offense_button.DragOver += new DragEventHandler(Onbuttondragover);

                        void Onbuttondragover(object sender, DragEventArgs e)
                        {
                            // find the sender uid extracting the date of the event
                            string MyWarshipUid = e.Data.GetData(DataFormats.StringFormat).ToString();

                            //iterate thru the collection of ships to find the sender element with matching uid
                            foreach (Ship ship in this.Player_2.Playershipcollection)
                            {
                                if (isLocked2 == false)
                                {
                                    //if the sender element uid matches then this is my element, then move it with the mouse
                                    if (MyWarshipUid == ship.Uid)
                                    {
                                        Point GrabPos = e.GetPosition(this.PlayerWindow_2); //find the position of the mouse compared to the canvas for player two
                                        double ShipmaxX = (this.PlayerWindow_2.Width / 2) - ship.Width + Cellsize;
                                        double ShipmaxY = (this.PlayerWindow_2.Width) / 2 - ship.Height + Cellsize;
                                       if (GrabPos.X < ShipmaxX && GrabPos.Y < ShipmaxY)
                                       {
                                        Canvas.SetTop(ship, Player_2_Offense_button.Top_Comp_ParentTop);
                                        ship.Top_Comp_ParentTop = Player_2_Offense_button.Top_Comp_ParentTop;
                                        Canvas.SetLeft(ship, Player_2_Offense_button.Left_Comp_ParentLeft);
                                        ship.Left_Comp_ParentLeft = Player_2_Offense_button.Left_Comp_ParentLeft;

                                        Coordinate shipStartCoords = this.ConvertCanvasCoordinatesToGridCoordinates(GrabPos.X, GrabPos.Y);
                                        Coordinate shipEndCoords = this.ConvertCanvasCoordinatesToGridCoordinates(GrabPos.X, GrabPos.Y);


                                        if (ship.h_direction == true)
                                        {
                                            shipEndCoords.XCoordinate += (short)((ship.Width / Cellsize) - 1);
                                        }
                                        else if (ship.h_direction == false)
                                        {
                                            shipEndCoords.YCoordinate += (short)((ship.Height / Cellsize) - 1);
                                        }

                                        UpdateShipCoords(ship, shipStartCoords, shipEndCoords);
                                    }
                                    }
                                }
                            }
                        }
                }
                //Add player 2 cells to the window grid
                this.PlayerWindow_2.Children.Add(Player_2_Offense_button);
            }

            ///player two ships actions
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Load all ships from player two to the player two canvas
            foreach (Ship ship_2 in this.Player_2.Playershipcollection)
            {
                //create a move move event for player 2 ships to attacch the rectangle to the mouse
                ship_2.MouseMove += new MouseEventHandler(Warship_MouseMove);
                ship_2.MouseRightButtonDown += new MouseButtonEventHandler(Warship_MouseRightButtonDown);

                void Warship_MouseMove(object sender, MouseEventArgs e)
                {
                    if (isLocked2 == false)
                    {
                        if (e.LeftButton == MouseButtonState.Pressed)
                        {
                            string ObjectUniqueID = ship_2.Uid;
                            Point GrabPos = e.GetPosition(ship_2);
                            Canvas.SetTop(ship_2, GrabPos.Y);
                            Canvas.SetLeft(ship_2, GrabPos.X);
                            DragDrop.DoDragDrop(ship_2, ObjectUniqueID, DragDropEffects.Move);
                        }
                    }
                }

                //Rotate ships for player two with rigth click(refer to ship class constructor)
                void Warship_MouseRightButtonDown(object sender, System.EventArgs e)
                {
                    if (isLocked2 == false)
                    {
                        if (ship_2.h_direction == true)
                        {
                            double ShipmaxY = (this.PlayerWindow_2.Width) / 2 - (Cellsize * 2);
                            double ShipmaxX = (this.PlayerWindow_2.Width / 2);
                            if (ship_2.Top_Comp_ParentTop < ShipmaxY && ship_2.Left_Comp_ParentLeft < ShipmaxX)
                            {
                                ship_2.Rotateship(true);
                            }
                        }
                        else
                        {
                            double ShipmaxY = (this.PlayerWindow_2.Width) / 2;
                            double ShipmaxX = (this.PlayerWindow_2.Width / 2) - (Cellsize * 2);
                            if (ship_2.Top_Comp_ParentTop < ShipmaxY && ship_2.Left_Comp_ParentLeft < ShipmaxX)
                            {
                                ship_2.Rotateship(true);
                            }
                        }
                    }
                }

                //Add player 2 Ships to the window grid
                this.PlayerWindow_2.Children.Add(ship_2);
            }

            //load both canvas to this window grid
            this.Maingrid.Children.Add(this.PlayerWindow_1);
            this.Maingrid.Children.Add(this.PlayerWindow_2);


            foreach (GridCell cell in PlayersCellRecords)
            {
                listbtn.Items.Add("Pid= "+cell.playerid.ToString()+" offense "+cell.Uid+" "+cell.OffenseButton+ "  stricked= "+cell.Stricked_);
            }

            this.Show();
        }

        /// <summary>
        /// switch between windows
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        //Allow window to be set to invisible read only
        public bool Switch
        {
            get { return ScreenPlayerOne_; }
        }

        /// <summary>
        /// Make the windows visible with Attack button
        /// </summary>
        public void SwitchPlayerWindows()
        {
            if (ScreenPlayerOne_ == true)
            {
                //change the visual to off for player 1 and turn on the vissible to player two canvas
                ScreenPlayerOne_ = false;
                PlayerOnelabel.Visibility = Visibility.Hidden;
                PlayerTwolabel.Visibility = Visibility.Visible;

                foreach (UIElement Canvas in this.Maingrid.Children)
                {
                    if(Canvas.Uid == "Player1Canvas")
                    {
                        Canvas.Visibility = Visibility.Hidden;
                    }
                    if (Canvas.Uid == "Player2Canvas")
                    {
                        Canvas.Visibility = Visibility.Visible;
                    }
                }
                // if the switch button has been clicked for the first time then allow player2 to move their ships

                SetConfirmButtonVisibility("Player2Canvas");
            }
            else// if the screen player one entert the method in false condition
            {
                //change the visual to on for player 1 and turn off the vissible to player two canvas

                ScreenPlayerOne_ = true;
                PlayerOnelabel.Visibility = Visibility.Visible;
                PlayerTwolabel.Visibility = Visibility.Hidden;

                foreach (UIElement Canvas in this.Maingrid.Children)
                {
                    if (Canvas.Uid == "Player1Canvas")
                    {
                        Canvas.Visibility = Visibility.Visible;
                    }
                    if (Canvas.Uid == "Player2Canvas")
                    {
                        Canvas.Visibility = Visibility.Hidden;
                    }
                }

                SetConfirmButtonVisibility("Player1Canvas");
            }
        }

        private void SetConfirmButtonVisibility(string canvasUid)
        {
            if ((canvasUid == "Player1Canvas" && this.isLocked == true) || (canvasUid == "Player2Canvas" && this.isLocked2 == true))
                this.Confirm_Button.IsEnabled = false;

            else if ((canvasUid == "Player1Canvas" && this.isLocked) == false || (canvasUid == "Player2Canvas" && this.isLocked2 == false))
                this.Confirm_Button.IsEnabled = true;
        }

        private void ConfirmShipPlacement(string canvasUid)
        {
            if (canvasUid == "Player1Canvas")
                this.isLocked = true;

            else if (canvasUid == "Player2Canvas")
                this.isLocked2 = true;

            SetConfirmButtonVisibility(canvasUid);
        }

        /// <summary>
        /// Converts the specified <paramref name="roundedCanvasCoords"/> into a <see cref="Coordinate"/> object.
        /// </summary>
        /// <param name="roundedCanvasCoords">The coordinates to be converted.</param>
        /// <returns>The converted coordinates.</returns>
        private Coordinate ConvertCanvasCoordinatesToGridCoordinates(double canvasX, double canvasY)
        {
            Coordinate gridCoordinate = new Coordinate();

            gridCoordinate.XCoordinate = (short)((canvasX / Cellsize) + 1);
            gridCoordinate.YCoordinate = (short)((canvasY / Cellsize) + 1);

            return gridCoordinate;
        }

        /// <summary>
        /// Method to update the logical coordinates of the passed in <paramref name="shipToUpdate"/> object.
        /// </summary>
        /// <param name="shipToUpdate">The ship whose coordinates are to be updated.</param>
        /// <param name="shipStartCoords">The starting (top-left) coordinates of the ship.</param>
        /// <param name="shipEndCoords">The ending (bottom-right) coordinates of the ship.</param>
        private void UpdateShipCoords(Ship shipToUpdate, Coordinate shipStartCoords, Coordinate shipEndCoords)
        {
            Logger.ConsoleInformation("New Ship Start Coords: " + shipStartCoords.XCoordinate.ToString() + ", " + shipStartCoords.YCoordinate.ToString());
            Logger.ConsoleInformation("New Ship End Coords: " + shipEndCoords.XCoordinate.ToString() + ", " + shipEndCoords.YCoordinate.ToString());
            shipToUpdate.UpdateShipCoords(shipStartCoords, shipEndCoords);
        }

        /// <summary>
        /// Fire missiles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttackBtn_Click_1(object sender, RoutedEventArgs e)
        {
            //goto to method to change the screen view
            SwitchPlayerWindows();
        }

        private void reportbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.PlayerWindow_1.Visibility == Visibility.Visible)
                ConfirmShipPlacement("Player1Canvas");
            else if (this.PlayerWindow_2.Visibility == Visibility.Visible)
                ConfirmShipPlacement("Player2Canvas");
        }
    }
}

