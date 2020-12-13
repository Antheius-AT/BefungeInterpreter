//-----------------------------------------------------------------------
// <copyright file="LeftDirectionCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.DirectionCommands
{
    using Interfaces;
    using Enumerations;

    /// <summary>
    /// Represent a command which changes the pointer to move left.
    /// </summary>
    public class LeftDirectionCommand : ICommand
    {
        private ProgramCounter pointer;

        public LeftDirectionCommand(ProgramCounter pointer)
        {
            this.pointer = pointer;
        }

        public void Execute()
        {
            this.pointer.CurrentPointerDirection = Direction.Left;
        }
    }
}
