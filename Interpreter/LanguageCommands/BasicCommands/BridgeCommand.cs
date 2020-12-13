//-----------------------------------------------------------------------
// <copyright file="BridgeCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.BasicCommands
{
    using Interfaces;

    /// <summary>
    /// Represents a command that moves the program counter one further, to skip the next command.
    /// </summary>
    public class BridgeCommand : ICommand
    {
        private ProgramCounter pointer;

        public BridgeCommand(ProgramCounter pointer)
        {
            this.pointer = pointer;
        }

        public void Execute()
        {
            this.pointer.Move();
        }
    }
}
