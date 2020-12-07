using System;
using System.Collections.Generic;
using System.Text;
using Interpreter.Interfaces;

namespace Interpreter.LanguageCommands.BasicCommands
{
    public class PushToStackCommand : ICommand
    {
        private long data;
        private Stack<long> stack;

        public PushToStackCommand(long data, Stack<long> stack)
        {
            if (stack == null)
                throw new ArgumentNullException(nameof(stack), "Stack must not be null.");

            this.stack = stack;
            this.data = data;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
