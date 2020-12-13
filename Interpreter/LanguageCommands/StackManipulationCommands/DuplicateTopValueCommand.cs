//-----------------------------------------------------------------------
// <copyright file="DuplicateTopValueCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.StackManipulationCommands
{
    using System.Collections.Generic;
    using Interfaces;

    /// <summary>
    /// Represent a command that duplicates the top value on the stack.
    /// </summary>
    public class DuplicateTopValueCommand : ICommand
    {
        private Stack<long> stack;

        public DuplicateTopValueCommand(Stack<long> stack)
        {
            this.stack = stack;
        }

        public void Execute()
        {
            this.stack.TryPeek(out long result);

            this.stack.Push(result);
        }
    }
}
