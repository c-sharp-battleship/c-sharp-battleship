using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Media;

namespace Battleship.GUIComponents
{
    class NewDefenseGrid : Canvas
    {
        /// <summary>
        /// The object that the user drags.
        /// </summary>
        private UIElement dragObject;

        /// <summary>
        /// The point of the object.
        /// </summary>
        private Point offset;

        private double PixelGridSize;

        /// <summary>
        /// Performs when mouse button is pressed.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void CanvasMain_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.dragObject = sender as UIElement;
            this.offset = e.GetPosition(this);
            this.offset.Y -= Canvas.GetTop(this.dragObject);
            this.offset.X -= Canvas.GetLeft(this.dragObject);
            this.CaptureMouse();
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
            this.ReleaseMouseCapture();
        }
        public NewDefenseGrid(double width, double height, double pixelgridsize) : base()
        {
            this.PixelGridSize = pixelgridsize;

            Ellipse thing = new Ellipse();
            thing.Fill = Brushes.Blue;
            thing.Width = 100;
            thing.Height = 100;
            
            Canvas.SetTop(thing, 20);
            Canvas.SetLeft(thing, 20);
            
            thing.PreviewMouseDown += this.CanvasMain_OnPreviewMouseDown;

            this.Children.Add(thing);
        }
    }
}
