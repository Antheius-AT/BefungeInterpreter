//-----------------------------------------------------------------------
// <copyright file="SwapTopValuesCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.StackManipulationCommands
{
    using System.Collections.Generic;
    using Interfaces;

    /// <summary>
    /// A command that pops 2 values from the stack and swaps them.
    /// </summary>
    public class SwapTopValuesCommand : ICommand
    {
        private Stack<long> stack;

        public SwapTopValuesCommand(Stack<long> stack)
        {
            this.stack = stack;
        }

        public void Execute()
        {
            long first;
            long second;

            this.stack.TryPop(out first);
            this.stack.TryPop(out second);

            this.stack.Push(first);
            this.stack.Push(second);
        }
    }
}
