//-----------------------------------------------------------------------
// <copyright file="SaveLoad.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    using Microsoft.Win32;

    /// <summary>
    /// Class to save the game state.
    /// </summary>
    internal class SaveLoad
    {
        /// <summary>
        /// The list of file contents.
        /// </summary>
        private List<string> fileContents;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveLoad" /> class.
        /// </summary>
        public SaveLoad()
        {
            this.fileContents = new List<string>();
        }

        /// <summary>
        /// Gets or sets the fileContents.
        /// </summary>
        public List<string> FileContents
        {
            get { return this.fileContents; }
            set { this.fileContents = value; }
        }

        /// <summary>
        /// Read a file from a file dialog.
        /// </summary>
        private void ReadFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.FileName = "Game";
            dialog.DefaultExt = ".csv";
            dialog.Filter = "Battleship Game File (.csv)|*.csv";
            dialog.InitialDirectory = @"C:\";

            using (StreamReader sr = new StreamReader(dialog.FileName))
            {
                while (sr.Peek() >= 0)
                {
                    this.fileContents.Add(sr.ReadLine());
                }
            }
        }

        /// <summary>
        /// Method to write to a file.
        /// </summary>
        private void WriteFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.FileName = "Game";
            dialog.DefaultExt = ".csv";
            dialog.Filter = "Battleship Game File (.csv)|*.csv";
            dialog.InitialDirectory = @"C:\";

            using (StreamWriter sw = new StreamWriter(dialog.FileName))
            {
                for (int i = 0; i < this.fileContents.Count; i++)
                {
                    sw.WriteLine(this.fileContents[i]);
                }
            }
        }
    }
}
