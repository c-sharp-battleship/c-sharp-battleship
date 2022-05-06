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
        /// The first player's username.
        /// </summary>
        private string player1Username;

        /// <summary>
        /// The second player's username.
        /// </summary>
        private string player2Username;

        /// <summary>
        /// The first player's type.
        /// </summary>
        private StatusCodes.PlayerType player1Type;

        /// <summary>
        /// The second player's type.
        /// </summary>
        private StatusCodes.PlayerType player2Type;

        /// <summary>
        /// The first player's attack board.
        /// </summary>
        private Dictionary<int, StatusCodes.AttackStatus> player1AttackBoard;

        /// <summary>
        /// The second player's attack board.
        /// </summary>
        private Dictionary<int, StatusCodes.AttackStatus> player2AttackBoard;

        /// <summary>
        /// The first player's defense board.
        /// </summary>
        private Dictionary<StatusCodes.ShipType, List<int>> player1DefenseBoard;

        /// <summary>
        /// The second player's defense board.
        /// </summary>
        private Dictionary<StatusCodes.ShipType, List<int>> player2DefenseBoard;

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
        /// Parses the header of each player's CSV space.
        /// </summary>
        /// <param name="playerUsernameObject">The object for the player's username (passed in by reference based on the player's ID).</param>
        /// <param name="playerTypeObject">The object for the player's type (passed in by reference based on the player's ID).</param>
        /// <param name="line">The line of text (header) to be parsed.</param>
        /// <exception cref="ArgumentException">Thrown if the CSV schema is invalid.</exception>
        public void ParseCSVPlayerHeader(ref string playerUsernameObject, ref StatusCodes.PlayerType playerTypeObject, string line)
        {
            string[] playerHeader = line.Split(",");

            if (line.Length != 2)
            {
                Logger.ConsoleInformation("Error: invalid CSV player header!");
                throw new ArgumentException("Error: invalid CSV player header: ", nameof(line));
            }
            else
            {
                playerUsernameObject = playerHeader[0];

                int playerType;

                if (!int.TryParse(playerHeader[1], out playerType))
                {
                    Logger.ConsoleInformation("Error: the second entry in the CSV player header is an invalid integer!");
                    throw new ArgumentException("Error: invalid CSV player header: ", nameof(line));
                }
                else
                {
                    if (playerType == 0)
                    {
                        playerTypeObject = StatusCodes.PlayerType.PLAYER;
                    }
                    else if (playerType == 1)
                    {
                        playerTypeObject = StatusCodes.PlayerType.COMPUTER;
                    }
                    else
                    {
                        throw new ArgumentException("Error: invalid CSV player header: ", nameof(line));
                    }
                }
            }
        }

        /// <summary>
        /// Method that parses the attack board.
        /// </summary>
        /// <param name="attackBoardObject">The object containing the grid spaces that the player attacked (passed in by reference).</param>
        /// <param name="lines">The lines that correspond to the player's attack board.</param>
        /// <exception cref="ArgumentException">Thrown if the CSV schema is invalid.</exception>
        public void ParseCSVPlayerAttackBoard(ref Dictionary<int, StatusCodes.AttackStatus> attackBoardObject, List<string> lines)
        {
            if (lines.Count != 10)
            {
                throw new ArgumentException("Error: invalid CSV player attack board height: ", nameof(lines));
            }
            else
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] separatedLine = lines[i].Split(",");
                    if (separatedLine.Length != 10)
                    {
                        throw new ArgumentException("Error: invalid CSV player attack board width in line" + (i + 1).ToString() + ": ", nameof(separatedLine));
                    }
                    else
                    {
                        int[] separatedLineConverted = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        for (int j = 0; j < separatedLine.Length; j++)
                        {
                            if (!int.TryParse(separatedLine[j], out separatedLineConverted[j]))
                            {
                                throw new ArgumentException("Error: invalid data format in player attack board. Expected: int: ", nameof(separatedLine));
                            }
                            else
                            {
                                switch (separatedLineConverted[j])
                                {
                                    case 1:
                                        attackBoardObject[i + (j * 10)] = StatusCodes.AttackStatus.NOT_ATTACKED;
                                        break;
                                    case 2:
                                        attackBoardObject[i + (j * 10)] = StatusCodes.AttackStatus.ATTACKED_NOT_HIT;
                                        break;
                                    case 3:
                                        attackBoardObject[i + (j * 10)] = StatusCodes.AttackStatus.ATTACKED_HIT;
                                        break;
                                    default:
                                        throw new ArgumentException("Error: invalid attack status in grid space: ", nameof(separatedLine));
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method to parse the player's defense board.
        /// </summary>
        /// <param name="ships">The ships and their crew members.</param>
        /// <param name="lines">The lines to be parsed.</param>
        /// <exception cref="ArgumentException">Thrown if the CSV schema is invalid.</exception>
        public void ParseCSVPlayerDefenseBoard(ref Dictionary<StatusCodes.ShipType, List<int>> ships, List<string> lines)
        {
            if (lines.Count != 10)
            {
                throw new ArgumentException("Error: invalid CSV player defense board height: ", nameof(lines));
            }
            else
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] separatedLine = lines[i].Split(",");
                    if (separatedLine.Length != 10)
                    {
                        throw new ArgumentException("Error: invalid CSV player defense board width: ", nameof(separatedLine));
                    }
                    else
                    {
                        for (int j = 0; j < separatedLine.Length; j++)
                        {
                            switch (separatedLine[j])
                            {
                                case "De":
                                    ships[StatusCodes.ShipType.DESTROYER].Add(i + (j * 10));
                                    break;
                                case "Su":
                                    ships[StatusCodes.ShipType.SUBMARINE].Add(i + (j * 10));
                                    break;
                                case "Cr":
                                    ships[StatusCodes.ShipType.CRUISER].Add(i + (j * 10));
                                    break;
                                case "Ba":
                                    ships[StatusCodes.ShipType.BATTLESHIP].Add(i + (j * 10));
                                    break;
                                case "Ca":
                                    ships[StatusCodes.ShipType.CARRIER].Add(i + (j * 10));
                                    break;
                                case "X":
                                    // Don't do anything if the grid space is empty.
                                    break;
                                default:
                                    throw new ArgumentException("Error: invalid CSV player ship syntax: ", nameof(separatedLine));
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method to parse the entire CSV file.
        /// </summary>
        public void ParseCSV()
        {
            // TODO: Implement Method to Parse CSV File
        }

        /// <summary>
        /// Read a file from a file dialog.
        /// </summary>
        public void ReadFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.FileName = "Game";
            dialog.DefaultExt = ".csv";
            dialog.Filter = "Battleship Game File (.csv)|*.csv";
            dialog.InitialDirectory = @"C:\";

            dialog.ShowDialog();

            try
            {
                using (StreamReader sr = new StreamReader(dialog.FileName))
                {
                    while (sr.Peek() >= 0)
                    {
                        this.fileContents.Add(sr.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.ConsoleInformation(ex.ToString());
            }
        }

        /// <summary>
        /// Method to display the contents of <see cref="fileContents"/>.
        /// </summary>
        public void DisplayFileContents()
        {
            foreach (string line in this.fileContents)
            {
                Logger.Information(line);
            }
        }

        /// <summary>
        /// Method to write to a file.
        /// </summary>
        public void WriteFile()
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.FileName = "Game";
            dialog.DefaultExt = ".csv";
            dialog.Filter = "Battleship Game File (.csv)|*.csv";
            dialog.InitialDirectory = @"C:\";

            dialog.ShowDialog();

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
