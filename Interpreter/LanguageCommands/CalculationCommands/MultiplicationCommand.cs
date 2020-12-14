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
            long first;
            long second;

            this.stack.TryPop(out first);
            this.stack.TryPop(out second);

            this.stack.Push(second * first);
        }
    }
}
