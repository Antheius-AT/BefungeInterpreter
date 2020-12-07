//-----------------------------------------------------------------------
// <copyright file="CommandExecutionFailedException.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.Exceptions
{
    using System;

    public class CommandExecutionFailedException : Exception
    {
        public CommandExecutionFailedException()
        {
        }

        public CommandExecutionFailedException(string message) : base(message)
        {
        }

        public CommandExecutionFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
