//-----------------------------------------------------------------------
// <copyright file="CanvasWindow.xaml.cs" company="Team">
//     Company copyright tag.
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
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for CanvasWindow.xaml
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public partial class CanvasWindow : Window
    {
        /// <summary>
        /// The canvas.
        /// </summary>
        private Canvas myParentCanvas = new Canvas();

        /// <summary>
        ///  Initializes a new instance of the <see cref="CanvasWindow" /> class.
        /// </summary>
        public CanvasWindow()
        {
            this.InitializeComponent();
        }
    }
}
