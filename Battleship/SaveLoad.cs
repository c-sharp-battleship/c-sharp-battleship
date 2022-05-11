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
        /// The event that is invoked whenever the gameStatus is changed.
        /// </summary>
        public event EventHandler OnGameStatusUpdate;

        /// <summary>
        /// Enum that represents the schema of each line in the CSV file.
        /// </summary>
        private enum CsvSchema
        {
            /// <summary>
            /// The key that the gameStatus dictionary references.
            /// </summary>
            KEY,

            /// <summary>
            /// The attack status of the <see cref="GridCell"/>.
            /// </summary>
            CELL_ATTACK_STATUS,

            /// <summary>
            /// The column number of the <see cref="GridCell"/>.
            /// </summary>
            COLUMN_NUMBER,

            /// <summary>
            /// The visibility number of the <see cref="GridCell"/>.
            /// </summary>
            CONTENT,

            /// <summary>
            /// The ship that is located on the <see cref="GridCell"/>.
            /// </summary>
            SHIP_CONTAINED_NAME,

            /// <summary>
            /// Whether or not the <see cref="GridCell"/> is an offense button.
            /// </summary>
            OFFENSE_BUTTON,

            /// <summary>
            /// The player ID that the <see cref="GridCell"/> belongs to.
            /// </summary>
            PLAYER_ID,

            /// <summary>
            /// The row number of the <see cref="GridCell"/>.
            /// </summary>
            ROW_NUMBER,

            /// <summary>
            /// The visibility number of the <see cref="GridCell"/>.
            /// </summary>
            VISIBILITY,
        }

        /// <summary>
        /// Method to load the game from a CSV file.
        /// </summary>
        /// <param name="gameStatus">The dictionary object to be "hacked" into using reference magic.</param>
        public void LoadGame(ref Dictionary<string, GridCell> gameStatus)
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
                    string key = string.Empty;
                    for (int j = 0; j < fileContents[i].Length; j++)
                    {
                        if (j == (int)CsvSchema.KEY)
                        {
                            key = fileContents[i][j];
                        }
                        else if (j == (int)CsvSchema.CELL_ATTACK_STATUS)
                        {
                            int outputConversion = 0;
                            if (!int.TryParse(fileContents[i][j], out outputConversion))
                            {
                                Logger.ConsoleInformation("Invalid CSV file format!");
                            }
                            else
                            {
                                gameStatus[key].CellAttackStatus = (StatusCodes.AttackStatus)outputConversion;
                            }
                        }
                        else if (j == (int)CsvSchema.COLUMN_NUMBER)
                        {
                            int outputConversion = 0;
                            if (!int.TryParse(fileContents[i][j], out outputConversion))
                            {
                                Logger.ConsoleInformation("Invalid CSV file format!");
                            }
                            else
                            {
                                gameStatus[key].ColNum = outputConversion;
                            }
                        }
                        else if (j == (int)CsvSchema.CONTENT)
                        {
                            gameStatus[key].ShipContainedName = fileContents[i][j];
                        }
                        else if (j == (int)CsvSchema.SHIP_CONTAINED_NAME)
                        {
                            gameStatus[key].ShipContainedName = fileContents[i][j];
                        }
                        else if (j == (int)CsvSchema.OFFENSE_BUTTON)
                        {
                            bool outputConversion = false;
                            if (!bool.TryParse(fileContents[i][j], out outputConversion))
                            {
                                Logger.ConsoleInformation("Invalid CSV file format!");
                            }
                            else
                            {
                                gameStatus[key].OffenseButton = outputConversion;
                            }
                        }
                        else if (j == (int)CsvSchema.PLAYER_ID)
                        {
                            int outputConversion = 0;
                            if (!int.TryParse(fileContents[i][j], out outputConversion))
                            {
                                Logger.ConsoleInformation("Invalid CSV file format!");
                            }
                            else
                            {
                                gameStatus[key].PlayerID = outputConversion;
                            }
                        }
                        else if (j == (int)CsvSchema.ROW_NUMBER)
                        {
                            int outputConversion = 0;
                            if (!int.TryParse(fileContents[i][j], out outputConversion))
                            {
                                Logger.ConsoleInformation("Invalid CSV file format!");
                            }
                            else
                            {
                                gameStatus[key].RowNum = outputConversion;
                            }
                        }
                        else if (j == (int)CsvSchema.VISIBILITY)
                        {
                            int outputConversion = 0;
                            if (!int.TryParse(fileContents[i][j], out outputConversion))
                            {
                                Logger.ConsoleInformation("Invalid CSV file format!");
                            }
                            else
                            {
                                gameStatus[key].Visibility = (System.Windows.Visibility)outputConversion;
                            }
                        }
                        else
                        {
                            Logger.ConsoleInformation("There was an error. Please contact your nearest software developer for further assistance.");
                        }
                    }
                }

                this.OnGameStatusUpdate?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Logger.Error("File failed to open: " + ex.ToString());
            }
        }

        /// <summary>
        /// Method to save the game into a CSV file.
        /// </summary>
        /// <param name="gameStatus">The dictionary object to be "hacked" into using reference magic.</param>
        public void SaveGame(ref Dictionary<string, GridCell> gameStatus)
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
                            test.Key + "," +
                            (int)test.Value.CellAttackStatus + "," +
                            test.Value.ColNum + "," +
                            test.Value.Content + ", " +
                            test.Value.ShipContainedName + "," +
                            test.Value.OffenseButton + "," +
                            test.Value.PlayerID + "," +
                            test.Value.RowNum + ", " +
                            (int)test.Value.Visibility);
                    }

                    outputfile.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("File failed to save: " + ex.ToString());
            }
        }
    }
}