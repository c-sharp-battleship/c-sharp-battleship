using System;
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
    class Ship : UserControl
    {
        /// <summary>
        /// Private fields
        /// </summary>
        private int ShipType_;
        private string Name_;
        private int Resistance_;
        private int Grids_;
        private int PlayerID_;
        private bool H_direction = true;
        private double S_length_;

        /// <summary>
        /// This is the Ship constructor
        /// </summary>
        /// <param name="PlayerID"> This is the player ID passed from player class</param>
        /// <param name="ShipName"> This is the name for the ship,refer to player class</param>
        /// <param name="Resistance">this is the number of hits ths ship will resist</param>
        /// <param name="ShipType"> this is the type of ship, Submarine,warship...</param>
        /// <param name="Grids"> This is the number of gridsquares the ship will cover on the player class(canvas)</param>
        /// <param name="gridcellSize"> This is the size of the grid square passed from player class, determined in pixels</param>
        public Ship(int PlayerID, string ShipName, int Resistance, int ShipType, int Grids,double gridcellSize) : base()
        {
            PlayerID_ = PlayerID;
            Name_ = ShipName;
            Resistance_ = Resistance;
            ShipType_ = ShipType;
            Grids_ = Grids;
            Width = Grids * gridcellSize;
            Height = gridcellSize;
        }
        /// <summary>
        /// This method will change the width fr the Height of this ship and viceversa
        /// </summary>
        /// <param name="trigger"></param>
        public void Rotateship(bool trigger)
        {
            if (trigger == true)
            {
                double switcher = Width;//base
                Width = Height;
                Height = switcher;
            }

        }

        /// <summary>
        /// Horizontal loading for the ship set true at loading
        /// </summary>
        public bool h_direction
        {
            get { return H_direction; }
            set { H_direction = value; }
        }

        /// <summary>
        /// this is the type of ship, Submarine,warship...
        /// </summary>
        public int shiptype
        {
            get { return ShipType_; }
            set { ShipType_ = value; }
        }

        /// <summary>
        /// this is the number of hits ths ship will resist
        /// </summary>
        public int resistance
        {
            get { return Resistance_; }
            set { Resistance_ = value; }
        }

        /// <summary>
        /// This is the name for the ship,refer to player class
        /// </summary>
        public string name
        {
            get { return Name_; }
            set { Name_ = value; }
        }

         /// <summary>
         ///Ship length 
         /// </summary>
        public int gridspaces
        {
            get { return Grids_; }
            set { Grids_ = value; }
        }

        /// <summary>
        /// This is the number of gridsquares the ship will cover on the player class(canvas)
        /// </summary>
        public double shiplength
        {
            get { return S_length_; }
            set { S_length_ = value; }
        }

        /// <summary>
        /// This is the player ID passed from player class
        /// </summary>
        public int playerid
        {
            get { return PlayerID_; }
        }

    }
}
