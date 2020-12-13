//-----------------------------------------------------------------------
// <copyright file="LogicalNotCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.LogicalCommands
{
    using System.Collections.Generic;
    using Interfaces;

    /// <summary>
    /// Represent a command which pops a value off the stack and pushes 1 or 0 to the stack, depending on whether the popped value
    /// is 0 or not.
    /// </summary>
    public class LogicalNotCommand : ICommand
    {
        private Stack<long> stack;

        public LogicalNotCommand(Stack<long> stack)
        {
            this.stack = stack;
        }

        public void Execute()
        {
            this.stack.TryPop(out long result);

            if (result == 0)
                this.stack.Push(1);
            else
                this.stack.Push(0);
        }
    }
}
