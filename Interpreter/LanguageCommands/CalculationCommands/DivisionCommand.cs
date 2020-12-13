//-----------------------------------------------------------------------
// <copyright file="DivisionCommand.cs" company="FHWN">
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
    /// This class represents a command which pops 2 values of the stack and pushes the result of their division back onto the stack.
    /// </summary>
    public class DivisionCommand : ICommand
    {
        private Stack<long> stack;

        public DivisionCommand(Stack<long> stack)
        {
            this.stack = stack;
        }

        public void Execute()
        {
            long first;
            long second;

            this.stack.TryPop(out first);
            this.stack.TryPop(out second);

            this.stack.Push(second / first);
        }
    }
}
