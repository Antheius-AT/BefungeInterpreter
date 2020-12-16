using System;
using System.Collections.Generic;
using Interpreter;
using Interpreter.AdditionalComponents;
using Interpreter.Enumerations;
using Interpreter.Interfaces;
using Interpreter.InterpreterComponents;
using NUnit.Framework;

namespace Interpreter_Tests
{
    public class Tests
    {
        private BefungeInterpreter interpreter;
        private IInputHandler inputHandler;
        private IOutputHandler outputHandler;
        private Torus torus;
        private ExecutableCodeContainer codeContainer;
        private ICommandParser commandParser;
        private ProgramCounter pointer;
        private Stack<long> stack;

        [SetUp]
        public void Setup()
        {
            this.pointer = new ProgramCounter();
            this.torus = new Torus();
            this.commandParser = new DefaultCommandParser(this.stack, this.pointer, new Random(), this.outputHandler, this.inputHandler, this.torus);
        }

        [Test]
        [TestCase(@"64+""!dlroW, olleH"">:#,_@")]
        [TestCase(@"Hallo      Duda")]
        public void Do_Coordinates_Match_After_CallTo_PrepareTorus(string code)
        {
            var interpreter = new BefungeInterpreter(this.torus, this.pointer, new ExecutableCodeContainer(code), this.commandParser);

            interpreter.PrepareTorus(code);

            string control = string.Empty;

            foreach (var item in this.torus.TorusContent)
            {
                control += item;
            }

            Assert.AreEqual(code, control.Replace(" ", string.Empty));
        }

        [Test]
        [TestCase(Direction.Right)]
        [TestCase(Direction.Left)]
        [TestCase(Direction.Up)]
        [TestCase(Direction.Down)]
        public void Does_Pointer_Move_Correctly(Direction direction)
        {
            this.pointer.CurrentPosition.X = 5;
            this.pointer.CurrentPosition.Y = 10;

            var initialPosition = new Position(this.pointer.CurrentPosition.X, this.pointer.CurrentPosition.Y);
            this.pointer.CurrentPointerDirection = direction;

            this.pointer.Move();

            switch (direction)
            {
                case Direction.Up:
                    Assert.True(pointer.CurrentPosition.Y == initialPosition.Y - 1);
                    break;
                case Direction.Down:
                    Assert.True(pointer.CurrentPosition.Y == initialPosition.Y + 1);
                    break;
                case Direction.Left:
                    Assert.True(pointer.CurrentPosition.X == initialPosition.X - 1);
                    break;
                case Direction.Right:
                    Assert.True(pointer.CurrentPosition.X == initialPosition.X + 1);
                    break;
            }
        }
    }
}