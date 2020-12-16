//-----------------------------------------------------------------------
// <copyright file="IOutputHandler.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.Interfaces
{
    using System;
    using AdditionalComponents;

    /// <summary>
    /// Defines an object capable of handling output.
    /// </summary>
    public interface IOutputHandler
    {
        /// <summary>
        /// Gets the current output mode.
        /// </summary>
        OutputMode CurrentOutputMode { get; }

        /// <summary>
        /// Sets the output mode.
        /// </summary>
        /// <param name="outputMode">The new output mode.</param>
        /// <exception cref="ArgumentException">
        /// Is thrown if you specify an output mode that does not exist.
        /// </exception>
        void SetOutputMode(OutputMode outputMode);

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
