//-----------------------------------------------------------------------
// <copyright file="RightDirectionCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.DirectionCommands
{
    using Interfaces;
    using Enumerations;

    /// <summary>
    /// Represent a command which changes the pointer to move right.
    /// </summary>
    public class RightDirectionCommand : ICommand
    {
        private ProgramCounter pointer;

        public RightDirectionCommand(ProgramCounter pointer)
        {
            this.pointer = pointer;
        }

        public void Execute()
        {
            this.pointer.CurrentPointerDirection = Direction.Right;
        }
    }
}
