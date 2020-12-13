//-----------------------------------------------------------------------
// <copyright file="ToggleStringModeCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.BasicCommands
{
    using System;
    using Interfaces;

    /// <summary>
    /// A command that toggles string mode.
    /// </summary>
    public class ToggleStringModeCommand : ICommand
    {
        private Action action;

        public ToggleStringModeCommand(Action action)
        {
            this.action = action;
        }

        public void Execute()
        {
            this.action.Invoke();
        }
    }
}
