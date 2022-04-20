//-----------------------------------------------------------------------
// <copyright file="DefenseGrid.xaml.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship.GUIComponents
{
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

    /// <summary>
    /// Interaction logic for DefenseGrid.xaml
    /// </summary>
    public partial class DefenseGrid : UserControl
    {
        /// <summary>
        /// The size (in pixels) of each grid space.
        /// </summary>
        private const int PIXELGRIDSIZE = 20;

        /// <summary>
        /// The object that the user drags.
        /// </summary>
        private UIElement dragObject = null;

        /// <summary>
        /// The point of the object.
        /// </summary>
        private Point offset;

        /// <summary>
        /// The <see cref="Ellipse"/> that refers to the Carrier <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        private Ellipse carrierShip;

        /// <summary>
        /// The <see cref="Ellipse"/> that refers to the Battleship <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        private Ellipse battleshipShip;

        /// <summary>
        /// The <see cref="Ellipse"/> that refers to the Cruiser <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        private Ellipse cruiserShip;

        /// <summary>
        /// The <see cref="Ellipse"/> that refers to the Submarine <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        private Ellipse submarineShip;

        /// <summary>
        /// The <see cref="Ellipse"/> that refers to the Destroyer <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        private Ellipse destroyerShip;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefenseGrid" /> class.
        /// </summary>
        public DefenseGrid()
        {
            this.InitializeComponent();

            this.carrierShip = new Ellipse();
            this.battleshipShip = new Ellipse();
            this.cruiserShip = new Ellipse();
            this.submarineShip = new Ellipse();
            this.destroyerShip = new Ellipse();
        }

        /// <summary>
        /// Generic ship deployment method that is called by <see cref="deployCarrierShip"/>, <see cref="deployBattleshipShip"/>, <see cref="deployCruiserShip"/>, <see cref="deploySubmarineShip"/>, and <see cref="deployDestroyerShip"/>.
        /// </summary>
        /// <param name="templeEllipse"> The <see cref="Ellipse"/> that represents the <see cref="Battleship.CoreComponents.Ship"/> that is to be deployed.</param>
        /// <param name="height">The height (in grid spaces) of the <see cref="Battleship.CoreComponents.Ship"/> to be deployed.</param>
        public void DeployShip(Ellipse templeEllipse, int height)
        {
            templeEllipse.Fill = Brushes.Blue;
            templeEllipse.Width = PIXELGRIDSIZE;
            templeEllipse.Height = height * PIXELGRIDSIZE;
            Canvas.SetTop(templeEllipse, 20);
            Canvas.SetLeft(templeEllipse, 20);
            templeEllipse.PreviewMouseDown += this.CanvasMain_OnPreviewMouseDown;
            this.CanvasMain.Children.Add(templeEllipse);
        }

        /// <summary>
        /// The click event that deploys a Carrier <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        public void DeployCarrierShip()
        {
            this.DeployShip(this.carrierShip, 5);
        }

        /// <summary>
        /// The click event that deploys a Battleship <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        public void DeployBattleshipShip()
        {
            this.DeployShip(this.battleshipShip, 4);
        }

        /// <summary>
        /// The click event that deploys a Cruiser <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        public void DeployCruiserShip()
        {
            this.DeployShip(this.cruiserShip, 3);
        }

        /// <summary>
        /// The click event that deploys a Submarine <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        public void DeploySubmarineShip()
        {
            this.DeployShip(this.submarineShip, 3);
        }

        /// <summary>
        /// The click event that deploys a Destroyer <see cref="Battleship.CoreComponents.Ship"/>.
        /// </summary>
        public void DeployDestroyerShip()
        {
            this.DeployShip(this.destroyerShip, 2);
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
