//-----------------------------------------------------------------------
// <copyright file="DownDirectionCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.DirectionCommands
{
    using Interfaces;
    using Enumerations;

    /// <summary>
    /// Represents the down direction command, which changes the direction of the program counter to downwards.
    /// </summary>
    public class DownDirectionCommand : ICommand
    {
        private ProgramCounter pointer;

        public DownDirectionCommand(ProgramCounter pointer)
        {
            this.pointer = pointer;
        }

        public void Execute()
        {
            this.pointer.CurrentPointerDirection = Direction.Down;
        }
    }
}
