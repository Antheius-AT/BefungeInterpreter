using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter.AdditionalComponents
{
    public class ExecutableCodeContainer
    {
        public ExecutableCodeContainer(string code)
        {
            this.Code = code;
        }

        public string Code
        {
            get;
            private set;
        }
    }
}
