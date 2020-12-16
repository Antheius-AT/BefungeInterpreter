//-----------------------------------------------------------------------
// <copyright file="ToggleOutputModeCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.BasicCommands
{
    using AdditionalComponents;
    using Interfaces;

    /// <summary>
    /// Represents a command that toggles the output mode, switching from inline to newline.
    /// </summary>
    public class ToggleOutputModeCommand : ICommand
    {
        private IOutputHandler outputHandler;
        private OutputMode mode;

        public ToggleOutputModeCommand(IOutputHandler outputHandler, OutputMode mode)
        {
            this.outputHandler = outputHandler;
            this.mode = mode;
        }

        public void Execute()
        {
            this.outputHandler.SetOutputMode(mode);
        }
    }
}
