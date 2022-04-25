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

namespace Battleship
{
    public class GridCell : Button
    {
        private int PlayerID_;
        private string Name_;
        private int ColumnNumber;
        private int RowNumber;
        private bool OffenseButton_ = true;
        private bool ButtonOccupied_ = false;
        public int Stricked_ = 0;
        public int FireToEnemy = 0;
        public double Left_To_ParentLeft;
        public double Top_To_ParentTop;

        /// <summary>
        /// Constructor
        /// </summary>
        public GridCell(int PlayerID,int buttoncolor, string myname) : base()
        {
            PlayerID_ = PlayerID;
            Name_ = myname;
            switch (buttoncolor)
            {
                case 1:
                    Background = Brushes.Black;//base
                    BorderBrush = Brushes.White;//base
                    BorderBrush = Brushes.White;//base
                    BorderThickness = new Thickness(1);//base
                    Foreground = Brushes.Black;
                    break;
                case 2:
                    Background = Brushes.DarkBlue;//base
                    BorderBrush = Brushes.White;//base
                    BorderBrush = Brushes.White;//base
                    BorderThickness = new Thickness(1);//base
                    Foreground = Brushes.DarkBlue;
                    break;
                case 3:
                    Background = Brushes.Magenta;//base
                    BorderBrush = Brushes.White;//base
                    BorderBrush = Brushes.White;//base
                    BorderThickness = new Thickness(1);//base
                    Foreground = Brushes.Magenta;
                    break;
                case 4:
                    Background = Brushes.LightSeaGreen;//base
                    BorderBrush = Brushes.White;//base
                    BorderBrush = Brushes.White;//base
                    BorderThickness = new Thickness(1);//base
                    Foreground = Brushes.LightSeaGreen;
                    break;
                case 5:
                    Background = Brushes.Purple;//base
                    BorderBrush = Brushes.White;//base
                    BorderBrush = Brushes.White;//base
                    BorderThickness = new Thickness(1);//base
                    Foreground = Brushes.Purple;
                    break;
                case 6:
                    Background = Brushes.White;//base
                    BorderBrush = Brushes.Black;//base
                    Foreground = Brushes.LightSeaGreen;//base
                    BorderThickness = new Thickness(1);//base
                    Foreground = Brushes.White;
                    break;
                default:
                    Background = Brushes.CadetBlue;//base
                    BorderBrush = Brushes.Transparent;//base
                    BorderThickness = new Thickness(0.1);//base
                    Foreground = Brushes.CadetBlue;

                    break;
            }

        }




        //Type of button , offense or defense
        public bool OffenseButton
        {
            get { return OffenseButton_; }
            set { OffenseButton_ = value; }
        }

        //occupied property is some other object over this button
        public bool ButtonOccupied
        {
            get { return ButtonOccupied_; }
            set { ButtonOccupied_ = value; }
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

        //Player Number property
        public int playerid
        {
            get { return PlayerID_; }
            set { PlayerID_ = value; }
        }

        //buttonname Property
        public string buttonname
        {
            get { return Name_; }
            set { Name_ = value; }
        }

        //Player Number property
        public int ColNum
        {
            get { return ColumnNumber; }
            set { ColumnNumber = value; }
        }

        //Player Number property
        public int RowNum
        {
            get { return RowNumber; }
            set { RowNumber = value; }
        }
    }
}
