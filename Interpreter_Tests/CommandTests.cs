using System;
using System.Collections.Generic;
using System.Text;
using Interpreter;
using Interpreter.Interfaces;
using Interpreter.LanguageCommands.BasicCommands;
using Interpreter.LanguageCommands.CalculationCommands;
using Interpreter.LanguageCommands.DecisionMakingCommands;
using Interpreter.LanguageCommands.DirectionCommands;
using Interpreter.LanguageCommands.InputCommands;
using Interpreter.LanguageCommands.LogicalCommands;
using Interpreter.LanguageCommands.MemoryManipulatingCommands;
using Interpreter.LanguageCommands.OutputCommands;
using Interpreter.LanguageCommands.StackManipulationCommands;
using Interpreter.Enumerations;
using NUnit.Framework;
using Interpreter.AdditionalComponents;
using Interpreter.InterpreterComponents;

namespace Interpreter_Tests
{
    public class CommandTests
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
        public void DoesCommandExecuteCorrectly_BridgeCommand()
        {
            Position initialPosition;
            Position movedPosition;
            var bridge = new BridgeCommand(pointer);

            initialPosition = new Position(pointer.CurrentPosition.X, pointer.CurrentPosition.Y);
            bridge.Execute();

            movedPosition = pointer.CurrentPosition;

            // Assert whether something changed. In this test I want to test whether the bridge command moves
            // the cursor. I don`t want to test whether the cursor moved properly into a specific direction.
            Assert.True(movedPosition.X != initialPosition.X || movedPosition.Y != movedPosition.Y);
        }

        [Test]
        public void DoesCommandExecuteCorrectly_EndExecutionCommand()
        {
            var command = new EndExecutionCommand(this.pointer);

            if (this.pointer.Terminated)
                Assert.Fail("Pointer needs to be in a state that is not terminated to run this test.");

            command.Execute();

            Assert.True(this.pointer.Terminated);
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(22)]
        public void DoesCommandExecuteCorrectly_PushToStackCommand(long data)
        {
            this.stack.Clear();

            var command = new PushToStackCommand(data, this.stack);

            command.Execute();

            Assert.That(this.stack.Count == 1 && this.stack.Peek() == data);
        }

        [Test]
        [TestCase(OutputMode.InLine, OutputMode.NewLine, OutputMode.NewLine, OutputMode.NewLine, OutputMode.InLine)]
        public void DoesCommandExecuteCorrectly_ToggleOutputCommand(params OutputMode[] outputModes)
        {
            foreach (var item in outputModes)
            {
                var command = new ToggleOutputModeCommand(this.outputHandler, item);
                command.Execute();
                if (this.outputHandler.CurrentOutputMode != item)
                    Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        public void DoesCommandExecuteCorrectly_ToggleStringModeCommand()
        {
            // The toggle string mode command technically only invokes a delegate that is being passed to it
            // via its constructor.
            var command = new ToggleStringModeCommand(() =>
            {
                Assert.Pass();
            });

            command.Execute();

            Assert.Fail();
        }

        [Test]
        [TestCase(5,2)]
        [TestCase(10, 33)]
        [TestCase(0, 0)]
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
        [TestCase(10, 5)]
        [TestCase(6, 4)]
        [TestCase(1, 20)]
        [TestCase(35, 0)]
        [TestCase(0, 22)]
        public void DoesCommandExecuteCorrectly_DivisionCommand(long first, long second)
        {
            this.stack.Push(first);
            this.stack.Push(second);

            var command = new DivisionCommand(this.stack);

            command.Execute();

            this.stack.TryPop(out long result);

            Assert.That(Math.Floor(first * 1.0 / second) == result);
        }
    }
}
