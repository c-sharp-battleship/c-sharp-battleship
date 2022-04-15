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
            if (this.PlayerNumber == 1)
            {
                this.Background = Brushes.Black; // base
            }
            else
            {
                this.Background = Brushes.DarkCyan; // base   
            }

            this.BorderBrush = Brushes.White;
            this.BorderThickness = new Thickness(2); // base
            this.Click += new RoutedEventHandler(this.Button_Click); // base

            this.AllowDrop = true;
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

        /// <summary>
        /// Performs when button is clicked.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param> 
        public void Button_Click(object sender, System.EventArgs e)
        {
            this.Content = "X";
            this.Striked = 1;
            this.Background = Brushes.Red;
            MessageBox.Show(
                "Id on this grid = " + this.ButtongridID.ToString() + "\n" + "Stricked Status = " + this.Striked.ToString() + "\n" + "Fire To Enemy = " + this.FireToEnemy.ToString(), 
                "Status Report", 
                MessageBoxButton.OK, 
                MessageBoxImage.Asterisk);
        }
    }
}
