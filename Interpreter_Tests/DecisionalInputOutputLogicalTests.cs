using System;
using System.Collections.Generic;
using Interpreter;
using NUnit.Framework;
using Interpreter.Interfaces;
using Interpreter.AdditionalComponents;
using Interpreter.InterpreterComponents;
using Interpreter.LanguageCommands.DecisionMakingCommands;
using Interpreter.Enumerations;
using Interpreter.LanguageCommands.InputCommands;
using Interpreter.LanguageCommands.OutputCommands;
using Interpreter.Exceptions;
using Interpreter.LanguageCommands.LogicalCommands;

namespace Interpreter_Tests
{
    public class DecisionalInputOutputLogicalTests
    {
        private ProgramCounter pointer;
        private Stack<long> stack;
        private UnitTestingOutputHandler outputHandler;
        private UnitTestingInputHandler inputHandler;

        [SetUp]
        public void Setup()
        {
            this.outputHandler = new UnitTestingOutputHandler();
            this.stack = new Stack<long>();
            this.pointer = new ProgramCounter();
            this.inputHandler = new UnitTestingInputHandler();
        }

        [Test]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(500)]
        public void IsCommandWorking_HorizontalCondition(int stackInput)
        {
            this.pointer.CurrentPointerDirection = Direction.Down;

            var command = new HorizontalConditionalCommand(this.stack, this.pointer);

            this.stack.Push(stackInput);

            command.Execute();

            if (Convert.ToBoolean(stackInput))
                Assert.True(pointer.CurrentPointerDirection == Direction.Left);
            else
                Assert.True(pointer.CurrentPointerDirection == Direction.Right);
        }

        [Test]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(1000)]
        public void IsCommandWorking_VerticalCondition(int stackInput)
        {
            this.pointer.CurrentPointerDirection = Direction.Right;

            var command = new VerticalConditionalCommand(this.stack, this.pointer);

            this.stack.Push(stackInput);

            command.Execute();

            if (Convert.ToBoolean(stackInput))
                Assert.True(pointer.CurrentPointerDirection == Direction.Up);
            else
                Assert.True(pointer.CurrentPointerDirection == Direction.Down);
        }

        [Test]
        [TestCase('X')]
        [TestCase('a')]
        [TestCase('5')]
        [TestCase('l')]
        public void IsCommandWorking_GetcharacterInputCommand(char input)
        {
            var command = new GetCharacterInputCommand(this.stack, this.inputHandler);
            this.inputHandler.CurrentTestChar = input;

            command.Execute();

            var control = (char)this.stack.Pop();

            Assert.True(input == control);
        }

        [Test]
        [TestCase(5)]
        [TestCase(1)]
        [TestCase(95)]
        [TestCase(255)]
        [TestCase(20505010)]
        public void IsCommandWorking_GetIntegerInputCommand(int input)
        {
            var command = new GetIntegerInputCommand(this.stack, this.inputHandler);
            this.inputHandler.CurrentTestNumber = input;

            command.Execute();

            var control = this.stack.Pop();

            Assert.True(input == control);
        }

        [Test]
        [TestCase('A')]
        [TestCase('5')]
        [TestCase('3')]
        [TestCase('y')]
        [TestCase('ä')]
        [TestCase('q')]
        public void IsCommandWorking_OutputCharacterCommand(char character)
        {
            var command = new OutputCharacterCommand(this.outputHandler, this.stack);

            this.stack.Push((long)character);

            command.Execute();

            Assert.True(character == this.outputHandler.ExpectedCharacterOutput);
        }

        [Test]
        [TestCase(5)]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(252525252)]
        [TestCase(50001003)]
        [TestCase(0)]
        [TestCase(20000052)]
        public void IsCommandWorking_OutputIntegerCommand(long input)
        {
            var command = new OutputIntegerCommand(this.outputHandler, this.stack);

            this.stack.Push(input);

            command.Execute();

            Assert.True(input == this.outputHandler.ExpectedNumberOutput);
        }

        [TestCase(25502005205025022)]
        public void DoesThrowException_OutputInteger_WithValueTooBig(long value)
        {
            var command = new OutputIntegerCommand(this.outputHandler, this.stack);

            this.stack.Push(value);

            Assert.Throws<CommandExecutionFailedException>(() =>
            {
                command.Execute();
            });
        }

        [Test]
        [TestCase(5, 10)]
        [TestCase(2, 1)]
        [TestCase(1, 2)]
        [TestCase(3, 1000)]
        [TestCase(5, 5)]
        [TestCase(0, 0)]
        public void DoesCommandWork_GreaterThanCommand(long first, long second)
        {
            var command = new GreaterThanCommand(this.stack);

            this.stack.Push(first);
            this.stack.Push(second);

            command.Execute();

            bool isGreater = first > second;

            var result = this.stack.Pop();

            Assert.AreEqual(isGreater, Convert.ToBoolean(result));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(500)]
        public void DoesCommandWork_LogicalNotCommand(long input)
        {
            var command = new LogicalNotCommand(this.stack);

            this.stack.Push(input);

            command.Execute();
            var isValueZero = input == 0;
            var result = this.stack.Pop();

            if (isValueZero)
                Assert.True(result == 1);
            else
                Assert.True(result == 0);
        }
    }
}
