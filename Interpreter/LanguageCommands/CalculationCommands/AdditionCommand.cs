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
            long first;
            long second;

            this.stack.TryPop(out first);
            this.stack.TryPop(out second);

            this.stack.Push(first + second);
        }
    }
}
