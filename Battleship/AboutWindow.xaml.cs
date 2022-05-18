//-----------------------------------------------------------------------
// <copyright file="AboutWindow.xaml.cs" company="David Fedchuk, Gerson Eliu Sorto Flores, Lincoln Kaszynski, Sanaaia Okhlopkova, and Samuel Mace">
//     MIT License, 2022 (https://mit-license.org).
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System.Windows;
    using System.Windows.Navigation;

    /// <summary>
    /// Interaction logic for AboutWindow.xaml.
    /// </summary>
    public partial class AboutWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutWindow" /> class.
        /// </summary>
        public AboutWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Closes the about window.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Opens a hyperlink containing the reference to the license.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://mit-license.org");
        }
    }
}
