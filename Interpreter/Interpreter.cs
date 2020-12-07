using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter
{
    /// <summary>
    /// The main class of this application, the interpreter, combines all of the various elements and coordinates them.
    /// </summary>
    public class Interpreter
    {
        public Interpreter()
        {
            this.Torus = new Torus();
            this.Pointer = new ProgramCounter();
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

        public void RunCode()
        {
            throw new NotImplementedException();
        }
    }
}
