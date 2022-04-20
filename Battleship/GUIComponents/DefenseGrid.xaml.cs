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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Battleship.GUIComponents
{
    /// <summary>
    /// Interaction logic for DefenseGridUserControl.xaml
    /// </summary>
    public partial class DefenseGridUserControl : UserControl
    {
        /// <summary>
        /// The object that the user drags.
        /// </summary>
        private UIElement dragObject = null;

        /// <summary>
        /// The point of the object.
        /// </summary>
        private Point offset;

        private const int PIXEL_GRID_SIZE = 20;

        private Ellipse carrierShip;
        private Ellipse battleshipShip;
        private Ellipse cruiserShip;
        private Ellipse submarineShip;
        private Ellipse destroyerShip;

        public DefenseGridUserControl()
        {
            InitializeComponent();

            carrierShip = new Ellipse();
            battleshipShip = new Ellipse();
            cruiserShip = new Ellipse();
            submarineShip = new Ellipse();
            destroyerShip = new Ellipse();
        }

        public void deployShip(Ellipse templeEllipse, int height)
        {
            templeEllipse.Fill = Brushes.Blue;
            templeEllipse.Width = PIXEL_GRID_SIZE;
            templeEllipse.Height = height * PIXEL_GRID_SIZE;
            Canvas.SetTop(templeEllipse, 20);
            Canvas.SetLeft(templeEllipse, 20);
            templeEllipse.PreviewMouseDown += this.CanvasMain_OnPreviewMouseDown;
            this.CanvasMain.Children.Add(templeEllipse);
        }

        public void deployCarrierShip()
        {
            deployShip(carrierShip, 5);
        }

        public void deployBattleshipShip()
        {
            deployShip(battleshipShip, 4);
        }
        public void deployCruiserShip()
        {
            deployShip(cruiserShip, 3);
        }
        public void deploySubmarineShip()
        {
            deployShip(submarineShip, 3);
        }
        public void deployDestroyerShip()
        {
            deployShip(destroyerShip, 2);
        }

        /// <summary>
        /// Performs when mouse button is pressed.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void CanvasMain_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.dragObject = sender as UIElement;
            this.offset = e.GetPosition(this.CanvasMain);
            this.offset.Y -= Canvas.GetTop(this.dragObject);
            this.offset.X -= Canvas.GetLeft(this.dragObject);
            this.CanvasMain.CaptureMouse();
        }

        /// <summary>
        /// Performs when mouse button is moving.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void CanvasMain_OnPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (this.dragObject == null)
            {
                return;
            }

            var position = e.GetPosition(sender as IInputElement);
            Canvas.SetTop(this.dragObject, position.Y - this.offset.Y);
            Canvas.SetLeft(this.dragObject, position.X - this.offset.X);
        }

        /// <summary>
        /// Performs when mouse button is released.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void CanvasMain_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.dragObject = null;
            this.CanvasMain.ReleaseMouseCapture();
        }
    }
}
