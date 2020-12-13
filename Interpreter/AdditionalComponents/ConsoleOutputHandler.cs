//-----------------------------------------------------------------------
// <copyright file="ConsoleOutputHandler.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.AdditionalComponents
{
    using System;
    using Interfaces;

    /// <summary>
    /// Represent the output handler that outputs to the console.
    /// </summary>
    public class ConsoleOutputHandler : IOutputHandler
    {
        public void HandleCharacterOutput(long output)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine((char)output);
            Console.ResetColor();
        }

        public void HandleIntegerOutput(long output)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine((int)output);
            Console.ResetColor();
        }
    }
}
