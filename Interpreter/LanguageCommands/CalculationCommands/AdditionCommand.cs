//-----------------------------------------------------------------------
// <copyright file="AdditionCommand.cs" company="FHWN">
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
    /// The addition command which pops 2 values off the stack and pushes the sum of them onto the stack.
    /// </summary>
    public class AdditionCommand : ICommand
    {
        private Stack<long> stack;

        public AdditionCommand(Stack<long> stack)
        {
            this.stack = stack;
        }

        public void Execute()
        {
            if (this.stack.Count < 2)
                throw new CommandExecutionFailedException("Could not execute addition command, as the stack did not have enough values pushed.");

            var first = this.stack.Pop();
            var second = this.stack.Pop();
            this.stack.Push(first + second);
        }
    }
}
