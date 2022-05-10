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
    using Microsoft.Win32;

    /// <summary>
    /// Class to save the game state.
    /// </summary>
    internal class SaveLoad
    {
        /// <summary>
        /// Enum that represents the schema of each line in the CSV file.
        /// </summary>
        private enum CsvSchema
        {
            /// <summary>
            /// The attack status of the <see cref="GridCell"/>.
            /// </summary>
            ATTACK_STATUS,

            /// <summary>
            /// The player ID that the <see cref="GridCell"/> belongs to.
            /// </summary>
            PLAYER_ID,

            /// <summary>
            /// The ship that is located on the <see cref="GridCell"/>.
            /// </summary>
            CONTAINED_SHIP_NAME,

            /// <summary>
            /// The column number of the <see cref="GridCell"/>.
            /// </summary>
            COLUMN_NUMBER,

            /// <summary>
            /// The row number of the <see cref="GridCell"/>.
            /// </summary>
            ROW_NUMBER,

            /// <summary>
            /// Whether or not the <see cref="GridCell"/> is an offense button.
            /// </summary>
            OFFENSE_BUTTON,
        }

        /// <summary>
        /// Method to load the game from a CSV file.
        /// </summary>
        /// <param name="gameStatus">The dictionary object to be "hacked" into using reference magic.</param>
        public static void LoadGame(ref Dictionary<string, GridCell> gameStatus)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.FileName = "Game";
            dialog.DefaultExt = ".csv";
            dialog.Filter = "Battleship Game File (.csv)|*.csv";
            dialog.InitialDirectory = @"Desktop";

            dialog.ShowDialog();

            List<string[]> fileContents = new List<string[]>();

            try
            {
                using (StreamReader sr = new StreamReader(dialog.FileName))
                {
                    while (sr.Peek() >= 0)
                    {
                        fileContents.Add(sr.ReadLine().Split(","));
                    }
                }

                for (int i = 0; i < fileContents.Count; i++)
                {
                    for (int j = 0; j < fileContents[i].Length; j++)
                    {
                        if(j == (int)CsvSchema.ATTACK_STATUS)
                        {
                            Logger.ConsoleInformation("Loaded: " + fileContents[i][j]);
                        }
                        else if(j == (int)CsvSchema.COLUMN_NUMBER)
                        {
                            Logger.ConsoleInformation("Loaded: " + fileContents[i][j]);
                        }
                        else if(j == (int)CsvSchema.CONTAINED_SHIP_NAME)
                        {
                            Logger.ConsoleInformation("Loaded: " + fileContents[i][j]);
                        }
                        else if(j == (int)CsvSchema.OFFENSE_BUTTON)
                        {
                            Logger.ConsoleInformation("Loaded: " + fileContents[i][j]);
                        }
                        else if(j == (int)CsvSchema.PLAYER_ID)
                        {
                            Logger.ConsoleInformation("Loaded: " + fileContents[i][j]);
                        }
                        else if(j == (int)CsvSchema.ROW_NUMBER)
                        {
                            Logger.ConsoleInformation("Loaded: " + fileContents[i][j]);
                        }
                        else
                        {
                            Logger.ConsoleInformation("There was an error. Please contact your nearest software developer for further assistance.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("File failed to open!");
            }
        }

        /// <summary>
        /// Method to save the game into a CSV file.
        /// </summary>
        /// <param name="gameStatus">The dictionary object to be "hacked" into using reference magic.</param>
        public static void SaveGame(ref Dictionary<string, GridCell> gameStatus)
        {
            try
            {
                SaveFileDialog saveTool = new SaveFileDialog();
                saveTool.InitialDirectory = @"Desktop";
                saveTool.Filter = "Battleship Game File (.csv)|*.csv";
                saveTool.FileName = "Game";
                saveTool.DefaultExt = ".csv";

                if (saveTool.ShowDialog() == true)
                {
                    StreamWriter outputfile;
                    outputfile = File.CreateText(saveTool.FileName);

                    foreach (KeyValuePair<string, GridCell> test in gameStatus)
                    {
                        outputfile.WriteLine(
                            test.Value.CellAttackStatus + ", " +
                            test.Value.ColNum + ", " +
                            test.Value.ShipContainedName + ", " +
                            test.Value.OffenseButton + ", " +
                            test.Value.PlayerID + ", " +
                            test.Value.RowNum);
                    }

                    outputfile.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("File failed to save!");
            }
        }
    }
}