//-----------------------------------------------------------------------
// <copyright file="PushToStackCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.BasicCommands
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

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
            this.stack.Push(this.data);
        }
    }
}
