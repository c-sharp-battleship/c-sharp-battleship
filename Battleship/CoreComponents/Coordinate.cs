//-----------------------------------------------------------------------
// <copyright file="Coordinate.cs" company="Team">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Battleship.CoreComponents
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The class which is used to represent a coordinate.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    internal class Coordinate
    {
        /// <summary>
        /// The y position of the coordinate.
        /// </summary>
        protected short xCoordinate;

        /// <summary>
        /// The y position of the coordinate.
        /// </summary>
        protected short yCoordinate;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Coordinate" /> class.
        /// </summary>
        public Coordinate()
        {
            this.xCoordinate = 0;
            this.yCoordinate = 0;
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Coordinate" /> class.
        /// </summary>
        /// <param name="xCoordinate">The x coordinate</param>
        /// <param name="yCoordinate">The y coordinate.</param>
        public Coordinate(short xCoordinate, short yCoordinate)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }
    }
}
