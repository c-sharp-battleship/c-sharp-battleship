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
        public static void LoadGame(ref Dictionary<string, GridCell> gameStatus)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.FileName = "Game";
            dialog.DefaultExt = ".csv";
            dialog.Filter = "Battleship Game File (.csv)|*.csv";
            dialog.InitialDirectory = @"C:\";

            dialog.ShowDialog();

            List<string[]> fileContents = new List<string[]>();

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
                    if (j == 1)
                    {
                        string test = fileContents[i][1];
                        if (test == false.ToString())
                        {
                            System.Windows.Visibility trigger = System.Windows.Visibility.Hidden;
                            string testInt = fileContents[i][0];
                            gameStatus[testInt].Visibility = trigger;
                        }
                    }
                }

                Logger.ConsoleInformationForArray("\n");
            }
        }

        public static void SaveGame(ref Dictionary<string, GridCell> gameStatus)
        {
            try
            {
                SaveFileDialog saveTool = new SaveFileDialog();
                saveTool.InitialDirectory = @"Desktop";
                saveTool.Filter = "Text file|*txt";
                saveTool.FileName = "game";
                saveTool.DefaultExt = ".csv";
                if (saveTool.ShowDialog() == true)
                {
                    StreamWriter outputfile;
                    outputfile = File.CreateText(saveTool.FileName);

                    foreach (KeyValuePair<string, GridCell> test in gameStatus)
                    {
                        System.Windows.Visibility madonna = test.Value.Visibility;
                        bool madonnaIsVisible;

                        if (madonna == System.Windows.Visibility.Visible)
                        {
                            madonnaIsVisible = true;
                        }
                        else
                        {
                            madonnaIsVisible = false;
                        }

                        outputfile.WriteLine(test.Key + "," + madonnaIsVisible.ToString());

                        /*
                       test.Value.ButtonName + "," +
                       test.Value.ShipContainedName + "," +
                       test.Value.ShipContainedType + "," +
                       test.Value.PlayerID + "," +
                       test.Value.OffenseButton + "," +
                       test.Value.LeftToParentLeft.ToString() + "," +
                       test.Value.Stricked + "," +
                       test.Value.Stricked + "," + madonnaIsVisible.ToString() +
                       test.Value.Background + "," +

                       test.Value.PlayerID);
                        */
                    }

                    outputfile.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Information(ex.Message);
            }
        }
    }
}