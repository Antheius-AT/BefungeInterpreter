using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interpreter.AdditionalComponents;
using Interpreter.Exceptions;
using Interpreter.Interfaces;
using Interpreter.InterpreterComponents;
using Microsoft.Extensions.Hosting;

namespace Interpreter
{
    /// <summary>
    /// The main class of this application, the interpreter, combines all of the various elements and coordinates them.
    /// </summary>
    public class Interpreter
    {
        private bool isRunning;

        public Interpreter(Torus torus, ProgramCounter pointer, ExecutableCodeContainer codeContainer, ICommandParser commandParser)
        {
            this.Torus = torus;
            this.Pointer = pointer;
            this.CommandParser = commandParser;

            if (codeContainer == null)
                throw new ArgumentNullException(nameof(codeContainer), "Code must not be null.");

            if (codeContainer.Code.Length > this.Torus.Height * this.Torus.Width)
                throw new ArgumentOutOfRangeException(nameof(codeContainer), $"Code characters exceeded the maximum amount of possible commands in the torus ({this.Torus.Height * this.Torus.Width})");

            this.PrepareTorus(codeContainer.Code);
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

        public void Start()
        {
            this.isRunning = true;
            this.RunCode();
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
        private void RunCode()
        {
            ICommand currentCommand;
            char current;

            while (this.isRunning)
            {
                current = this.Torus.TorusContent[this.Pointer.CurrentPosition.X, this.Pointer.CurrentPosition.Y];

                if (!this.CommandParser.CanParse(current))
                    throw new InterpreterException($"Code interpretation failed at position ({this.Pointer.CurrentPosition.X}|{this.Pointer.CurrentPosition.Y}) due to invalid character {this.Torus.TorusContent[this.Pointer.CurrentPosition.X, this.Pointer.CurrentPosition.Y]}");
                        
                currentCommand = this.CommandParser.Parse(current);
                currentCommand.Execute();
                this.Pointer.Move();
                this.isRunning = !this.Pointer.Terminated;
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

            code = code.Replace("\r", string.Empty);

            foreach (var item in code)
            {
                // Only write current item into torus if it is not a new line feed.
                this.Torus.TorusContent[column, row] = item == '\n' ? ' ' : item;
                column++;

                if (column == this.Torus.Width - 1 || item == '\n')
                {
                    column = 0;
                    row++;
                }
            }
        }
    }
}
