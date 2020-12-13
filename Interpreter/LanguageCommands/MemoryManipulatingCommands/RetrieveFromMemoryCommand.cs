//-----------------------------------------------------------------------
// <copyright file="RetrieveFromMemoryCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.MemoryManipulatingCommands
{
    using System.Collections.Generic;
    using Interfaces;

    /// <summary>
    /// Retrieves a value at a position specified by the two upper most stack values (serving as X and Y) and pushes
    /// it onto the upper most position on the stack.
    /// </summary>
    public class RetrieveFromMemoryCommand : ICommand
    {
        private Stack<long> stack;
        private Torus torus;

        public RetrieveFromMemoryCommand(Stack<long> stack, Torus torus)
        {
            this.stack = stack;
            this.torus = torus;
        }

        public void Execute()
        {
            long y;
            long x;

            this.stack.TryPop(out y);
            this.stack.TryPop(out x);

            if (x > this.torus.Width - 1 || y > this.torus.Height - 1)
                this.stack.Push(0);
            else
                this.stack.Push(this.torus.TorusContent[x, y]);
        }
    }
}
