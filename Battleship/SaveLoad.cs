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
        /// The number of lines that make up a CSV player header.
        /// </summary>
        private const ushort NumLinesCsvPlayerHeader = 1;

        /// <summary>
        /// The number of lines that make up a CSV player attack board.
        /// </summary>
        private const ushort NumLinesCsvPlayerAttackBoard = 10;

        /// <summary>
        /// The number of lines that make up a CSV player defense board.
        /// </summary>
        private const ushort NumLinesCsvPlayerDefenseBoard = 10;

        /// <summary>
        /// The number of cells that can exist for each line of a file (per the CSV schema).
        /// </summary>
        private const ushort NumCellsPerLine = 10;

        /// <summary>
        /// The number of lines that can exist for each player's board (per the CSV schema).
        /// </summary>
        private const ushort NumLinesPerBoard = 10;

        /// <summary>
        /// The number of lines that make up a CSV player.
        /// </summary>
        private const ushort NumLinesCsvPlayer =
            NumLinesCsvPlayerHeader + NumLinesCsvPlayerAttackBoard + NumLinesCsvPlayerDefenseBoard;

        /// <summary>
        /// The number of lines that make up an entire CSV project file.
        /// </summary>
        private const ushort NumLinesCsv = 2 * NumLinesCsvPlayer;

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
        /// Loads the header of each player's CSV space.
        /// </summary>
        /// <param name="playerUsernameObject">The object for the player's username (passed in by reference based on the player's ID).</param>
        /// <param name="playerTypeObject">The object for the player's type (passed in by reference based on the player's ID).</param>
        /// <param name="line">The line of text (header) to be loaded.</param>
        /// <exception cref="ArgumentException">Thrown if the CSV schema is invalid.</exception>
        public void LoadCsvPlayerHeader(
            ref string playerUsernameObject,
            ref StatusCodes.PlayerType playerTypeObject,
            string line)
        {
            string[] playerHeader = line.Split(",");

            if (line.Length != SaveLoad.NumLinesCsvPlayerHeader)
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
                    Logger.ConsoleInformation(
                        "Error: the second entry in the CSV player header is an invalid integer!");
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
        /// Method that Loads the attack board.
        /// </summary>
        /// <param name="attackBoardObject">The object containing the grid spaces that the player attacked (passed in by reference).</param>
        /// <param name="lines">The lines that correspond to the player's attack board.</param>
        /// <exception cref="ArgumentException">Thrown if the CSV schema is invalid.</exception>
        public void LoadCsvPlayerAttackBoard(
            ref Dictionary<int, StatusCodes.AttackStatus> attackBoardObject,
            List<string> lines)
        {
            if (lines.Count != SaveLoad.NumLinesCsvPlayerAttackBoard)
            {
                throw new ArgumentException("Error: invalid CSV player attack board height: ", nameof(lines));
            }
            else
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] separatedLine = lines[i].Split(",");
                    if (separatedLine.Length != SaveLoad.NumCellsPerLine)
                    {
                        throw new ArgumentException(
                            "Error: invalid CSV player attack board width in line" + (i + 1).ToString() + ": ",
                            nameof(separatedLine));
                    }
                    else
                    {
                        int[] separatedLineConverted = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        for (int j = 0; j < separatedLine.Length; j++)
                        {
                            if (!int.TryParse(separatedLine[j], out separatedLineConverted[j]))
                            {
                                throw new ArgumentException(
                                    "Error: invalid data format in player attack board. Expected: int: ",
                                    nameof(separatedLine));
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
                                        throw new ArgumentException(
                                            "Error: invalid attack status in grid space: ",
                                            nameof(separatedLine));
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method to Load the player's defense board.
        /// </summary>
        /// <param name="ships">The ships and their crew members.</param>
        /// <param name="lines">The lines to be Loadd.</param>
        /// <exception cref="ArgumentException">Thrown if the CSV schema is invalid.</exception>
        public void LoadCsvPlayerDefenseBoard(
            ref Dictionary<StatusCodes.ShipType, List<int>> ships,
            List<string> lines)
        {
            if (lines.Count != SaveLoad.NumLinesCsvPlayerDefenseBoard)
            {
                throw new ArgumentException("Error: invalid CSV player defense board height: ", nameof(lines));
            }
            else
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] separatedLine = lines[i].Split(",");
                    if (separatedLine.Length != SaveLoad.NumCellsPerLine)
                    {
                        throw new ArgumentException(
                            "Error: invalid CSV player defense board width: ",
                            nameof(separatedLine));
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
                                    throw new ArgumentException(
                                        "Error: invalid CSV player ship syntax: ",
                                        nameof(separatedLine));
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method that Loads the player sections of a CSV file.
        /// </summary>
        /// <param name="playerUsernameObject">The player's username (passed in by reference).</param>
        /// <param name="playerTypeObject">The player's type (passed in by reference).</param>
        /// <param name="attackBoardObject">The player's attack board (passed in by reference).</param>
        /// <param name="ships">The player's ship collection (defense board) (passed in by reference).</param>
        /// <param name="lines">The information about the player (in CSV format).</param>
        public void LoadCsvPlayer(
            ref string playerUsernameObject,
            ref StatusCodes.PlayerType playerTypeObject,
            ref Dictionary<int, StatusCodes.AttackStatus> attackBoardObject,
            ref Dictionary<StatusCodes.ShipType, List<int>> ships,
            List<string> lines)
        {
            if (lines.Count != SaveLoad.NumLinesCsvPlayer)
            {
                throw new ArgumentException("Error: invalid CSV player content: ", nameof(lines));
            }
            else
            {
                string playerHeader = lines[0];

                List<string> playerAttackBoard = new List<string>();
                List<string> playerDefenseBoard = new List<string>();

                for (ushort i = SaveLoad.NumLinesCsvPlayerHeader;
                     i < (SaveLoad.NumLinesCsvPlayerHeader + SaveLoad.NumLinesCsvPlayerAttackBoard);
                     i++)
                {
                    playerAttackBoard.Add(lines[i]);
                }

                for (ushort i = SaveLoad.NumLinesCsvPlayerHeader + SaveLoad.NumLinesCsvPlayerAttackBoard;
                     i < (SaveLoad.NumLinesCsvPlayerAttackBoard + SaveLoad.NumLinesCsvPlayerDefenseBoard);
                     i++)
                {
                    playerDefenseBoard.Add(lines[i]);
                }

                this.LoadCsvPlayerHeader(ref playerUsernameObject, ref playerTypeObject, playerHeader);
                this.LoadCsvPlayerAttackBoard(ref attackBoardObject, playerAttackBoard);
                this.LoadCsvPlayerDefenseBoard(ref ships, playerDefenseBoard);
            }
        }

        /// <summary>
        /// Method to Load the entire CSV file.
        /// </summary>
        public void LoadCsv()
        {
            if (this.fileContents.Count != SaveLoad.NumLinesCsv)
            {
                throw new ArgumentException("Error: invalid CSV player content: ", nameof(this.fileContents));
            }
            else
            {
                List<string> player1Csv = new List<string>();
                List<string> player2Csv = new List<string>();

                for (ushort i = 0; i < SaveLoad.NumLinesCsvPlayer; i++)
                {
                    player1Csv.Add(this.fileContents[i]);
                }

                for (ushort i = SaveLoad.NumLinesCsvPlayer; i < 2 * SaveLoad.NumLinesCsvPlayer; i++)
                {
                    player2Csv.Add(this.fileContents[i]);
                }

                this.LoadCsvPlayer(
                    ref this.player1Username,
                    ref this.player1Type,
                    ref this.player1AttackBoard,
                    ref this.player1DefenseBoard,
                    player1Csv);
                this.LoadCsvPlayer(
                    ref this.player2Username,
                    ref this.player2Type,
                    ref this.player2AttackBoard,
                    ref this.player2DefenseBoard,
                    player2Csv);
            }
        }

        /// <summary>
        /// Saves the player's header in CSV format (per the CSV schema).
        /// </summary>
        /// <param name="playerUsernameObject">The username of the given player (passed in by reference).</param>
        /// <param name="playerTypeObject">The type of the given player (passed in by reference).</param>
        /// <returns>The CSV-formatted player header.</returns>
        public string SaveCsvPlayerHeader(ref string playerUsernameObject, ref StatusCodes.PlayerType playerTypeObject)
        {
            string playerHeader = string.Empty;

            if (playerTypeObject == StatusCodes.PlayerType.PLAYER)
            {
                playerHeader += playerUsernameObject + "," + "0";
            }
            else if (playerTypeObject == StatusCodes.PlayerType.COMPUTER)
            {
                playerHeader += playerUsernameObject + "," + "1";
            }

            return playerHeader;
        }

        /// <summary>
        /// Saves the given player's attack board in CSV format (per the schema).
        /// </summary>
        /// <param name="playerAttackBoardObject">The given user's attack board (passed in by reference).</param>
        /// <returns>The CSV-formatted attack board.</returns>
        public List<string> SaveCsvPlayerAttackBoard(
            ref Dictionary<int, StatusCodes.AttackStatus> playerAttackBoardObject)
        {
            List<string> lines = new List<string>();

            for (int i = 0; i < SaveLoad.NumLinesPerBoard; i++)
            {
                string line = string.Empty;

                for (int j = 0; j < SaveLoad.NumCellsPerLine; j++)
                {
                    line += playerAttackBoardObject[i + (j * 10)];

                    // If the cell is not the last in the line, add a comma.
                    if (j != (SaveLoad.NumCellsPerLine - 1))
                    {
                        line += ",";
                    }
                }

                lines.Add(line);
            }

            return lines;
        }

        /// <summary>
        /// Saves the player's defense board in CSV format (per the schema).
        /// </summary>
        /// <param name="playerDefenseBoardObject">The player's defense board object (passed in by reference).</param>
        /// <returns>The CSV-formatted player defense board.</returns>
        public List<string> SaveCsvPlayerDefenseBoard(
            ref Dictionary<StatusCodes.ShipType, List<int>> playerDefenseBoardObject)
        {
            List<string> lines = new List<string>();

            for (int i = 0; i < SaveLoad.NumLinesPerBoard; i++)
            {
                string line = string.Empty;

                for (int j = 0; j < SaveLoad.NumCellsPerLine; j++)
                {
                    string gridspace = string.Empty;

                    // Loop through each of the ships and their crewmembers to see if they are located on the ship.
                    for (int k = 0; k < playerDefenseBoardObject.Count; k++)
                    {
                        foreach (int crewmember in playerDefenseBoardObject[(StatusCodes.ShipType)k])
                        {
                            if (crewmember == i + (j * 10))
                            {
                                switch ((StatusCodes.ShipType)k)
                                {
                                    case StatusCodes.ShipType.DESTROYER:
                                        gridspace = "De";
                                        break;
                                    case StatusCodes.ShipType.SUBMARINE:
                                        gridspace = "Su";
                                        break;
                                    case StatusCodes.ShipType.CRUISER:
                                        gridspace = "Cr";
                                        break;
                                    case StatusCodes.ShipType.BATTLESHIP:
                                        gridspace = "Ba";
                                        break;
                                    case StatusCodes.ShipType.CARRIER:
                                        gridspace = "Ca";
                                        break;
                                    default:
                                        gridspace = "X";
                                        break;
                                }
                            }
                        }
                    }

                    line += gridspace;

                    // If the cell is not the last in the line, add a comma.
                    if (j != (SaveLoad.NumCellsPerLine - 1))
                    {
                        line += ",";
                    }
                }

                lines.Add(line);
            }

            return lines;
        }

        /// <summary>
        /// Saves the player's information in CSV format (per the schema).
        /// </summary>
        /// <returns>The player's information in CSV-format (per the schema).</returns>
        public List<string> SaveCsvPlayer()
        {
            List<string> lines = new List<string>();

            return lines;
        }

        /// <summary>
        /// Saves the current class-member objects to a CSV file according to the schema.
        /// </summary>
        /// <returns>The entire CSV file to be written (per the schema).</returns>
        public List<string> SaveCsV()
        {
            List<string> lines = new List<string>();

            return lines;
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

                this.LoadCsv();
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

            List<string> lines = this.SaveCsV();

            try
            {
                using (StreamWriter sw = new StreamWriter(dialog.FileName))
                {
                    for (int i = 0; i < lines.Count; i++)
                    {
                        sw.WriteLine(lines[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.ConsoleInformation(ex.ToString());
            }
        }
    }
}