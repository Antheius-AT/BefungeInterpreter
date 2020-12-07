//-----------------------------------------------------------------------
// <copyright file="ICommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.Interfaces
{
    using Exceptions;

    public interface ICommand
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <exception cref="CommandExecutionFailedException">
        /// Is thrown if the command execution failed.
        /// </exception>
        void Execute();
    }
}
