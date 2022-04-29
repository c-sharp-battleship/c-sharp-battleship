//-----------------------------------------------------------------------
// <copyright file="Ship.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
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

    /// <summary>
    /// Interaction logic for SHip
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public class Ship : UserControl
    {
        /// <summary>
        /// The left to parent left.
        /// </summary>
        public double LeftToParentLeft;

        /// <summary>
        /// The top to parent top.
        /// </summary>
        public double TopToParentTop;

        /// <summary>
        /// Is ship sunk or not.
        /// </summary>
        public bool ShipIsSunk;

        /// <summary>
        /// The ship's type.
        /// </summary>
        private int shipType;

        /// <summary>
        /// The ship's name.
        /// </summary>
        private string name;

        /// <summary>
        /// The ship's resistance.
        /// </summary>
        private int resistance;

        /// <summary>
        /// The ship's length.
        /// </summary>
        private int length;

        /// <summary>
        /// The ship's player ID.
        /// </summary>
        private int playerID;

        /// <summary>
        /// The ship's horizontal direction.
        /// </summary>
        private bool horDirection = true;

        /// <summary>
        /// The ship's start coordinate.
        /// </summary>
        private Coordinate shipStartCoords;

        /// <summary>
        /// The ship's end coordinate.
        /// </summary>
        private Coordinate shipEndCoords;

        /// <summary>
        /// Horizontal crew members
        /// </summary>
        private List<int> Moving_H_crewmembers;

        /// <summary>
        /// Vertical Crew mwmbers
        /// </summary>
        private List<int> Moving_V_crewmembers;

        /// <summary>
        /// Horizontal crew members
        /// </summary>
        private List<int> Fixed_H_crewmembers;

        /// <summary>
        /// Vertical Crew mwmbers
        /// </summary>
        private List<int> Fixed_V_crewmembers;

        /// <summary>
        /// Ship current crew
        /// </summary>
        private List<int> actualship_crewmembers;

        /// <summary>
        /// Ship driver cell
        /// </summary>
        private int captain_;

        /// <summary>
        /// The ship's length.
        /// </summary>
        private int grids;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ship" /> class.
        /// </summary>
        /// <param name="playerID"> This is the player ID passed from player class</param>
        /// <param name="resistance">this is the number of hits this ship will resist</param>
        /// <param name="shipType"> this is the type of ship, Submarine,warship...</param>
        /// <param name="gridCellSize"> This is the size of the grid square passed from player class, determined in pixels</param>
        /// <param name="startCoords"> This is the start coordinates of the ship</param>
        /// <param name="endCoords"> This is the end coordinates of the ship</param>
        public Ship(int playerID,int driver, int shipType, double gridCellSize, int RowTotal, Coordinate startCoords) : base()
        {
            this.Moving_H_crewmembers = new List<int>();
            this.Moving_V_crewmembers = new List<int>();
            this.Fixed_H_crewmembers = new List<int>();
            this.Fixed_V_crewmembers = new List<int>();
            this.actualship_crewmembers = new List<int>();
            this.playerID = playerID;
            this.shipType = shipType;
            this.ShipIsSunk = false;
            this.shipStartCoords = startCoords;

            switch (shipType)
            {
                case 1:
                    this.name = "Destroyer";
                    this.length = 2;
                    this.resistance = 2;
                    this.grids = 2;
                    break;
                case 2:
                    this.name = "Submarine";
                    this.length = 3;
                    this.resistance = 3;
                    this.grids = 3;
                    break;
                case 3:
                    this.name = "Cruiser";
                    this.length = 3;
                    this.resistance = 3;
                    this.grids = 3;
                    break;
                case 4:
                    this.name = "Battleship";
                    this.length = 4;
                    this.resistance = 4;
                    this.grids = 4;
                    break;
                case 5:
                    this.name = "Carrier";
                    this.length = 5;
                    this.resistance = 5;
                    this.grids = 5;
                    break;
                default:
                    this.name = "Mistake";
                    this.length = 0;
                    this.resistance = 0;
                    this.grids = 0;
                    break;
            }
            Coordinate endCoords = new Coordinate((short)(this.shipStartCoords.XCoordinate + this.length - 1), this.ShipStartCoords.YCoordinate);
            this.shipEndCoords = endCoords;
            this.Width = length * gridCellSize;
            this.Height = gridCellSize;
            this.captain_ = driver;

            //set the entry point crew member to compare future moves
            Fixed_H_crewmembers.Clear();
            Fixed_V_crewmembers.Clear();
            int Hvalue = driver;
            int Vvalue = driver;

            for (int i = 0; i < grids; i++)
            {
                Fixed_H_crewmembers.Add(Hvalue);
                Hvalue++;
            }

            for (int i = 0; i < grids; i++)
            {
                Fixed_V_crewmembers.Add(Vvalue);
                Vvalue += RowTotal;
            }

        }

        /// <summary>
        /// Event for the is ship sunk or not
        /// </summary>
        public event EventHandler OnShipIsSunk;

        /// <summary>
        /// Gets the start coordinates of the ship
        /// </summary>
        public Coordinate ShipStartCoords
        {
            get { return this.shipStartCoords; }
        }

        /// <summary>
        /// Gets the end coordinates of the ship
        /// </summary>
        public Coordinate ShipEndCoords
        {
            get { return this.shipEndCoords; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether horizontal direction is loading for the ship, set true at loading
        /// </summary>
        public bool HDirection
        {
            get { return this.horDirection; }
            set { this.horDirection = value; }
        }

        /// <summary>
        /// Gets or sets type of shi
        /// </summary>
        public int ShipType
        {
            get { return this.shipType; }
            set { this.shipType = value; }
        }

        /// <summary>
        /// Gets or sets the number of hits this ship will resist
        /// </summary>
        public int Resistance
        {
            get { return this.resistance; }
            set { this.resistance = value; }
        }

        /// <summary>
        /// Gets or sets ship length 
        /// </summary>
        public int Length
        {
            get { return this.length; }
            set { this.length = value; }
        }

        /// <summary>
        /// Gets the player ID passed from player class
        /// </summary>
        public int PlayerID
        {
            get { return this.playerID; }
        }

        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets or sets the ship's left to parent left.
        /// </summary>
        public double Left_Comp_ParentLeft
        {
            get { return this.LeftToParentLeft; }
            set { this.LeftToParentLeft = value; }
        }

        /// <summary>
        /// Gets or sets the ship's top to parent top.
        /// </summary>
        public double Top_Comp_ParentTop
        {
            get { return this.TopToParentTop; }
            set { this.TopToParentTop = value; }
        }

        /// <summary>
        /// Gets or sets ship length 
        /// </summary>
        public int GridSpaces
        {
            get { return this.grids; }
            set { this.grids = value; }
        }

        public List<int> H_Crewmembers
        {
            get { return Moving_H_crewmembers; }
        }

        public List<int> V_Crewmembers
        {
            get { return Moving_V_crewmembers; }
        }

        public List<int> Delayed_H_Crewmembers
        {
            get { return Fixed_H_crewmembers; }
        }

        public List<int> Delayed_V_Crewmembers
        {
            get { return Fixed_V_crewmembers; }
        }

        public List<int> Ship_Crewmembers
        {
            get { return actualship_crewmembers; }
        }

        /// <summary>
        /// Set the entry point for the ship when loaded 
        /// </summary>
        public int Captain
        {
            get { return this.captain_; }
            set { this.captain_ = value; }
        }

        /// <summary>
        /// This method will change the width or the Height of this ship and reverse it.
        /// </summary>
        /// <param name="trigger">The trigger</param>
        public void RotateShip(bool trigger)
        {
            if (trigger == true)
            {
                // Instantiate new coordinate objects to store the ship's previous coordinates.
                Coordinate previousShipStartCoords;
                Coordinate previousShipEndCoords;

                if (this.HDirection == true)
                {
                    this.HDirection = false;
                    double switcher = Width; // base
                    this.Width = this.Height;
                    this.Height = switcher;
                    previousShipStartCoords = new Coordinate(this.shipStartCoords.XCoordinate, this.shipStartCoords.YCoordinate);
                    previousShipEndCoords = new Coordinate(this.shipStartCoords.XCoordinate, (short)(this.shipStartCoords.YCoordinate + this.length - 1));
                }
                else 
                {
                    this.HDirection = true;
                    double switcher = Width; // base
                    this.Width = this.Height;
                    this.Height = switcher;
                    previousShipStartCoords = new Coordinate(this.shipStartCoords.XCoordinate, this.shipStartCoords.YCoordinate);
                    previousShipEndCoords = new Coordinate((short)(this.shipStartCoords.XCoordinate + this.length - 1), this.shipStartCoords.YCoordinate);
                }

                // Update the coordinate properties of the current ship.
                this.shipStartCoords = previousShipStartCoords;
                this.shipEndCoords = previousShipEndCoords;
            }
        }

        /// <summary>
        /// Set a method that attacks the coordinate.
        /// </summary>
        /// <param name="testCoordinate">The coordinate.</param>
        /// <returns>The attack coordinate.</returns>
        public AttackCoordinate AttackGridSpace(Coordinate testCoordinate)
        {
            AttackCoordinate attackCoordinate = new AttackCoordinate(testCoordinate.XCoordinate, testCoordinate.YCoordinate);

            // If the ship is horizontal, we only have to compare the X-Coordinate of the attacked grid space with the ship's grid spaces.
            if (this.HDirection == true)
            {
                if ((testCoordinate.YCoordinate == this.shipStartCoords.YCoordinate) && (testCoordinate.XCoordinate >= this.shipStartCoords.XCoordinate) && (testCoordinate.XCoordinate <= this.shipEndCoords.XCoordinate))
                {
                    attackCoordinate.CoordinateStatus = StatusCodes.AttackStatus.ATTACKED_HIT;
                    
                    this.resistance--;

                    if (this.resistance <= 0)
                    {
                        this.OnShipIsSunk?.Invoke(this, EventArgs.Empty);
                    }
                }
                else
                {
                    attackCoordinate.CoordinateStatus = StatusCodes.AttackStatus.ATTACKED_NOT_HIT;
                }
            }
            else
            {
                if ((testCoordinate.XCoordinate == this.shipStartCoords.XCoordinate) && (testCoordinate.YCoordinate >= this.shipStartCoords.YCoordinate) && (testCoordinate.YCoordinate <= this.shipEndCoords.YCoordinate))
                {
                    attackCoordinate.CoordinateStatus = StatusCodes.AttackStatus.ATTACKED_HIT;

                    this.resistance--;

                    if (this.resistance <= 0)
                    { 
                        this.OnShipIsSunk?.Invoke(this, EventArgs.Empty);
                    }
                }
                else
                {
                    attackCoordinate.CoordinateStatus = StatusCodes.AttackStatus.ATTACKED_NOT_HIT;
                }
            }

            return attackCoordinate;
        }

        /// <summary>
        /// Set a method that updates the ship's coordinates.
        /// </summary>
        /// <param name="shipStartCoords">The ship's start coordinate.</param>
        /// <param name="shipEndCoords">The ship's end coordinate.</param>
        public void UpdateShipCoords(Coordinate shipStartCoords, Coordinate shipEndCoords)
        {
            this.shipStartCoords = shipStartCoords;
            this.shipEndCoords = shipEndCoords;

            if (shipStartCoords.YCoordinate == shipEndCoords.YCoordinate)
            {
                this.HDirection = true;
            }
            else
            {
                this.HDirection = false;
            }
        }

        public void SetCrewmembers(int p_shipLength, int p_capitan, bool p_horDirection)
        {
            this.Moving_H_crewmembers.Clear();
            this.Moving_V_crewmembers.Clear();
            int Hvalue = p_capitan;
            int Vvalue = p_capitan;

            for (int i = 0; i < GridSpaces; i++)
            {
                this.Moving_H_crewmembers.Add(Hvalue);
                Hvalue++;
            }

            for (int i = 0; i < GridSpaces; i++)
            {
                this.Moving_V_crewmembers.Add(Vvalue);
                Vvalue += this.GridSpaces;
            }

            if (p_horDirection == true)
            {
                this.actualship_crewmembers.Clear();
                this.actualship_crewmembers = this.H_Crewmembers;
            }
            else
            {
                this.actualship_crewmembers.Clear();
                this.actualship_crewmembers = this.V_Crewmembers;
            }

        }
    }
}
