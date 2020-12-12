using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interpreter.Exceptions;
using Interpreter.Interfaces;
using Interpreter.InterpreterComponents;
using Microsoft.Extensions.Hosting;

namespace Interpreter
{
    /// <summary>
    /// The main class of this application, the interpreter, combines all of the various elements and coordinates them.
    /// </summary>
    public class Interpreter : IHostedService
    {
        private bool isRunning;
        private readonly Stack<long> befungeStack;

        public Interpreter(string code)
        {
            this.Torus = new Torus();
            this.Pointer = new ProgramCounter();
            this.isRunning = true;
            this.CommandParser = new DefaultCommandParser();
            this.PrepareTorus(code);
        }

        public Interpreter(ICommandParser commandParser, string code)
        {
            this.Torus = new Torus();
            this.Pointer = new ProgramCounter();
            this.isRunning = true;
            this.CommandParser = commandParser;
            this.PrepareTorus(code);
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

        public ICommandParser CommandParser
        {
            get;
            private set;
        }

        /// <summary>
        /// Runs a piece of Befunge-93 code.
        /// </summary>
        /// <param name="code">The code to run.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if code is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Is thrown if the characters in the code exceed the limit the torus can handle.
        /// </exception>
        public void RunCode(string code)
        {
            if (code == null)
                throw new ArgumentNullException(nameof(code), "Code must not be null.");

            if (code.Length > this.Torus.Height * this.Torus.Width)
                throw new ArgumentOutOfRangeException(nameof(code), $"Code characters exceeded the maximum amount of possible commands in the torus ({this.Torus.Height * this.Torus.Width})");
           
            ICommand currentCommand;
            char current;

            this.PrepareTorus(code);

            while (this.isRunning)
            {
                current = this.Torus.TorusContent[this.Pointer.CurrentPosition.X, this.Pointer.CurrentPosition.Y];

                if (!this.CommandParser.CanParse(current))
                    throw new InterpreterException($"Code interpretation failed at position ({this.Pointer.CurrentPosition.X}|{this.Pointer.CurrentPosition.Y}) due to invalid character {this.Torus.TorusContent[this.Pointer.CurrentPosition.X, this.Pointer.CurrentPosition.Y]}");
                        
                currentCommand = this.CommandParser.Parse(current);
                currentCommand.Execute();
                this.Pointer.Move();
            }
        }

        /// <summary>
        /// Prepares the torus by writing the code into the 80x25 array.
        /// </summary>
        /// <param name="code">The code to write to the torus.</param>
        private void PrepareTorus(string code)
        {
            int row = 0;
            int column = 0;

            foreach (var item in code)
            {
                this.Torus.TorusContent[column, row] = item;
                column++;

                if (column == this.Torus.Width - 1)
                {
                    column = 0;
                    row++;
                }
            }
        }

        private void ExitProgramCallback()
        {
            this.isRunning = false;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Gets called when host.run is called.
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
