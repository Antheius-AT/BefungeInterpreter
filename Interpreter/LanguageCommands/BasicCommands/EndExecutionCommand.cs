using System;
using System.Collections.Generic;
using System.Text;
using Interpreter.Interfaces;

namespace Interpreter.LanguageCommands.BasicCommands
{
    public class EndExecutionCommand : ICommand
    {
        private Action callBack;

        public EndExecutionCommand(Action callBack)
        {
            if (callBack != null)
                throw new ArgumentNullException(nameof(callBack), "Callback must not be null.");

            this.callBack = callBack;
        }

        public void Execute()
        {
            this.callBack.Invoke();
        }
    }
}
