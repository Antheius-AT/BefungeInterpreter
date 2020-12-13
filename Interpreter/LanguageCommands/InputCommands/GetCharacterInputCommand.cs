//-----------------------------------------------------------------------
// <copyright file="GetCharacterInputCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.InputCommands
{
    using Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// This command gets a character input from the user.
    /// </summary>
    public class GetCharacterInputCommand : ICommand
    {
        private Stack<long> stack;
        private IInputHandler inputHandler;

        public GetCharacterInputCommand(Stack<long> stack, IInputHandler inputHandler)
        {
            this.stack = stack;
            this.inputHandler = inputHandler;
        }

        public void Execute()
        {
            var input = this.inputHandler.AcquireInput("Please enter a character into the console.");

            this.stack.Push(input);
        }
    }
}
