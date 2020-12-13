//-----------------------------------------------------------------------
// <copyright file="ICommand.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace Interpreter.InterpreterComponents
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using LanguageCommands.LogicalCommands;
    using LanguageCommands.CalculationCommands;
    using LanguageCommands.DirectionCommands;
    using LanguageCommands.BasicCommands;
    using LanguageCommands.DecisionMakingCommands;
    using LanguageCommands.InputCommands;
    using LanguageCommands.OutputCommands;
    using LanguageCommands.StackManipulationCommands;
    using LanguageCommands.MemoryManipulatingCommands;

    /// <summary>
    /// Represent the default command parser, which parses characters into commands.
    /// </summary>
    public class DefaultCommandParser : ICommandParser
    {
        private Stack<long> stack;
        private Dictionary<char, ICommand> charToCommandMap;

        public DefaultCommandParser(Stack<long> stack, ProgramCounter pointer, Random random, IOutputHandler outputHandler, IInputHandler inputHandler, Torus torus)
        {
            this.stack = stack;
            this.charToCommandMap = new Dictionary<char, ICommand>()
            {
                {'+', new AdditionCommand(stack) },
                {'-', new SubtractionCommand(stack) },
                {'*', new MultiplicationCommand(stack) },
                {'/', new DivisionCommand(stack) },
                {'%', new ModuloCommand(stack) },
                {'!', new LogicalNotCommand(stack) },
                {'`', new GreaterThanCommand(stack) },
                {'>', new RightDirectionCommand(pointer) },
                {'<', new LeftDirectionCommand(pointer) },
                {'^', new UpDirectionCommand(pointer) },
                {'v', new DownDirectionCommand(pointer) },
                {'?', new RandomDirectionCommand(pointer, random) },
                {'_', new HorizontalConditionalCommand(stack, pointer) },
                {'|', new VerticalConditionalCommand(stack, pointer) },
                {'"', new ToggleStringModeCommand(this.ToggleStringMode) },
                {':', new DuplicateTopValueCommand(stack) },
                {'\\', new  SwapTopValuesCommand(stack) },
                {'$', new DiscardTopValueCommand(stack) },
                {'.', new OutputIntegerCommand(outputHandler, stack) },
                {',', new OutputCharacterCommand(outputHandler, stack) },
                {'#', new BridgeCommand(pointer) },
                {'g', new RetrieveFromMemoryCommand(stack, torus) },
                {'p', new PutToMemoryCommand(stack, torus) },
                {'&', new GetIntegerInputCommand(stack, inputHandler) },
                {'~', new GetCharacterInputCommand(stack, inputHandler) },
                {'@', new EndExecutionCommand(pointer) },
                {' ', new NullCommand() },
                {'\0', new NullCommand() },
                {'\r', new NullCommand() }
           };
        }

        /// <summary>
        /// Gets a value indicating whether string mode is toggled.
        /// </summary>
        public bool IsStringmodeToggled
        {
            get;
            private set;
        }

        /// <summary>
        /// Checks whether a specified input can be parsed.
        /// </summary>
        /// <param name="character">The character to check.</param>
        /// <returns>Whether the specified character can be parsed.</returns>
        public bool CanParse(char character)
        {
            if (this.IsStringmodeToggled || char.IsDigit(character))
                return true;

            if (character.ToString() == @"\")
                character = '\\';

            return this.charToCommandMap.ContainsKey(character);
        }

        /// <summary>
        /// Parses a character into a command.
        /// </summary>
        /// <param name="character">The character to be parsed.</param>
        /// <returns>The parsed command.</returns>
        public ICommand Parse(char character)
        {
            if (!this.CanParse(character))
                throw new ArgumentException(nameof(character), "Character could not be parsed.");

            ICommand command;

            if (char.IsDigit(character))
                command = new PushToStackCommand(long.Parse(character.ToString()), this.stack);
            else if (this.IsStringmodeToggled && character != '"')
                command = new PushToStackCommand((long)character, this.stack);
            else
                command = this.charToCommandMap[character];

            return command;
        }

        /// <summary>
        /// Toggles string mode.
        /// </summary>
        public void ToggleStringMode()
        {
            this.IsStringmodeToggled = !this.IsStringmodeToggled;
        }
    }
}
