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
    class CustomButton : Button
    {
        private int ButtongridID_; // Grid field
        private int PlayerNumber_;  // Player number field
        private string Name_;
        public int Stricked_ = 0;
        public int FireToEnemy = 0;
        public int Row_;
        public int Column_;

        //constructor take both parameters for button ID and player number for color fill
        public CustomButton(int PassID, int PassPlayerNumber,string myname) : base()
        {
            ButtongridID_ = PassID;
            PlayerNumber_ = PassPlayerNumber;
            Name_ = myname;
            if (PlayerNumber == 1)  // get the player number proprty from this class for color of button
            {
                Background = Brushes.Black;//base
            }
            else
            {
                Background = Brushes.DarkCyan;//base   
            }
            BorderBrush = Brushes.White;//
            BorderThickness = new Thickness(2);//base
            Click += new RoutedEventHandler(button_Click);//base
            
            AllowDrop = true;
        }

        public CustomButton(object anybutton)
        {
            Name_ = anybutton.ToString();
        }

        //ID Property
        public int ButtongridID { get { return ButtongridID_; } set { ButtongridID_ = value; } }

        //Player Number property
        public int PlayerNumber
        {
            get { return PlayerNumber_; }
            set { PlayerNumber_ = value; }
        }

        //Player Number property
        public int row
        {
            get { return Row_; }
            set { Row_ = value; }
        }

        //Player Number property
        public int column
        {
            get { return Column_; }
            set { Column_ = value; }
        }

        //buttonname Property
        public string buttonname
        {
            get { return Name_; }
            set { Name_ = value; }
        }

        //Create a method when button is clicked 
        void button_Click(object sender, System.EventArgs e)
        {
            Content = "X";
            Stricked_ = 1;
            Background = Brushes.Red;
            MessageBox.Show("Id on this grid = " + this.ButtongridID.ToString() + "\n" +
                            "Stricked Status = " + this.Stricked_.ToString() + "\n" +
                            "Fire To Enemy = " + this.FireToEnemy.ToString()
                                                                                        , "Status Report", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

    }
}
