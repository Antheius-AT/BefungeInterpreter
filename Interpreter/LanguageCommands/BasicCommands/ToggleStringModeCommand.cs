using System;
using System.Collections.Generic;
using System.Text;
using Interpreter.Interfaces;

namespace Interpreter.LanguageCommands.BasicCommands
{
    public class ToggleStringModeCommand : ICommand
    {
        private ICommandParser parser;

        public ToggleStringModeCommand(ICommandParser parser)
        {
            this.parser = parser;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
