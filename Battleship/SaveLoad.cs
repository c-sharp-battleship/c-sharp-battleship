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
        // start of load function
        // Generate new game (Later set GameID to what was loaded)
        // Pull info from file, seperate into seperate arrays
        // loadedP1DefenceArray, etc...
        // P1DefenceArray = loadedP1DefenceArray
        // or
        // foreach entry in loadedP1DefenceArray
        //  temp = loadedP1DefenceArray[x,y]
        //  P1DDefenceArray = temp
        //  x++
        //  y++

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveLoad" /> class.
        /// </summary>
        public SaveLoad()
        {
            List<string> fileContents = this.ReadFile();
            this.WriteFile(fileContents);
        }

        /// <summary>
        /// Read a file from a file dialog.
        /// </summary>
        /// <returns>The contents of the file in a list.</returns>
        private List<string> ReadFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.FileName = "Game";
            dialog.DefaultExt = ".csv";
            dialog.Filter = "Battleship Game File (.csv)|*.csv";
            dialog.InitialDirectory = @"C:\";

            List<string> fileContents = new List<string>();

            using (StreamReader sr = new StreamReader(dialog.FileName))
            {
                while (sr.Peek() >= 0)
                {
                    fileContents.Add(sr.ReadLine());
                }
            }

            return fileContents;
        }

        /// <summary>
        /// Method to write to a file.
        /// </summary>
        /// <param name="fileContents">The contents to be written to the file.</param>
        private void WriteFile(List<string> fileContents)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.FileName = "Game";
            dialog.DefaultExt = ".csv";
            dialog.Filter = "Battleship Game File (.csv)|*.csv";
            dialog.InitialDirectory = @"C:\";

            using (StreamWriter sw = new StreamWriter(dialog.FileName))
            {
                for (int i = 0; i < fileContents.Count; i++)
                {
                    sw.WriteLine(fileContents[i]);
                }
            }
        }
    }
}
