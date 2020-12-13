//-----------------------------------------------------------------------
// <copyright file="SubtractionCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.CalculationCommands
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Exceptions;

    /// <summary>
    /// Represent a command which pops 2 values off the stack, subtracts them, and pushes the result back onto the stack.
    /// </summary>
    public class SubtractionCommand : ICommand
    {
        private Stack<long> stack;

        public SubtractionCommand(Stack<long> stack)
        {
            this.stack = stack;
        }

        public void Execute()
        {
            long first;
            long second;

            this.stack.TryPop(out first);
            this.stack.TryPop(out second);

            this.stack.Push(second - first);
        }
    }
}
