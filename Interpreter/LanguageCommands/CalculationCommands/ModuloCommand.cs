//-----------------------------------------------------------------------
// <copyright file="ModuloCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.CalculationCommands
{
    using System.Collections.Generic;
    using Interfaces;
    using Exceptions;

    /// <summary>
    /// This class represents a command which pops 2 values of the stack and pushes the remainder of their division back onto the stack.
    /// </summary>
    public class ModuloCommand : ICommand
    {
        private Stack<long> stack;

        public ModuloCommand(Stack<long> stack)
        {
            this.stack = stack;
        }

        public void Execute()
        {
            long first;
            long second;

            this.stack.TryPop(out first);
            this.stack.TryPop(out second);

            if (first == 0)
                throw new CommandExecutionFailedException("Could not invoke modulo command, as it is impossible to divide by zero");

            // second is element that was pushed first onto the stack, due to the stacks LIFO nature.
            this.stack.Push(second % first);
        }
    }
}
