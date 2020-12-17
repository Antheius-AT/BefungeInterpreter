//-----------------------------------------------------------------------
// <copyright file="GreaterThanCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.LogicalCommands
{
    using System.Collections.Generic;
    using Interfaces;

    /// <summary>
    /// Represents a command that pops 2 values from the stack and pushes 1 or 0 to the stack
    /// depending on whether value 1 is greater than value 2.
    /// </summary>
    public class GreaterThanCommand : ICommand
    {
        private Stack<long> stack;

        public GreaterThanCommand(Stack<long> stack)
        {
            this.stack = stack;
        }

        public void Execute()
        {
            long first;
            long second;

            this.stack.TryPop(out first);
            this.stack.TryPop(out second);

            if (second > first)
                this.stack.Push(1);
            else
                this.stack.Push(0);
        }
    }
}
