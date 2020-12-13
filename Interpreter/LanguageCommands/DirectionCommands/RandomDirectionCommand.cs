//-----------------------------------------------------------------------
// <copyright file="RandomDirectionCommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.LanguageCommands.DirectionCommands
{
    using Interfaces;
    using Enumerations;
    using System;

    /// <summary>
    /// Represent a command which changes the pointer to move into a random direction.
    /// </summary>
    public class RandomDirectionCommand : ICommand
    {
        private Random random;
        private ProgramCounter pointer;

        public RandomDirectionCommand(ProgramCounter pointer, Random random)
        {
            this.pointer = pointer;
            this.random = random;
        }

        public void Execute()
        {
            var randomNumber = this.random.Next(0, 101);
            Direction direction;

            if (randomNumber < 24)
                direction = Direction.Left;
            else if (randomNumber < 49)
                direction = Direction.Right;
            else if (randomNumber < 74)
                direction = Direction.Up;
            else
                direction = Direction.Down;

            this.pointer.CurrentPointerDirection = direction;
        }
    }
}
