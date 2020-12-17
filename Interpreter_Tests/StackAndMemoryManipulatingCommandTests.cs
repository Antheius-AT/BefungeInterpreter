using System;
using System.Collections.Generic;
using System.Text;
using Interpreter;
using Interpreter.Exceptions;
using Interpreter.Interfaces;
using Interpreter.LanguageCommands.MemoryManipulatingCommands;
using Interpreter.LanguageCommands.StackManipulationCommands;
using Microsoft.VisualBasic.CompilerServices;
using NUnit.Framework;

namespace Interpreter_Tests
{
    public class StackAndMemoryManipulatingCommandTests
    {
        private Stack<long> stack;
        private Torus torus;

        [SetUp]
        public void Setup()
        {
            this.stack = new Stack<long>();
            this.torus = new Torus();
        }

        [Test]
        public void DoesCommandWork_DiscardTopValueCommand()
        {
            this.stack.Push(10);

            var command = new DiscardTopValueCommand(this.stack);

            command.Execute();

            this.stack.TryPop(out long result);

            Assert.False(result == 10);
        }

        [Test]
        public void DoesCommandWork_DuplicateTopValueCommand()
        {
            this.stack.Push(33);

            var command = new DuplicateTopValueCommand(this.stack);

            command.Execute();

            var first = this.stack.Pop();
            var second = this.stack.Pop();

            Assert.True(first == 33 && second == 33);
        }

        [Test]
        [TestCase(5, 10)]
        [TestCase(0, 2)]
        [TestCase(33, 25000)]
        public void DoesCommandWork_SwapTopValuesCommand(long first, long second)
        {
            this.stack.Push(first);
            this.stack.Push(second);

            var command = new SwapTopValuesCommand(this.stack);

            command.Execute();

            var firstPopped = this.stack.Pop();
            var secondPopped = this.stack.Pop();

            Assert.True(firstPopped == first && secondPopped == second);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(10, 20)]
        [TestCase(3, 13)]
        [TestCase(79, 24)]
        public void DoesCommandWork_RetrieveFromMemoryCommand(long x, long y)
        {
            var command = new RetrieveFromMemoryCommand(this.stack, this.torus);

            this.torus.TorusContent[x, y] = '.';

            this.stack.Push(x);
            this.stack.Push(y);

            command.Execute();

            var result = this.stack.Pop();

            Assert.True('.' == (char)result);
        }

        [Test]
        [TestCase(0, 0, 22)]
        [TestCase(22, 11, 1001)]
        [TestCase(79, 24, 58)]
        public void DoesCommandWork_PutToMemoryCommand(long x, long y, long value)
        {
            var command = new PutToMemoryCommand(this.stack, this.torus);

            this.stack.Push(value);
            this.stack.Push(x);
            this.stack.Push(y);

            command.Execute();

            Assert.That(() =>
            {
                return this.torus.TorusContent[x, y] == (char)value;
            });
        }

        [Test]
        [TestCase(-5, 10)]
        [TestCase(100, 30)]
        [TestCase(-10, 100)]
        [TestCase(100, -10)]
        public void RetrieveFromMemorycommand_ThrowsException_IfOutOfBounds(long x, long y)
        {
            var command = new RetrieveFromMemoryCommand(this.stack, this.torus);

            this.stack.Push(x);
            this.stack.Push(y);

            Assert.Throws<CommandExecutionFailedException>(() =>
            {
                command.Execute();
            });
        }

        [Test]
        [TestCase(-5, 10, 20)]
        [TestCase(0, 80, 100)]
        [TestCase(22, 250, 0)]
        [TestCase(5, 25, 57)]
        [TestCase(80, 24, 1)]
        public void PutToMemoryCommand_ThrowsException_IfOutofBounds(long x, long y, long value)
        {
            var command = new PutToMemoryCommand(this.stack, this.torus);

            this.stack.Push(value);
            this.stack.Push(x);
            this.stack.Push(y);

            Assert.Throws<CommandExecutionFailedException>(() =>
            {
                command.Execute();
            });
        }
    }
}
