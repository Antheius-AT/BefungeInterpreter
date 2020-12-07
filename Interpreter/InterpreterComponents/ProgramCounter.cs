using Interpreter.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter
{
    public class ProgramCounter
    {
        /// <summary>
        /// Advances the program counter by one into the specified direction.
        /// </summary>
        /// <param name="direction">The direction in which to move.</param>
        public void Move(Direction direction)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the current index of the program counter.
        /// </summary>
        public int CurrentIndex
        {
            get;
            private set;
        }
    }
}
