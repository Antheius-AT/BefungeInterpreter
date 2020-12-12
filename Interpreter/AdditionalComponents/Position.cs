using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter.AdditionalComponents
{
    /// <summary>
    /// Represents a position with two coordinates.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets the x coordinate.
        /// </summary>
        public int X
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the y coordinate.
        /// </summary>
        public int Y
        {
            get;
            set;
        }
    }
}
