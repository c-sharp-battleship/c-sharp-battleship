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

    using Battleship.CoreComponents;

    /// <summary>
    /// Interaction logic for DefenseGrid.xaml
    /// </summary>
    public partial class DefenseGrid : UserControl
    {
        /// <summary>
        /// The size (in pixels) of each grid space.
        /// </summary>
        private const int pixelGridSize = 20;

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
            templeEllipse.Width = pixelGridSize;
            templeEllipse.Height = height * pixelGridSize;
            Canvas.SetTop(templeEllipse, pixelGridSize);
            Canvas.SetLeft(templeEllipse, pixelGridSize);
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

            // Set 1: Retrieve the current object coordinates.
            var step1Coords = e.GetPosition(sender as IInputElement);

            // Step 2: Round the current canvas coordinates to the nearest ingegral value.
            double[] step2Coords = new double[2] { step1Coords.X, step1Coords.Y };
            
            // Step 3: Convert rounded canvas coordinates to grid coordinates.
            Coordinate step3Coords = ConvertCanvasCoordinatesToGridCoordinates(step2Coords);

            // Step 4: Convert grid coordinates back into canvas coordinates (by multiplying by 20).
            double[] step4Coords = ConvertGridCoordinatesToCanvasCoordinates(step3Coords);

            Logger.ConsoleInformation("Absolute Coordinates: " + step1Coords.X + ", " + step1Coords.Y);
            Logger.ConsoleInformation("Rounded Coordinates: " + step4Coords[0] + ", " + step4Coords[1]);

            Canvas.SetTop(this.dragObject, step4Coords[1]);
            Canvas.SetLeft(this.dragObject, step4Coords[0]);
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

        /// <summary>
        /// Rounds the specified <paramref name="canvasCoords"/> to the nearest integral value.
        /// </summary>
        /// <param name="canvasCoords">The coordinates to be rounded.</param>
        /// <returns>The rounded coordinates.</returns>
        private double[] RoundCanvasCoords(double[] canvasCoords)
        {
            double[] roundedCanvasCoords = new double[2] { 0, 0 };

            roundedCanvasCoords[0] = Math.Round(canvasCoords[0]);
            roundedCanvasCoords[1] = Math.Round(canvasCoords[1]);

            return roundedCanvasCoords;
        }

        // The following methods explicitly reduce percision to the nearest pixelgridsize.

        /// <summary>
        /// Converts the specified <paramref name="roundedCanvasCoords"/> into a <see cref="Coordinate"/> object.
        /// </summary>
        /// <param name="roundedCanvasCoords">The coordinates to be converted.</param>
        /// <returns>The converted coordinates.</returns>
        private Coordinate ConvertCanvasCoordinatesToGridCoordinates(double[] roundedCanvasCoords)
        {
            Coordinate gridCoordinate = new Coordinate();

            gridCoordinate.XCoordinate = (ushort)(roundedCanvasCoords[0] / pixelGridSize);
            gridCoordinate.YCoordinate = (ushort)(roundedCanvasCoords[1] / pixelGridSize);

            return gridCoordinate;
        }

        /// <summary>
        /// Converts the specified <paramref name="testCoordinate"/> into a double array.
        /// </summary>
        /// <param name="testCoordinate">The coordinates to be converted.</param>
        /// <returns>The converted coordinates.</returns>
        private double[] ConvertGridCoordinatesToCanvasCoordinates(Coordinate testCoordinate)
        {
            double[] newCoordinate = new double[2] { 0, 0 };

            newCoordinate[0] = testCoordinate.XCoordinate * pixelGridSize;
            newCoordinate[1] = testCoordinate.YCoordinate * pixelGridSize;

            return newCoordinate;
        }
    }
}
