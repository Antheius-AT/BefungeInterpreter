//-----------------------------------------------------------------------
// <copyright file="PutToMemoryCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.MemoryManipulatingCommands
{
    using System.Collections.Generic;
    using Interfaces;
    using Exceptions;

    /// <summary>
    /// Represent a command that pushes 3 values, serving as x, y and v from the stack, and then
    /// writes the character v to the position specified by x and y in the torus.
    /// </summary>
    public class PutToMemoryCommand : ICommand
    {
        private Stack<long> stack;
        private Torus torus;

        public PutToMemoryCommand(Stack<long> stack, Torus torus)
        {
            this.stack = stack;
            this.torus = torus;
        }

        public void Execute()
        {
            long y;
            long x;
            long value;

            this.stack.TryPop(out y);
            this.stack.TryPop(out x);
            this.stack.TryPop(out value);

            if (x > this.torus.Width - 1 || y > this.torus.Height - 1)
                throw new CommandExecutionFailedException($"Could not execute put command to modify code as the coordinates were out of bounds. Coordinates as popped from the stack where: ({x}|{y})");
            else
                this.torus.TorusContent[x, y] = (char)value;
        }
    }
}
