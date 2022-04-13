//-----------------------------------------------------------------------
// <copyright file="Board.xaml.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
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
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public partial class Board : Window
    {
        /// <summary>
        /// The object that the user drags.
        /// </summary>
        private UIElement dragObject = null;

        /// <summary>
        /// The point of the object.
        /// </summary>
        private Point offset;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Board" /> class.
        /// </summary>
        public Board()
        {
            this.InitializeComponent();
            Rectangle gameboard = new Rectangle();
            //// gameboard.Fill = Brushes.White;
            Ellipse thing = new Ellipse();
            thing.Fill = Brushes.Blue;
            thing.Width = 100;
            thing.Height = 100;
            Canvas.SetTop(thing, 20);
            Canvas.SetLeft(thing, 20);
            thing.PreviewMouseDown += this.CanvasMain_OnPreviewMouseDown;
            CanvasMain.Children.Add(thing);
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
