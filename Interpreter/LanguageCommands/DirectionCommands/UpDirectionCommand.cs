//-----------------------------------------------------------------------
// <copyright file="UpDirectionCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.DirectionCommands
{
    using Interfaces;
    using Enumerations;

    /// <summary>
    /// Represent a command which changes the pointer to move up.
    /// </summary>
    public class UpDirectionCommand : ICommand
    {
        private ProgramCounter pointer;

        public UpDirectionCommand(ProgramCounter pointer)
        {
            this.pointer = pointer;
        }

        public void Execute()
        {
            this.pointer.CurrentPointerDirection = Direction.Up;
        }
    }
}
