//-----------------------------------------------------------------------
// <copyright file="DiscardTopValueCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.StackManipulationCommands
{
    using System.Collections.Generic;
    using Interfaces;

    /// <summary>
    /// A command that removes the top value from the stack.
    /// </summary>
    public class DiscardTopValueCommand : ICommand
    {
        private Stack<long> stack;

        public DiscardTopValueCommand(Stack<long> stack)
        {
            this.stack = stack;
        }

        public void Execute()
        {
            if (this.stack.Count > 1)
                this.stack.Pop();
        }
    }
}
