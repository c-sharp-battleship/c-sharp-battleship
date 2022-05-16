//-----------------------------------------------------------------------
// <copyright file="Ship_Loading.xaml.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System.Collections.Generic;
    using System.Windows;

    /// <summary>
    /// Interaction logic for Ship_Loading.xaml.
    /// </summary>
    public partial class Ship_Loading : Window
    {
        /// <summary>
        /// The <see cref="AdvancedOptions"/> for the <see cref="Ship_Loading"/> object.
        /// </summary>
        private AdvancedOptions advancedOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ship_Loading"/> class.
        /// </summary>
        /// <param name="p_advancedOptions">The <see cref="AdvancedOptions"/> object to be modified.</param>
        public Ship_Loading(ref AdvancedOptions p_advancedOptions)
        {
            this.InitializeComponent();

            this.advancedOptions = p_advancedOptions;
        }

        /// <summary>
        /// The loaded event for the <see cref="Ship_Loading"/> window.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (StatusCodes.ShipType ship in this.advancedOptions.ShipTypes)
            {
                switch (ship)
                {
                    case StatusCodes.ShipType.DESTROYER:
                        this.RPT_LIST.Items.Add("Destroyer");
                        break;
                    case StatusCodes.ShipType.SUBMARINE:
                        this.RPT_LIST.Items.Add("Submarine");
                        break;
                    case StatusCodes.ShipType.CRUISER:
                        this.RPT_LIST.Items.Add("Cruiser");
                        break;
                    case StatusCodes.ShipType.BATTLESHIP:
                        this.RPT_LIST.Items.Add("Battleship");
                        break;
                    case StatusCodes.ShipType.CARRIER:
                        this.RPT_LIST.Items.Add("Carrier");
                        break;
                }
            }
        }

        /// <summary>
        /// The destroyer deployment button click event.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void DE_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (this.advancedOptions.ShipTypes.Count < 7)
            {
                this.RPT_LIST.Items.Add("Destroyer");
                this.advancedOptions.ShipTypes.Add(StatusCodes.ShipType.DESTROYER);
            }
            else
            {
                Logger.Error("You Cannot Have More than 7 Ships in a Fleet!");
            }
        }

        /// <summary>
        /// The destroyer deployment button click event.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void SU_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (this.advancedOptions.ShipTypes.Count < 7)
            {
                this.RPT_LIST.Items.Add("Submarine");
                this.advancedOptions.ShipTypes.Add(StatusCodes.ShipType.SUBMARINE);
            }
            else
            {
                Logger.Error("You Cannot Have More than 7 Ships in a Fleet!");
            }
        }

        /// <summary>
        /// The cruiser deployment button click event.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void CR_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (this.advancedOptions.ShipTypes.Count < 7)
            {
                this.RPT_LIST.Items.Add("Cruiser");
                this.advancedOptions.ShipTypes.Add(StatusCodes.ShipType.CRUISER);
            }
            else
            {
                Logger.Error("You Cannot Have More than 7 Ships in a Fleet!");
            }
        }

        /// <summary>
        /// The battleship deployment button click event.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void BA_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (this.advancedOptions.ShipTypes.Count < 7)
            {
                this.RPT_LIST.Items.Add("Battleship");
                this.advancedOptions.ShipTypes.Add(StatusCodes.ShipType.BATTLESHIP);
            }
            else
            {
                Logger.Error("You Cannot Have More than 7 Ships in a Fleet!");
            }
        }

        /// <summary>
        /// The carrier deployment button click event.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void CA_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (this.advancedOptions.ShipTypes.Count < 7)
            {
                this.RPT_LIST.Items.Add("Carrier");
                this.advancedOptions.ShipTypes.Add(StatusCodes.ShipType.CARRIER);
            }
            else
            {
                Logger.Error("You Cannot Have More than 7 Ships in a Fleet!");
            }
        }

        /// <summary>
        /// The default options button click event.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void DEFAULT_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.RPT_LIST.Items.Clear();

            // Create a new AdvancedOptions.ShipTypes class and call the default values.
            this.advancedOptions.ShipTypes = new List<StatusCodes.ShipType>();

            this.advancedOptions.ShipTypes.Add(StatusCodes.ShipType.DESTROYER);
            this.RPT_LIST.Items.Add("Destroyer");

            this.advancedOptions.ShipTypes.Add(StatusCodes.ShipType.SUBMARINE);
            this.RPT_LIST.Items.Add("Submarine");

            this.advancedOptions.ShipTypes.Add(StatusCodes.ShipType.CRUISER);
            this.RPT_LIST.Items.Add("Cruiser");

            this.advancedOptions.ShipTypes.Add(StatusCodes.ShipType.BATTLESHIP);
            this.RPT_LIST.Items.Add("Battleship");

            this.advancedOptions.ShipTypes.Add(StatusCodes.ShipType.CARRIER);
            this.RPT_LIST.Items.Add("Carrier");
        }

        /// <summary>
        /// The clear options button click event.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void CLEAR_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.RPT_LIST.Items.Clear();

            // Create a new AdvancedOptions.ShipTypes.
            this.advancedOptions.ShipTypes = new List<StatusCodes.ShipType>();
        }

        /// <summary>
        /// The close window button click event.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void CLOSE_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// The delete selected option button click event.
        /// </summary>
        /// <param name="sender">The sender that invoked the event.</param>
        /// <param name="e">The arguments passed to the event.</param>
        private void DELETE_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (this.RPT_LIST.SelectedIndex == -1)
            {
                Logger.Error("You Need To Select Something Before Deleting It!");
            }
            else
            {
                int index = this.RPT_LIST.SelectedIndex;
                this.RPT_LIST.Items.RemoveAt(index);
                this.advancedOptions.ShipTypes.RemoveAt(index);
            }
        }
    }
}
