using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Battleship
{
    /// <summary>
    /// Interaction logic for SetWindow.xaml
    /// </summary>
    public partial class SetWindow : Window
    {
        public SetWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Variables
            double Gameboardwidth; // Create a game board width game size
            double Gameboardheight;//craete a game board height size
            double RowsQty; // Create a row qty check variable
            double ColsQty; // create a column qty
            double mygridsquaresize; // size for each square in grid
            int inches = 96;// 1 inch to pixels
            double Boardtolerance_H; // tolerance for board height
            Boardtolerance_H = 15;// Add Board tolerance at load to display even number of squares
            int Boardtolerance_V = 40; // tolerance for board width



            //!!!!!!!!!!Missing validation for row qty and colqty Please check!!!!!!!!!
            //Validate table grid input to be numeric only
            if ((MWtb_gridtablewidth.Text != "") && (RowQtyInputTxtbox.Text != ""))
            {
                //!!!!!!!!!!Create a check for row qty and colqty!!!!!!!!!!!!!
                if (double.TryParse(MWtb_gridtablewidth.Text, out Gameboardwidth) && double.TryParse(RowQtyInputTxtbox.Text, out RowsQty)
                    && double.TryParse(MWtxt_gridheight.Text, out Gameboardheight))
                {

                    //define grid square sizes for main squares
                    mygridsquaresize = Gameboardheight / RowsQty; // each square measures this
                    ColsQty = Convert.ToInt32(Gameboardwidth) / mygridsquaresize;//define the number of columns



                    if (ColsQty % 2 != 0) // check if number of columns is divisible by two 
                    {
                        ColsQty = ColsQty + 1;// will add one square to make it even all the time
                    }
                    Gameboardwidth = ColsQty * mygridsquaresize;// redefine the play board size



                    if (Gameboardwidth >= 4 && Gameboardwidth <= 13)
                    {


                        // Create instance of grid window
                        WindowCreateGrid mygridwindow = new WindowCreateGrid();
                        mygridwindow.Title = "GridScreen";
                        mygridwindow.Width = (Gameboardwidth * inches) + Boardtolerance_H;
                        mygridwindow.Height = (Gameboardheight * inches) + Boardtolerance_V;


                        /////////////////////attack grid/////////////////////////////////
                        // Create the Grid without gridlines, elements will apply border as gridlines
                        Grid PlayerOneGrid = new Grid();
                        PlayerOneGrid.Width = Gameboardwidth / 2 * inches;
                        PlayerOneGrid.Height = Gameboardheight * inches;
                        PlayerOneGrid.HorizontalAlignment = HorizontalAlignment.Left;
                        PlayerOneGrid.VerticalAlignment = VerticalAlignment.Top;
                        //PlayerOneGrid.ShowGridLines = true;



                        //Define PlayerOneGrid Columns, iterte new columns to user request
                        for (int gridcol = 0; gridcol < ColsQty / 2; gridcol++)
                        {
                            ColumnDefinition colDef = new ColumnDefinition();
                            PlayerOneGrid.ColumnDefinitions.Add(colDef);
                        }

                        //Define PlayerOneGrid rows,iterate new rows to user request
                        for (int gridrow = 0; gridrow < RowsQty; gridrow++)
                        {
                            RowDefinition rowDef = new RowDefinition();
                            PlayerOneGrid.RowDefinitions.Add(rowDef);
                        }


                        // Add the TextBlock elements to the Grid Children collection 
                        int count = 1;

                        //iterate thru counter to set row location loader for this button
                        for (int i = 0; i < RowsQty; i++) //Rows Button loader 
                        {
                            //iterate thru counter to set column nlocation loader for this button
                            for (int j = 0; j < ColsQty / 2; j++)// Columns button loader
                            {
                                if (MainGridChckbox.IsChecked == true)//will create a colored grid
                                {
                                    CustomButton myButton = new CustomButton(count, 1, "Button" + count.ToString());
                                    myButton.Content = count.ToString();
                                    Grid.SetColumn(myButton, j);
                                    Grid.SetRow(myButton, i);
                                    PlayerOneGrid.Children.Add(myButton);//Add This button to my grid location
                                }
                                else
                                {
                                    CustomButton myButton = new CustomButton(count, 1, "Button" + count.ToString());
                                    myButton.Background = Brushes.Transparent;//1new
                                    myButton.BorderBrush = Brushes.White;//2new
                                    myButton.BorderThickness = new Thickness(2);//3new
                                    Grid.SetColumn(myButton, j);
                                    Grid.SetRow(myButton, i);
                                    PlayerOneGrid.Children.Add(myButton);//Add This button to my grid location
                                }
                                count++;
                            }

                        }
                        /////////////////////attack grid/////////////////////////////////

                        /////////////////////Defense grid grid/////////////////////////////////

                        Grid PlayerTwoGrid = new Grid();
                        PlayerTwoGrid.Width = Gameboardwidth / 2 * inches;
                        PlayerTwoGrid.Height = Gameboardheight * inches;
                        PlayerTwoGrid.HorizontalAlignment = HorizontalAlignment.Right;
                        PlayerTwoGrid.VerticalAlignment = VerticalAlignment.Top;
                        PlayerTwoGrid.ShowGridLines = true;



                        //Define PlayerTwoGrid Columns, iterte new columns to user request
                        for (int gridcol = 0; gridcol < ColsQty / 2; gridcol++)
                        {
                            ColumnDefinition colDef = new ColumnDefinition();
                            PlayerTwoGrid.ColumnDefinitions.Add(colDef);
                        }

                        //Define PlayerTwoGrid rows,iterate new rows to user request
                        for (int gridrow = 0; gridrow < RowsQty; gridrow++)
                        {
                            RowDefinition rowDef = new RowDefinition();
                            PlayerTwoGrid.RowDefinitions.Add(rowDef);
                        }


                        // Add the TextBlock elements to the Grid Children collection 
                        int countOpponent = 1;
                        int reversemygrid = PlayerOneGrid.Children.Count;

                        //iterate thru counter to set row location loader for this button
                        for (int i = 0; i < RowsQty; i++) //Rows Button loader 
                        {
                            //iterate thru counter to set column nlocation loader for this button
                            for (int j = 0; j < ColsQty / 2; j++)// Columns button loader
                            {
                                if (MainGridChckbox.IsChecked == true)//will create a colored grid
                                {

                                    CustomButton myButton = new CustomButton(reversemygrid, 2, "Button" + reversemygrid.ToString());
                                    myButton.Content = reversemygrid.ToString();
                                    Grid.SetColumn(myButton, j);
                                    Grid.SetRow(myButton, i);
                                    PlayerTwoGrid.Children.Add(myButton);//Add This button to my grid location
                                }
                                else
                                {
                                    CustomButton myButton = new CustomButton(reversemygrid, 2, "Button" + reversemygrid.ToString());
                                    myButton.Name = "Button" + reversemygrid.ToString();
                                    myButton.Background = Brushes.Transparent;//1new
                                    myButton.BorderBrush = Brushes.White;//2new
                                    myButton.BorderThickness = new Thickness(2);//3new
                                    Grid.SetColumn(myButton, j);
                                    Grid.SetRow(myButton, i);
                                    PlayerTwoGrid.Children.Add(myButton);//Add This button to my grid location
                                }
                                countOpponent++;
                                reversemygrid--;

                            }

                        }

                        //Add Exit Button to my grid window
                        Button mygridExitButton = new Button();
                        mygridExitButton.Click += new RoutedEventHandler(Button_Click);

                        void Button_Click(object sender, EventArgs e)
                        {
                            MessageBox.Show("yes");
                        }


                        // Add the Grid as the Content of the Parent Window Object
                        if (Radioplayer1.IsChecked == true)
                        {
                            mygridwindow.Content = PlayerOneGrid;
                        }
                        if (Radioplayer2.IsChecked == true)
                        {
                            mygridwindow.Content = PlayerTwoGrid;
                        }

                        mygridwindow.Show();//show my window

                    }
                    else
                    {
                        MessageBox.Show("Board size can't be less than 4 or over 10 inches, Please try again", "No Data", MessageBoxButton.OK, MessageBoxImage.Information);
                        MWtb_gridtablewidth.Clear();
                        MWtb_gridtablewidth.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Input must be numeric value, Please try again", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                    MWtb_gridtablewidth.Clear();
                    MWtb_gridtablewidth.Focus();
                }
            }
            else
            {
                MessageBox.Show("Board size can't be zero, Please try again", "No Data", MessageBoxButton.OK, MessageBoxImage.Information);
                MWtb_gridtablewidth.Clear();
                MWtb_gridtablewidth.Focus();
            }
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void MWtb_gridtablewidth_MouseEnter(object sender, MouseEventArgs e)
        {
            // Create the ToolTip and associate with the Form container.
            ToolTip BoardWidthTip = new ToolTip();
            BoardWidthTip.Content = "Enter Value In inches no greater than 10";
            MWtb_gridtablewidth.ToolTip = BoardWidthTip;
        }

        private void DoDrageventbtn_Click(object sender, RoutedEventArgs e)
        {
            DragDropWindow dragdropcase = new DragDropWindow();
            dragdropcase.Show();
        }



        private void CanvaCreate_Click(object sender, RoutedEventArgs e)
        {
            CanvasWindow mycanva = new CanvasWindow();

            Canvas myParentCanvas = new Canvas();
            myParentCanvas.Width = 1152;
            myParentCanvas.Height = 752;


            double multi = 19.2;
            //iterate thru counter to set row location loader for this button
            for (int i = 0; i < 60; i++) //Rows Button loader 
            {
                double messedup;

                Button myButton = new Button();
                myButton.Content = i.ToString();
                myButton.Width = multi;
                myButton.Margin = new Thickness(0);
                Canvas.SetTop(myButton, 0);
                Canvas.SetLeft(myButton, i* multi);
                myParentCanvas.Children.Add(myButton);//Add This button to my grid location
                messedup = i * multi;


            }


            mycanva.Content = myParentCanvas;
            mycanva.Show();


        }

        private void MoveEvent_Click(object sender, RoutedEventArgs e)
        {
            Board MoveElipseWindow = new Board();
            MoveElipseWindow.Show();
        }
    }
}
