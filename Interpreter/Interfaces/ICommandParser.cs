//-----------------------------------------------------------------------
// <copyright file="ICommandParser.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.Interfaces
{
    using System;

    /// <summary>
    /// This interface defines a command parser, which is a class that is able to parse a character into a befunge command.
    /// </summary>
    public interface ICommandParser
    {
        /// <summary>
        /// Parses the given character into a befunge command.
        /// </summary>
        /// <param name="character">The specified character.</param>
        /// <returns>The parsed command.</returns>
        /// <exception cref="ArgumentException">
        /// Is thrown if the character could not be parsed into a command.
        /// </exception>
        ICommand Parse(char character);

        /// <summary>
        /// Evaluates whether this parser can parse a specified character.
        /// </summary>
        /// <param name="character">The specified character.</param>
        /// <returns>Whether this parser can parse the specificed character.</returns>
        public bool CanParse(char character);

        /// <summary>
        /// Gets a value indicating whether string mode is toggled on or off.
        /// </summary>
        bool IsStringmodeToggled { get; }
        
        /// <summary>
        /// Toggles string mode.
        /// </summary>
        void ToggleStringMode();
    }
}
