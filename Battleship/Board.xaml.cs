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
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : Window
    {
        public Board()
        {
            InitializeComponent();
            Rectangle gameboard = new Rectangle();
            // gameboard.Fill = Brushes.White;
            Ellipse thing = new Ellipse();
            thing.Fill = Brushes.Blue;
            thing.Width = 100;
            thing.Height = 100;
            Canvas.SetTop(thing, 20);
            Canvas.SetLeft(thing, 20);
            thing.PreviewMouseDown += CanvasMain_OnPreviewMouseDown;
            CanvasMain.Children.Add(thing);
        }

        private UIElement dragObject = null;
        private Point offset;
        private void CanvasMain_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.dragObject = sender as UIElement;
            this.offset = e.GetPosition(this.CanvasMain);
            this.offset.Y -= Canvas.GetTop(this.dragObject);
            this.offset.X -= Canvas.GetLeft(this.dragObject);
            this.CanvasMain.CaptureMouse();
        }
        private void CanvasMain_OnPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (this.dragObject == null)
                return;
            var position = e.GetPosition(sender as IInputElement);
            Canvas.SetTop(this.dragObject, position.Y - this.offset.Y);
            Canvas.SetLeft(this.dragObject, position.X - this.offset.X);
        }

        private void CanvasMain_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.dragObject = null;
            this.CanvasMain.ReleaseMouseCapture();
        }
    }
}
