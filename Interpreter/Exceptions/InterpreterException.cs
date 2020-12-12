//-----------------------------------------------------------------------
// <copyright file="CommandExecutionFailedException.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.Exceptions
{
    using System;

    public class InterpreterException : Exception
    {
        public InterpreterException()
        {
        }

        public InterpreterException(string message) : base(message)
        {
        }

        public InterpreterException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}