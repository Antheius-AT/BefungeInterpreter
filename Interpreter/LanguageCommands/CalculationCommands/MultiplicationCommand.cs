//-----------------------------------------------------------------------
// <copyright file="MultiplicationCommand.cs" company="FHWN">
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
    /// Represent a command which pops 2 values of the stack, multiplies them and then pushes the result back on the stack.
    /// </summary>
    public class MultiplicationCommand : ICommand
    {
        private Stack<long> stack;

        public MultiplicationCommand(Stack<long> stack)
        {
            this.stack = stack;
        }

        public void Execute()
        {
            if (this.stack.Count < 2)
                throw new CommandExecutionFailedException("Execution of multiplication command failed because too few elements where on stack.");

            var first = this.stack.Pop();
            var second = this.stack.Pop();

            this.stack.Push(first * second);
        }
    }
}
