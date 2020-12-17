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
        public ConsoleOutputHandler()
        {
            this.CurrentOutputMode = OutputMode.InLine;
        }

        /// <summary>
        /// Gets the current output mode.
        /// </summary>
        public OutputMode CurrentOutputMode
        {
            get;
            private set;
        }

        public void HandleCharacterOutput(long output)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            switch (this.CurrentOutputMode)
            {
                case OutputMode.InLine:
                    Console.Write((char)output);
                    break;
                case OutputMode.NewLine:
                    Console.WriteLine((char)output);
                    break;
                default:
                    Console.ResetColor();
                    throw new ArgumentException();
            }

            Console.ResetColor();
        }

        public void HandleIntegerOutput(long output)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            switch (this.CurrentOutputMode)
            {
                case OutputMode.InLine:
                    Console.Write($"{(int)output} ");
                    break;
                case OutputMode.NewLine:
                    Console.WriteLine((int)output);
                    break;
                default:
                    Console.ResetColor();
                    throw new ArgumentException();
            }

            Console.ResetColor();
        }

        public void SetOutputMode(OutputMode outputMode)
        {
            if (!Enum.TryParse<OutputMode>(outputMode.ToString(), out OutputMode parsed))
                throw new ArgumentException(nameof(outputMode), "Output mode was invalid.");

            this.CurrentOutputMode = outputMode;
        }
    }
}
