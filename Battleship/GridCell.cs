//-----------------------------------------------------------------------
// <copyright file="GridCell.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for GridCell.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public class GridCell : Button
    {
        /// <summary>
        /// Is the grid cell stricked or not.
        /// </summary>
        public int Stricked = 0;

        /// <summary>
        /// Is the grid cell fired an enemy's grid cell.
        /// </summary>
        public int FireToEnemy = 0;

        /// <summary>
        /// The left to the parent left.
        /// </summary>
        public double LeftToParentLeft;

        /// <summary>
        /// The top to the parent top.
        /// </summary>
        public double TopToParentTop;

        /// <summary>
        /// Horizontal crew members.
        /// </summary>
        private List<int> movingCrewmembers;

        /// <summary>
        /// The grid cell's player ID.
        /// </summary>
        private int playerID;

        /// <summary>
        /// The grid cell's name.
        /// </summary>
        private string name;

        /// <summary>
        /// name for ship contained.
        /// </summary>
        private string containedshipName;

        /// <summary>
        /// The grid cell's name.
        /// </summary>
        private string containedShipID;

        /// <summary>
        /// The type of the ship contained by the gridcell.
        /// </summary>
        private int containedshipType;

        /// <summary>
        /// The grid cell's column number.
        /// </summary>
        private int columnNumber;

        /// <summary>
        /// The grid cell's row number.
        /// </summary>
        private int rowNumber;

        /// <summary>
        /// The grid cell's row number.
        /// </summary>
        private int buttonID;

        /// <summary>
        /// Is the offense button clicked or not.
        /// </summary>
        private bool offenseButton = true;

        /// <summary>
        /// Is the button occupied or not.
        /// </summary>
        private bool buttonOccupied = false;

        /// <summary>
        /// The grid cell's row number.
        /// </summary>
        private int trackingID;

        /// <summary>
        /// Initializes a new instance of the <see cref="GridCell" /> class.
        /// </summary>
        /// <param name="playerID"> This is the ID of the player. </param>
        /// <param name="buttonColor"> This is the button color. </param>
        /// <param name="myName"> This is the name of the grid cell. </param>
        public GridCell(int playerID, int buttonColor, string myName)
        {
            this.movingCrewmembers = new List<int>();
            this.playerID = playerID;
            this.name = myName;
            switch (buttonColor)
            {
                case 1:
                    this.Background = Brushes.Black; // base
                    this.BorderBrush = Brushes.White; // base
                    this.BorderBrush = Brushes.White; // base
                    this.BorderThickness = new Thickness(1); // base
                    this.Foreground = Brushes.Black;
                    break;
                case 2:
                    this.Background = Brushes.DarkBlue; // base
                    this.BorderBrush = Brushes.White; // base
                    this.BorderBrush = Brushes.White; // base
                    this.BorderThickness = new Thickness(1); // base
                    this.Foreground = Brushes.DarkBlue;
                    break;
                case 3:
                    this.Background = Brushes.Magenta; // base
                    this.BorderBrush = Brushes.White; // base
                    this.BorderBrush = Brushes.White; // base
                    this.BorderThickness = new Thickness(1); // base
                    this.Foreground = Brushes.Magenta;
                    break;
                case 4:
                    this.Background = Brushes.LightSeaGreen; // base
                    this.BorderBrush = Brushes.White; // base
                    this.BorderBrush = Brushes.White; // base
                    this.BorderThickness = new Thickness(1); // base
                    this.Foreground = Brushes.LightSeaGreen;
                    break;
                case 5:
                    this.Background = Brushes.Purple; // base
                    this.BorderBrush = Brushes.White; // base
                    this.BorderBrush = Brushes.White; // base
                    this.BorderThickness = new Thickness(1); // base
                    this.Foreground = Brushes.Purple;
                    break;
                case 6:
                    this.Background = Brushes.White; // base
                    this.BorderBrush = Brushes.Black; // base
                    this.Foreground = Brushes.LightSeaGreen; // base
                    this.BorderThickness = new Thickness(1); // base
                    this.Foreground = Brushes.White;
                    break;
                default:
                    this.Background = Brushes.CadetBlue; // base
                    this.BorderBrush = Brushes.Transparent; // base
                    this.BorderThickness = new Thickness(0.1); // base
                    this.Foreground = Brushes.CadetBlue;
                    break;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether offense button is occupied or not.
        /// </summary>
        public bool OffenseButton
        {
            get { return this.offenseButton; }
            set { this.offenseButton = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether button is occupied or not.
        /// </summary>
        public bool ButtonOccupied
        {
            get { return this.buttonOccupied; }
            set { this.buttonOccupied = value; }
        }

        /// <summary>
        /// Gets or sets grid cell's left to parent left.
        /// </summary>
        public double Left_Comp_ParentLeft
        {
            get { return this.LeftToParentLeft; }
            set { this.LeftToParentLeft = value; }
        }

        /// <summary>
        /// Gets or sets grid cell's top to parent top.
        /// </summary>
        public double Top_Comp_ParentTop
        {
            get { return this.TopToParentTop; }
            set { this.TopToParentTop = value; }
        }

        /// <summary>
        /// Gets or sets the ship name contained if there is any.
        /// </summary>
        public string ShipContainedName
        {
            get { return this.containedshipName; }
            set { this.containedshipName = value; }
        }

        /// <summary>
        /// Gets or sets the ship name contained type.
        /// </summary>
        public int ShipContainedType
        {
            get { return this.containedshipType; }
            set { this.containedshipType = value; }
        }

        /// <summary>
        /// Gets or sets a ship id contained if there is any.
        /// </summary>
        public string ShipContainedID
        {
            get { return this.containedShipID; }
            set { this.containedShipID = value; }
        }

        /// <summary>
        /// Gets or sets grid cell's player ID.
        /// </summary>
        public int PlayerID
        {
            get { return this.playerID; }
            set { this.playerID = value; }
        }

        /// <summary>
        /// Gets or sets grid cell's player ID.
        /// </summary>
        public int Buttonid
        {
            get { return this.buttonID; }
            set { this.buttonID = value; }
        }

        /// <summary>
        /// Gets or sets button's name.
        /// </summary>
        public string ButtonName
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets grid cell's column number.
        /// </summary>
        public int ColNum
        {
            get { return this.columnNumber; }
            set { this.columnNumber = value; }
        }

        /// <summary>
        /// Gets or sets grid cell's row number.
        /// </summary>
        public int RowNum
        {
            get { return this.rowNumber; }
            set { this.rowNumber = value; }
        }

        /// <summary>
        /// Gets or sets grid cell's player ID.
        /// </summary>
        public int TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }

        /// <summary>
        /// Gets or sets grid cell's player ID.
        /// </summary>
        public List<int> Crewmembers
        {
            get { return this.movingCrewmembers; }
            set { this.movingCrewmembers = value; }
        }
    }
}
