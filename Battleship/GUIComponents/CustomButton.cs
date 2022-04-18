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


namespace Battleship.GUIComponents
{
    class CustomButton : Button
    {
        private double ButtongridID_; // Grid field
        private int PlayerNumber_;  // Player number field
        private string Name_;
        public int Stricked_ = 0;
        public int FireToEnemy = 0;
        public double Left_To_ParentLeft;
        public double Top_To_ParentTop;


        //constructor take both parameters for button ID and player number for color fill
        public CustomButton(double PassID, int PassPlayerNumber, string myname) : base()
        {
            ButtongridID_ = PassID;
            PlayerNumber_ = PassPlayerNumber;
            Name_ = myname;
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


        public CustomButton(object anybutton)
        {
            Name_ = anybutton.ToString();
        }

        //ID Property
        public double ButtongridID { get { return ButtongridID_; } set { ButtongridID_ = value; } }

        //Player Number property
        public int PlayerNumber
        {
            get { return PlayerNumber_; }
            set { PlayerNumber_ = value; }
        }

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

        //buttonname Property
        public string buttonname
        {
            get { return Name_; }
            set { Name_ = value; }
        }



    }
}
