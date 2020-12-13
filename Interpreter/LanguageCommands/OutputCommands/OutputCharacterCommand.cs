//-----------------------------------------------------------------------
// <copyright file="OutputIntegerCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.OutputCommands
{
    using System.Collections.Generic;
    using Interfaces;

    /// <summary>
    /// Represents a command that pops a value from the stack and outputs it as a character.
    /// </summary>
    public class OutputCharacterCommand : ICommand
    {
        private IOutputHandler outputHandler;
        private Stack<long> stack;

        public OutputCharacterCommand(IOutputHandler outputHandler, Stack<long> stack)
        {
            this.outputHandler = outputHandler;
            this.stack = stack;
        }

        public void Execute()
        {
            this.stack.TryPop(out long result);

            this.outputHandler.HandleCharacterOutput(result);
        }
    }
}
