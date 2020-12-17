using System;
using System.Collections.Generic;
using System.Text;
using Interpreter.Interfaces;

namespace Interpreter_Tests
{
    public class UnitTestingInputHandler : IInputHandler
    {
        public char AcquireCharacterInput(string promptMessage)
        {
            return this.CurrentTestChar;
        }

        public int AcquireNumericInput(string promptMessage)
        {
            return this.CurrentTestNumber;
        }

        public char CurrentTestChar
        {
            get;
            set;
        }

        public int CurrentTestNumber
        {
            get;
            set;
        }
    }
}
