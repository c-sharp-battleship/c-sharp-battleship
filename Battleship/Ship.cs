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
        public double Left_To_ParentLeft;
        public double Top_To_ParentTop;

        private Coordinate shipStartCoords;
        public Coordinate ShipStartCoords { get { return shipStartCoords; } }

        private Coordinate shipEndCoords;
        public Coordinate ShipEndCoords { get { return shipEndCoords; } }

        /// <summary>
        /// This is the Ship constructor
        /// </summary>
        /// <param name="PlayerID"> This is the player ID passed from player class</param>
        /// <param name="ShipName"> This is the name for the ship,refer to player class</param>
        /// <param name="Resistance">this is the number of hits ths ship will resist</param>
        /// <param name="ShipType"> this is the type of ship, Submarine,warship...</param>
        /// <param name="Grids"> This is the number of gridsquares the ship will cover on the player class(canvas)</param>
        /// <param name="gridcellSize"> This is the size of the grid square passed from player class, determined in pixels</param>
        public Ship(int PlayerID, string ShipName, int Resistance, int ShipType, int Grids,double gridcellSize, Coordinate startCoords, Coordinate endCoords) : base()
        {
            PlayerID_ = PlayerID;
            Name_ = ShipName;
            Resistance_ = Resistance;
            ShipType_ = ShipType;
            Grids_ = Grids;
            Width = Grids * gridcellSize;
            Height = gridcellSize;

            this.shipStartCoords = startCoords;
            this.shipEndCoords = endCoords;
        }
        /// <summary>
        /// This method will change the width fr the Height of this ship and viceversa
        /// </summary>
        /// <param name="trigger"></param>
        public void Rotateship(bool trigger)
        {
            if (trigger == true)
            {
                // Instantiate new coordinate objects to store the ship's previous coordinates.
                Coordinate previousShipStartCoords = new Coordinate(this.shipStartCoords.XCoordinate, this.shipStartCoords.YCoordinate);
                Coordinate previousShipEndCoords = new Coordinate(this.shipStartCoords.XCoordinate, this.shipStartCoords.YCoordinate);

                // Update the coordinate properties of the current ship.
                this.shipStartCoords = previousShipEndCoords;
                this.shipEndCoords = previousShipStartCoords;

                if (h_direction == true)
                {
                    h_direction = false;
                    double switcher = Width;//base
                    Width = Height;
                    Height = switcher;
                }
                else 
                {
                    h_direction = true;
                    double switcher = Width;//base
                    Width = Height;
                    Height = switcher;
                }
            }
        }

        public AttackCoordinate AttackGridSpace(Coordinate testCoordinate)
        {
            AttackCoordinate attackCoordinate = new AttackCoordinate(testCoordinate.XCoordinate, testCoordinate.YCoordinate);

            // If the ship is horizontal, we only have to compare the X-Coordinate of the attacked grid space with the ship's grid spaces.
            if(this.h_direction == true)
            {
                if((testCoordinate.YCoordinate == this.shipStartCoords.YCoordinate) && (testCoordinate.XCoordinate >= this.shipStartCoords.XCoordinate) && (testCoordinate.XCoordinate <= this.shipEndCoords.XCoordinate))
                {
                    attackCoordinate.CoordinateStatus = StatusCodes.AttackStatus.ATTACKED_HIT;
                    Logger.ConsoleInformation("You've hit gold!");
                }
                else
                {
                    attackCoordinate.CoordinateStatus = StatusCodes.AttackStatus.ATTACKED_NOT_HIT;
                    Logger.ConsoleInformation("Sorry, but you'll never succeed!");
                }
            }
            else
            {
                if ((testCoordinate.XCoordinate == this.shipStartCoords.XCoordinate) && (testCoordinate.YCoordinate >= this.shipStartCoords.YCoordinate) && (testCoordinate.YCoordinate <= this.shipEndCoords.YCoordinate))
                {
                    attackCoordinate.CoordinateStatus = StatusCodes.AttackStatus.ATTACKED_HIT;
                    Logger.ConsoleInformation("You've hit gold!");
                }
                else
                {
                    attackCoordinate.CoordinateStatus = StatusCodes.AttackStatus.ATTACKED_NOT_HIT;
                    Logger.ConsoleInformation("Sorry, but you'll never succeed!");
                }
            }

            Logger.ConsoleInformation("Ship Uid: " + this.Uid);
            Logger.ConsoleInformation("Ship Start Coordinates: " + this.shipStartCoords.XCoordinate + ", " + this.shipStartCoords.YCoordinate);
            Logger.ConsoleInformation("Ship End Coordinates: " + this.shipEndCoords.XCoordinate + ", " + this.shipEndCoords.YCoordinate);

            return attackCoordinate;
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
        /// This is the player ID passed from player class
        /// </summary>
        public int playerid
        {
            get { return PlayerID_; }
        }

        //Player Number property
        public double Left_Comp_ParentLeft
        {
            get { return Left_To_ParentLeft; }
            set { Left_To_ParentLeft = value; }
        }

        //Player ID property
        public double Top_Comp_ParentTop
        {
            get { return Top_To_ParentTop; }
            set { Top_To_ParentTop = value; }
        }

        public void UpdateShipCoords(Coordinate _shipStartCoords, Coordinate _shipEndCoords)
        {
            this.shipStartCoords = _shipStartCoords;
            this.shipEndCoords = _shipEndCoords;

            if(_shipStartCoords.YCoordinate == _shipEndCoords.YCoordinate)
            {
                this.h_direction = true;
            }
            else
            {
                this.h_direction = false;
            }
        }
    }
}
