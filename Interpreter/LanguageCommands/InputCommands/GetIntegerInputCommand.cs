//-----------------------------------------------------------------------
// <copyright file="GetIntegerInputCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.InputCommands
{
    using Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// This command gets an integer input from the user.
    /// </summary>
    public class GetIntegerInputCommand : ICommand
    {
        private Stack<long> stack;
        private IInputHandler inputHandler;

        public GetIntegerInputCommand(Stack<long> stack, IInputHandler inputHandler)
        {
            this.stack = stack;
            this.inputHandler = inputHandler;
        }

        public void Execute()
        {
            int input;

            input = this.inputHandler.AcquireNumericInput("Please enter an integer number");
            this.stack.Push(input);
        }
    }
}
