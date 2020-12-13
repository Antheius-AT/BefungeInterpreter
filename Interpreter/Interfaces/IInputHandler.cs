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
        /// <returns>The acquired user input.</returns>
        char AcquireInput(string promptMessage);
    }
}
