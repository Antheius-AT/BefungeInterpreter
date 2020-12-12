using System;
using System.Collections.Generic;
using System.Text;
using Interpreter.Interfaces;
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
            ICommand currentCommand;

            while (this.isRunning)
            {
                currentCommand = this.CommandParser.ParseCommand(this.Torus.TorusContent[this.Pointer.CurrentPosition.X, this.Pointer.CurrentPosition.Y]);
                currentCommand.Execute();
                this.Pointer.Move();
            }
        }

        private void ExitProgramCallback()
        {
            this.isRunning = false;
        }
    }
}
