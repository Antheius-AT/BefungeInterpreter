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

    public class DefaultCommandParser : ICommandParser
    {
        private Dictionary<char, Type> charToCommandMap;

        public DefaultCommandParser()
        {
            this.charToCommandMap = new Dictionary<char, Type>()
            {
                {'+', typeof(AdditionCommand) },
                {'-', typeof(SubtractionCommand) },
                {'*', typeof(MultiplicationCommand) },
                {'/', typeof(DivisionCommand) },
                {'%', typeof(ModuloCommand) },
                {'!', typeof(LogicalNotCommand) },
                {'`', typeof(GreaterThanCommand) },
                {'>', typeof(RightDirectionCommand) },
                {'<', typeof(LeftDirectionCommand) },
                {'^', typeof(UpDirectionCommand) },
                {'v', typeof(DownDirectionCommand) },
                {'?', typeof(RandomDirectionCommand) },
                {'_', typeof(HorizontalConditionalCommand) },
                {'|', typeof(VerticalConditionalCommand) },
                {'"', typeof(ToggleStringModeCommand) },
                {':', typeof(DuplicateTopValueCommand) },
                {'\\', typeof(SwapTopValuesCommand) },
                {'$', typeof(DiscardTopValueCommand) },
                {'.', typeof(OutputIntegerCommand) },
                {',', typeof(OutputCharacterCommand) },
                {'#', typeof(BridgeCommand) },
                {'g', typeof(RetrieveFromMemoryCommand) },
                {'p', typeof(PutToMemoryCommand) },
                {'&', typeof(GetIntegerInputCommand) },
                {'~', typeof(GetCharacterInputCommand) },
                {'@', typeof(EndExecutionCommand) },
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
            return this.charToCommandMap.ContainsKey(character);
        }

        public ICommand Parse(char character)
        {
            if (!this.CanParse(character))
                throw new ArgumentException(nameof(character), "Character could not be parsed.");

            ICommand command;
            Type commandType = this.charToCommandMap[character];

            command = (ICommand)Activator.CreateInstance(commandType);

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
