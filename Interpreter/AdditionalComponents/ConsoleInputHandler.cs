//-----------------------------------------------------------------------
// <copyright file="ConsoleInputHandler.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.AdditionalComponents
{
    using System;
    using Interfaces;

    /// <summary>
    /// Implementation of input handler for console.
    /// </summary>
    public class ConsoleInputHandler : IInputHandler
    {
        /// <summary>
        /// Acquires character input from a user via the console.
        /// </summary>
        /// <param name="promptMessage">The message that is displayed to the user as prompt.</param>
        /// <returns>The acquired char.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if prompt message is null.
        /// </exception>
        public char AcquireCharacterInput(string promptMessage)
        {
            if (promptMessage == null)
                throw new ArgumentNullException(nameof(promptMessage), "Message must not be null.");

            Console.WriteLine(promptMessage);

            return Console.ReadKey(true).KeyChar;
        }

        /// <summary>
        /// Acquires numeric input from a user via the console.
        /// </summary>
        /// <param name="promptMessage">The message that is displayed to the user as prompt.</param>
        /// <returns>The acquired char.</returns>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if prompt message is null.
        /// </exception>
        public int AcquireNumericInput(string promptMessage)
        {
            if (promptMessage == null)
                throw new ArgumentNullException(nameof(promptMessage), "Message must not be null.");

            int value;
            bool isValid;

            do
            {
                Console.WriteLine(promptMessage);
                isValid = int.TryParse(Console.ReadLine(), out value);
            } 
            while (!isValid);

            return value;
        }
    }
}
