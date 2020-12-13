//-----------------------------------------------------------------------
// <copyright file="IOutputHandler.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.Interfaces
{
    /// <summary>
    /// Defines an object capable of handling output.
    /// </summary>
    public interface IOutputHandler
    {
        /// <summary>
        /// Handles character output.
        /// </summary>
        /// <param name="output">The character to output.</param>
        void HandleIntegerOutput(long output);

        /// <summary>
        /// Handles integer output.
        /// </summary>
        /// <param name="output">The integer to output.</param>
        void HandleCharacterOutput(long output);
    }
}
