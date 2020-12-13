//-----------------------------------------------------------------------
// <copyright file="NullCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.BasicCommands
{
    using Interfaces;

    /// <summary>
    /// Represents a null command, which does not have any functionality.
    /// </summary>
    public class NullCommand : ICommand
    {
        /// <summary>
        /// Executes the null command.
        /// </summary>
        public void Execute()
        {
            return;
        }
    }
}
