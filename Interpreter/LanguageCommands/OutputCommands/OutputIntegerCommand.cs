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
    using Interpreter.Exceptions;

    /// <summary>
    /// Represents a command that pops a value from the stack and outputs it as an integer.
    /// </summary>
    public class OutputIntegerCommand : ICommand
    {
        private IOutputHandler outputHandler;
        private Stack<long> stack;

        public OutputIntegerCommand(IOutputHandler outputHandler, Stack<long> stack)
        {
            this.outputHandler = outputHandler;
            this.stack = stack;
        }

        public void Execute()
        {
            this.stack.TryPop(out long result);

            if (!int.TryParse(result.ToString(), out int parsed))
                throw new CommandExecutionFailedException("Could not execute output integer command, because the value stored in stack was greater than the max value for int32");
            
            this.outputHandler.HandleIntegerOutput(result);
        }
    }
}
