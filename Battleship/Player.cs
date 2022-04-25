﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Battleship
{


    class Player
    {
        /// <summary>
        /// This class is a canvas that will load with a list of grid squares and a list of ships attached as a property
        /// </summary>
        private int PlayerId_;
        private string Name_;
        private List<Ship> Playerships_;
        private List<GridCell> PlayerGridCells;


        /// <summary>
        /// This is the constructor
        /// </summary>
        /// <param name="PlayerID"> This is the ID of the player </param>
        /// <param name="PlayerName"> this is the name of the Player</param>
        /// <param name="gridcellSize"> This is the size in pixels for the grid square dimension</param>
        /// <param name="maxCol"> This is the max number of columns requested at the moment pf loading</param>
        /// <param name="buttoncolor"> this is the color for the button created, refer to Custom button class(switch case in constructor)</param>
        /// <param name="leftSideOfScreen"> This is the side of the screen to load the canvas, if left then reversed count, if right then incremental from one</param>
        public Player(int Player_ID,string Player_Name,double gridcellSize, int maxCol,int buttoncolorForDeffense, int buttoncolorForOffense)
        {
            //set the fixed properties
            Name_ = Player_Name;
            PlayerId_ = Player_ID;

            // List of buttons for each player returned to the personal grid builder 
            List<GridCell> loader = new List<GridCell>();

            //List of ships for each player to return to the personal grid builder
            List<Ship> shiploader = new List<Ship>();

            //List of Alphabet letters to give names to gridcells
            string[] CAPITAL_LETTERS = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};

            // set the player cstom button(grid) collection list if it is placed on the right side of screen
            //Make two grids of buttons for each player one for defense and one for offense(Defense buttons wnot have click events)
            for (int grids = 0; grids < 2; grids++)
            {
                //determine the grid type and assign a flag to the buttons if they are defense or offense.
                if  (grids == 0)
                {
                    for (int col = 0; col < maxCol; col++)// will iterate the number of columns requested
                    {
                        for (int row = 0; row < maxCol; row++) // will iterate the number of rows(same as the columns) requested
                        {
                            //create a name for this button will result in a string(10.0001, this is elevated to the ten thounsans to allow a high number of buttons without the repeating of the name)
                            double rowthousand = col + 1 + ((row + 1) * 0.0001);

                            GridCell myButton = new GridCell(Player_ID, buttoncolorForDeffense, rowthousand.ToString());
                            myButton.Content = CAPITAL_LETTERS[col] + (row + 1);
                            myButton.Width = gridcellSize;
                            myButton.Height = gridcellSize;
                            myButton.OffenseButton = false;
                            myButton.AllowDrop = true;
                            myButton.Uid = CAPITAL_LETTERS[col] + (row + 1);//will result in an id(A1) string
                            Canvas.SetTop(myButton, row * gridcellSize);//assign a value where it will be loaded if plased on a canvas
                            Canvas.SetLeft(myButton, col * gridcellSize);//assign a value where it will be loaded if plased on a canvas
                            myButton.Left_Comp_ParentLeft = col * gridcellSize;
                            myButton.Top_Comp_ParentTop = row * gridcellSize;
                            loader.Add(myButton);
                        }
                    }
                }
                else//second iteration for creating the attack grid
                {
                    //offset this buttons from the left to become the attack grid to compaensate the space occupied by the defense grid 
                    double GridOffsetWhenVisual = gridcellSize * maxCol;

                    for (int col = 0; col < maxCol; col++)// will iterate the number of columns requested
                    {
                        for (int row = 0; row < maxCol; row++) // will iterate the number of rows(same as the columns) requested 
                        {
                            //create a name for this button will result in a string(10.0001, this is elevated to the ten thounsans to allow a high number of buttons without the repeating of the name)
                            double rowthousand = col + 1 + ((row + 1) * 0.0001);

                            GridCell myButton = new GridCell(Player_ID, buttoncolorForOffense, rowthousand.ToString());
                            myButton.Content = CAPITAL_LETTERS[col] + (row + 1);
                            myButton.Width = gridcellSize;
                            myButton.Height = gridcellSize;
                            myButton.OffenseButton = true;
                            myButton.AllowDrop = false;
                            myButton.Uid = CAPITAL_LETTERS[col] + (row + 1);//will result in an id(A1) string
                            Canvas.SetTop(myButton, row * gridcellSize);//assign a value where it will be loaded if plased on a canvas
                            Canvas.SetLeft(myButton, (col * gridcellSize) + GridOffsetWhenVisual);//assign a value where it will be loaded if plased on a canvas
                            loader.Add(myButton);
                        }
                    }
                }

            }

            //load the button collection to the list field if it is right
            PlayerGridCells = loader;

            //Create a collection of 5 ships for any player 
            for (int i = 1; i <= 5; i++)
            {
                //get an iamge retainer for the iteration
                BitmapImage ShipPic = new BitmapImage();
                ShipPic.BeginInit();
                ShipPic.UriSource = new Uri(@"DinamicImages/Warship.jpg", UriKind.RelativeOrAbsolute);//Load dinamic image
                ShipPic.EndInit();

                //Construct the ships with the image above
                Ship Warship = new Ship(Player_ID,"Ship"+i.ToString(), 3, 0,3, gridcellSize);
                Warship.Background = new ImageBrush(ShipPic);
                Warship.Uid = i.ToString();
                Canvas.SetTop(Warship, i * gridcellSize);
                Canvas.SetLeft(Warship,0);

                // load the ship to the list of ships
                shiploader.Add(Warship);
            }
            //Load the ships to the list passed down the line with the field
            Playerships_ = shiploader;
        }

        /// <summary>
        /// Player name property
        /// </summary>
        public string name
        {
            get { return Name_; }
        }

        /// <summary>
        /// Player ID property
        /// </summary>
        public int playerid
        {
            get { return PlayerId_; }
        }

        /// <summary>
        /// Player collection of ships 
        /// </summary>
        public List<Ship> Playershipcollection
        {
            get { return Playerships_; }
        }

        /// <summary>
        /// Player Button collections for its personal grid 
        /// </summary>
        public List<GridCell> Playergridsquarecollection
        {
            get { return PlayerGridCells; }
        }

    }

}