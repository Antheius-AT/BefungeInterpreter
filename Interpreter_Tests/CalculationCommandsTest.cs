using System;
using System.Collections.Generic;
using System.Text;
using Interpreter;
using Interpreter.AdditionalComponents;
using Interpreter.Exceptions;
using Interpreter.Interfaces;
using Interpreter.InterpreterComponents;
using Interpreter.LanguageCommands.CalculationCommands;
using NUnit.Framework;

namespace Interpreter_Tests
{
    public class CalculationCommandsTest
    {
        private Torus torus;
        private ProgramCounter pointer;
        private Stack<long> stack;
        private IOutputHandler outputHandler;
        private IInputHandler inputHandler;
        private ICommandParser parser;

        [SetUp]
        public void Setup()
        {
            this.outputHandler = new ConsoleOutputHandler();
            this.stack = new Stack<long>();
            this.pointer = new ProgramCounter();
            this.torus = new Torus();
            this.inputHandler = new ConsoleInputHandler();
            this.parser = new DefaultCommandParser(this.stack, this.pointer, new Random(), this.outputHandler, this.inputHandler, this.torus);
        }

        [Test]
        [TestCase(5, 2)]
        [TestCase(10, 33)]
        [TestCase(0, 0)]
        [TestCase(-50, -33)]
        public void DoesCommandExecuteCorrectly_AdditionCommand(long first, long second)
        {
            this.stack.Push(first);
            this.stack.Push(second);

            var command = new AdditionCommand(this.stack);
            command.Execute();

            this.stack.TryPop(out long result);

            Assert.That(result == first + second);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(5, 4)]
        [TestCase(2, 10)]
        [TestCase(15000, 3)]
        [TestCase(-5, -20)]
        public void DoesCommandExecuteCorrectly_SubtractionCommand(long first, long second)
        {
            this.stack.Push(first);
            this.stack.Push(second);

            var command = new SubtractionCommand(this.stack);

            command.Execute();

            var result = this.stack.Pop();

            Assert.AreEqual(first - second, result);
        }

        [Test]
        [TestCase(10, 5)]
        [TestCase(6, 4)]
        [TestCase(1, 20)]
        [TestCase(35, 2)]
        [TestCase(0, 22)]
        [TestCase(-5, 133)]
        public void DoesCommandExecuteCorrectly_DivisionCommand(long first, long second)
        {
            this.stack.Push(first);
            this.stack.Push(second);

            var command = new DivisionCommand(this.stack);

            command.Execute();

            this.stack.TryPop(out long result);

            Assert.That(Math.Floor(first * 1.0 / second) == result);
        }

        [Test]
        [TestCase(5, 5)]
        [TestCase(3, 8)]
        [TestCase(0, 5)]
        [TestCase(0, 3)]
        [TestCase(-20, -3)]
        [TestCase(500, 22000)]
        public void DoesCommandExecuteCorrectly_ModuloCommand(long first, long second)
        {
            var command = new ModuloCommand(this.stack);

            this.stack.Push(first);
            this.stack.Push(second);

            command.Execute();

            var result = this.stack.Pop();

            Assert.AreEqual(first % second, result);
        }

        [Test]
        public void DoesCommandThrowException_ModuloCommandDivideByZero()
        {
            this.stack.Push(5);
            this.stack.Push(0);

            var command = new ModuloCommand(this.stack);

            Assert.Throws<CommandExecutionFailedException>(() =>
            {
                command.Execute();
            });
        }

        [Test]
        public void DoesCommandThrowException_DivisionCommandDivideByZero()
        {
            this.stack.Push(5);
            this.stack.Push(0);

            var command = new DivisionCommand(this.stack);

            Assert.Throws<CommandExecutionFailedException>(() =>
            {
                command.Execute();
            });
        }
    }
}
