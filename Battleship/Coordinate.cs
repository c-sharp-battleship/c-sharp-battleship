//-----------------------------------------------------------------------
// <copyright file="Coordinate.cs" company="Battleship Coding Group">
//     Battleship Coding Group, 2022
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship
{
    /// <summary>
    /// Interaction logic for Coordinate
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public class Coordinate
    {
        /// <summary>
        /// The y position of the coordinate.
        /// </summary>
        public short XCoordinate;

        /// <summary>
        /// The y position of the coordinate.
        /// </summary>
        public short YCoordinate;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Coordinate" /> class.
        /// </summary>
        public Coordinate()
        {
            this.XCoordinate = 0;
            this.YCoordinate = 0;
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Coordinate" /> class.
        /// </summary>
        /// <param name="xCoordinate">The x coordinate</param>
        /// <param name="yCoordinate">The y coordinate.</param>
        public Coordinate(short xCoordinate, short yCoordinate)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
        }

        /// <summary>
        /// Gets the letter of the coordinate according to the number of the x coordinate.
        /// </summary>
        public char XCoordinateLetter
        {
            get
            {
                switch (this.XCoordinate)
                {
                    case 1:
                        return 'A';
                        break;
                    case 2:
                        return 'B';
                        break;
                    case 3:
                        return 'C';
                        break;
                    case 4:
                        return 'D';
                        break;
                    case 5:
                        return 'E';
                        break;
                    case 6:
                        return 'F';
                        break;
                    case 7:
                        return 'G';
                        break;
                    case 8:
                        return 'H';
                        break;
                    case 9:
                        return 'I';
                        break;
                    case 10:
                        return 'J';
                        break;
                    default:
                        return 'Z';
                        break;
                }
            }
        }

        public short GetShipID()
        {
            short x = this.XCoordinate;
            short y = (short)(10 * this.YCoordinate);

            return (short)(x + y);
        }
    }
}
