//-----------------------------------------------------------------------
// <copyright file="IInputHandler.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.Interfaces
{
    /// <summary>
    /// Definition for an object capable of getting user input.
    /// </summary>
    public interface IInputHandler
    {
        /// <summary>
        /// Acquires input from the user.
        /// </summary>
        /// <param name="promptMessage">The prompt message displayed to the user.</param>
        /// <returns>The acquired user input.</returns>
        char AcquireCharacterInput(string promptMessage);

        /// <summary>
        /// Acquires numeric input from the user.
        /// </summary>
        /// <param name="promptMessage">The prompt message displayed to the user.</param>
        /// <returns>The input number.</returns>
        int AcquireNumericInput(string promptMessage);
    }
}
