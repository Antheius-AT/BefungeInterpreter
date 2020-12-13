//-----------------------------------------------------------------------
// <copyright file="HorizontalConditionalCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.DecisionMakingCommands
{
    using System.Collections.Generic;
    using Interfaces;
    using Enumerations;

    /// <summary>
    /// Represents a command which pops a value off the stack and changes the program counters direction based on the value.
    /// If true changes the direction to left. If false, to right.
    /// </summary>
    public class HorizontalConditionalCommand : ICommand
    {
        private Stack<long> stack;
        private ProgramCounter pointer;

        public HorizontalConditionalCommand(Stack<long> stack, ProgramCounter pointer)
        {
            this.stack = stack;
            this.pointer = pointer;
        }

        public void Execute()
        {
            this.stack.TryPop(out long result);

            this.pointer.CurrentPointerDirection = result == 0 ? Direction.Right : Direction.Left;
        }
    }
}
