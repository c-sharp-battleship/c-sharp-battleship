//-----------------------------------------------------------------------
// <copyright file="CustomButton.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship.GUIComponents
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// The class which is used to represent a custom button.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class CustomButton : Button
    {
        /// <summary>
        /// Is button striked or not.
        /// </summary>
        public int Striked = 0;

        /// <summary>
        /// Does button belong to enemy or not.
        /// </summary>
        public int FireToEnemy = 0;

        /// <summary>
        /// The row of where the button is located.
        /// </summary>
        public int Row;

        /// <summary>
        /// The column of where the button is located.
        /// </summary>
        public int Column;

        /// <summary>
        /// The grid field.
        /// </summary>
        private int buttonGridID;

        /// <summary>
        /// The player number field.
        /// </summary>
        private int playerNumber;

        /// <summary>
        /// The name of the button.
        /// </summary>
        private string name;


        public int Stricked_ = 0;


        public double Left_To_ParentLeft;


        public double Top_To_ParentTop;

        //Player Number property
        public double Left_Comp_ParentLeft
        {
            get { return Left_To_ParentLeft; }
            set { Left_To_ParentLeft = value; }
        }

        //Player Number property
        public double Top_Comp_ParentTop
        {
            get { return Top_To_ParentTop; }
            set { Top_To_ParentTop = value; }
        }


        /// <summary>
        ///  Initializes a new instance of the <see cref="CustomButton" /> class.
        /// </summary>
        /// <param name="passID">The button ID.</param>
        /// <param name="passPlayerNumber">The player number.</param>
        /// <param name="myname">The name of the player.</param>
        public CustomButton(int passID, int passPlayerNumber, string myname) : base()
        {
            this.buttonGridID = passID;
            this.playerNumber = passPlayerNumber;
            this.name = myname;

            // Get the player number property from this class for color of button
            switch (PlayerNumber)
            {
                case 1:
                    Background = Brushes.Black;//base
                    BorderBrush = Brushes.White;//base
                    BorderThickness = new Thickness(0.5);//base
                    break;
                case 2:
                    Background = Brushes.DarkCyan;//base
                    BorderBrush = Brushes.Green;//base
                    Foreground = Brushes.DarkCyan;//base
                    BorderThickness = new Thickness(0.5);//base
                    break;
                default:
                    Background = Brushes.Transparent;//base
                    BorderBrush = Brushes.DarkGray;//base
                    BorderThickness = new Thickness(0.1);//base
                    Foreground = Brushes.Transparent;
                    break;
            }

            AllowDrop = true;//base
            Click += new RoutedEventHandler(button_Click);//base

            //Create a method when button is clicked 
            void button_Click(object sender, System.EventArgs e)
            {
                Content = "X";
                Stricked_ = 1;
                Background = Brushes.Red;
                MessageBox.Show("Id on this grid = " + this.ButtongridID.ToString() + "\n" +
                                "Stricked Status = " + this.Stricked_.ToString() + "\n" +
                                "Fire To Enemy = " + this.FireToEnemy.ToString() + "\n" +
                                "LeftCompareTocanvas = " + this.Left_Comp_ParentLeft.ToString() + "\n" +
                                "Top compared to parent Top = " + this.Top_Comp_ParentTop.ToString()
                                                                                            , "Status Report", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="CustomButton" /> class.
        /// </summary>
        /// <param name="anyButton">The object of the button.</param>
        public CustomButton(object anyButton)
        {
            this.name = anyButton.ToString();
        }

        /// <summary>
        ///  Gets or sets the ID property.
        /// </summary>
        public int ButtongridID 
        { 
            get { return this.buttonGridID; } 
            set { this.buttonGridID = value; } 
        }

        /// <summary>
        /// Gets or sets the player number property.
        /// </summary>
        public int PlayerNumber
        {
            get { return this.playerNumber; }
            set { this.playerNumber = value; }
        }

        /// <summary>
        /// Gets or sets the row of where the button is located.
        /// </summary>
        public int ButtonRow
        {
            get { return this.Row; }
            set { this.Row = value; }
        }

        /// <summary>
        /// Gets or sets the column of where the button is located.
        /// </summary>
        public int ButtonColumn
        {
            get { return this.Column; }
            set { this.Column = value; }
        }

        /// <summary>
        /// Gets or sets the button name property.
        /// </summary>
        public string ButtonName
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
