using Interpreter.AdditionalComponents;
using Interpreter.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter
{
    public class ProgramCounter
    {
        public ProgramCounter()
        {
            this.CurrentPosition = new Position(0, 0);
            this.CurrentPointerDirection = Direction.Right;
        }

        /// <summary>
        /// Advances the program counter by one into the specified direction.
        /// </summary>
        public void Move()
        {
            switch (this.CurrentPointerDirection)
            {
                case Direction.Up:
                    // If current Y is greater than 0, simply diminish it by 1. If it is 0, wrap around and set Y
                    // to be in the last row.
                    this.CurrentPosition.Y = this.CurrentPosition.Y > 0 ? this.CurrentPosition.Y - 1 : 24;
                    break;
                case Direction.Down:
                    // If current Y is less than 24, simply increment it by 1. If it is 24, wrap around and set Y
                    // to be in the first row.
                    this.CurrentPosition.Y = this.CurrentPosition.Y < 24 ? this.CurrentPosition.Y + 1 : 0;
                    break;
                case Direction.Left:
                    // Same as Direction up, just horizontally.
                    this.CurrentPosition.X = this.CurrentPosition.X > 0 ? this.CurrentPosition.X - 1 : 79;
                    break;
                case Direction.Right:
                    // Same as direction down, just horizontally.
                    this.CurrentPosition.X = this.CurrentPosition.X < 79 ? this.CurrentPosition.X + 1 : 0;
                    break;
                default:
                    throw new InvalidOperationException("Invalid direction");
            }
        }

        /// <summary>
        /// Gets or sets the direction in which the pointer is currently traveling.
        /// </summary>
        public Direction CurrentPointerDirection
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the current index of the program counter.
        /// </summary>
        public Position CurrentPosition
        {
            get;
            private set;
        }
    }
}
