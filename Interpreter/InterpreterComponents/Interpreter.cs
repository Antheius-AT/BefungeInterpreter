using System;
using System.Collections.Generic;
using System.Text;
using Interpreter.InterpreterComponents;

namespace Interpreter
{
    /// <summary>
    /// The main class of this application, the interpreter, combines all of the various elements and coordinates them.
    /// </summary>
    public class Interpreter
    {
        private bool isRunning;
        public readonly Stack<long> befungeStack;

        public Interpreter()
        {
            this.Torus = new Torus();
            this.Pointer = new ProgramCounter();
            this.isRunning = true;
            this.CommandParser = new CommandParser();
        }

        public Torus Torus
        {
            get;
            private set;
        }

        public ProgramCounter Pointer
        {
            get;
            private set;
        }

        public CommandParser CommandParser
        {
            get;
            private set;
        }

        public void RunCode()
        {
            throw new NotImplementedException();
        }

        private void ExitProgramCallback()
        {
            this.isRunning = false;
        }
    }
}
