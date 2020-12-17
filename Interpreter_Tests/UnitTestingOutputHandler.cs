using System;
using Interpreter.AdditionalComponents;
using Interpreter.Interfaces;

namespace Interpreter_Tests
{
    public class UnitTestingOutputHandler : IOutputHandler
    {
        public OutputMode CurrentOutputMode { get; }

        public void HandleCharacterOutput(long output)
        {
            this.ExpectedCharacterOutput = (char)output;
        }

        public void HandleIntegerOutput(long output)
        {
            this.ExpectedNumberOutput = (int)output;
        }

        public void SetOutputMode(OutputMode outputMode)
        {
            throw new NotImplementedException();
        }

        public char ExpectedCharacterOutput
        {
            get;
            set;
        }

        public int ExpectedNumberOutput
        {
            get;
            set;
        }
    }
}
