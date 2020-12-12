using System;
using System.Collections.Generic;
using System.Text;
using Interpreter.Interfaces;

namespace Interpreter.LanguageCommands.MemoryManipulatingCommands
{
    /// <summary>
    /// Retrieves a value at a position specified by the two upper most stack values (serving as X and Y) and pushes
    /// it onto the upper most position on the stack.
    /// </summary>
    public class RetrieveFromMemoryCommand : ICommand
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
