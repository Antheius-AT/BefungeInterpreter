//-----------------------------------------------------------------------
// <copyright file="EndExecutionCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.BasicCommands
{
    using Interfaces;

    /// <summary>
    /// Represent a command that ends execution of the interpreter.
    /// </summary>
    public class EndExecutionCommand : ICommand
    {
        private ProgramCounter pointer;

        public EndExecutionCommand(ProgramCounter pointer)
        {
            this.pointer = pointer;
        }

        public void Execute()
        {
            this.pointer.EndExecution();
        }
    }
}
