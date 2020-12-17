using System;
using System.Collections.Generic;
using Interpreter;
using Interpreter.AdditionalComponents;
using Interpreter.Enumerations;
using Interpreter.Exceptions;
using Interpreter.Interfaces;
using Interpreter.InterpreterComponents;
using Interpreter.LanguageCommands.BasicCommands;
using Interpreter.LanguageCommands.MemoryManipulatingCommands;
using Interpreter.LanguageCommands.StackManipulationCommands;
using NUnit.Framework;

namespace Interpreter_Tests
{
    public class Tests
    {
        private IInputHandler inputHandler;
        private IOutputHandler outputHandler;
        private Torus torus;
        private ICommandParser commandParser;
        private ProgramCounter pointer;
        private Stack<long> stack;

        [SetUp]
        public void Setup()
        {
            this.pointer = new ProgramCounter();
            this.torus = new Torus();
            this.commandParser = new DefaultCommandParser(this.stack, this.pointer, new Random(), this.outputHandler, this.inputHandler, this.torus);
            this.stack = new Stack<long>();
        }

        [Test]
        [TestCase(':')]
        [TestCase('"')]
        [TestCase('p')]
        [TestCase('r')]
        public void DoesCommandParser_CanParse_Work(char character)
        {
            var result = this.commandParser.CanParse(character);
            bool expected;

            if (character == 'r')
                expected = false;
            else
                expected = true;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DoesCommandParser_Parse_Work()
        {
            var result = this.commandParser.Parse(':');

            Assert.IsTrue(result is DuplicateTopValueCommand);

            result = this.commandParser.Parse('p');

            Assert.IsTrue(result is PutToMemoryCommand);

            result = this.commandParser.Parse('@');

            Assert.IsTrue(result is EndExecutionCommand);
        }

        [TestCase('f')]
        [TestCase('m')]
        [TestCase('s')]
        public void DoesCommandParser_Parse_ThrowExceptionOnInvalidInput(char character)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.commandParser.Parse(character);
            });
        }

        [TestCase('f')]
        [TestCase('m')]
        [TestCase('s')]
        public void DoescommandParser_CanParse_ReturnFalseOnInvalidInput(char character)
        {
            Assert.False(this.commandParser.CanParse(character));
        }

        [Test]
        [TestCase("Hallo")]
        [TestCase("xyzfhefh    hfesfsf    yoyoyo")]
        [TestCase("H\r\nduda\r\n    lllll")]
        [TestCase("fsehflkhesfhlsefh\r\n      \r\nH   j   l  j kj flkj jl jl ljlk lk jlk jlk lkfjlksjer flVcfjsljf")]
        [TestCase("55*\\22@")]
        public void Does_PrepareTorus_Work(string input)
        {
            var container = new ExecutableCodeContainer(input);
            var interpreter = new BefungeInterpreter(this.torus, this.pointer, container, this.commandParser);

            interpreter.PrepareTorus(container.Code);

            // Initializing the control char array to contain only white space characters, because the same is true
            // for the torus before being filled with code in the prepare torus call.
            var control = new char[80, 25];

            for (int i = 0; i < control.GetLength(1); i++)
            {
                for (int j = 0; j < control.GetLength(0); j++)
                {
                    control[j, i] = ' ';
                }
            }

            // getting rid of line feeds and replacing them with a simple \n to know when to insert a logical line break.
            input = input.Replace("\r\n", "\n");

            int row = 0;
            int column = 0;

            // This loop fills the content of the input string into the control array. If current position is \n
            // insert a logical line break, incrementing row and resetting column.
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\n')
                {
                    row++;
                    column = 0;
                    continue;
                }

                control[column, row] = input[i];
                column++;
            }

            row = 0;
            column = 0;

            // In this iteration I am comparing each cell at index 0 - torus.Length - 1 in the control array, with each cell at that
            // same index in the torus. I am expecting them to be the same.
            for (int i = 0; i < control.Length; i++)
            {
                if (i != 0 && i % this.torus.Width == 0)
                {
                    row++;
                    column = 0;
                }

                if (control[column, row] != this.torus.TorusContent[column, row])
                    Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        [TestCase("195v   >@\r\n   >   ^")]
        [TestCase("55*\\22@")]
        public void DoesStart_ActuallyStartAndRunCode(string code)
        {
            var interpreter = new BefungeInterpreter(this.torus, this.pointer, new ExecutableCodeContainer(code), this.commandParser);

            interpreter.Start();
        }
    }
}