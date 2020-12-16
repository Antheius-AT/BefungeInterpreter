//-----------------------------------------------------------------------
// <copyright file="OutputMode.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.AdditionalComponents
{
    using Interfaces;

    /// <summary>
    /// This enumeration represents possible output modes for the <see cref="IOutputHandler"/> interface.
    /// </summary>
    public enum OutputMode
    {
        /// <summary>
        /// Writes output in line.
        /// </summary>
        InLine,

        /// <summary>
        /// Writes output to a new line
        /// </summary>
        NewLine
    }
}
