using System;
using System.Collections.Generic;
using System.Text;
using Interpreter;
using Interpreter.LanguageCommands.DirectionCommands;
using Interpreter.Enumerations;
using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using NUnit.Framework.Internal;

namespace Interpreter_Tests
{
    public class MovementAndDirectionCommandTests
    {
        private ProgramCounter pointer;

        [SetUp]
        public void Setup()
        {
            this.pointer = new ProgramCounter();
        }

        [Test]
        [TestCase(5)]
        [TestCase(0)]
        [TestCase(66)]
        [TestCase(79)]
        public void DoesNavigationWork_Right(int columnPosition)
        {
            var initialY = this.pointer.CurrentPosition.Y;
            this.pointer.CurrentPointerDirection = Direction.Right;
            this.pointer.CurrentPosition.X = columnPosition;
            this.pointer.Move();

            Assert.That(() =>
            {
                if (columnPosition == 79)
                    return this.pointer.CurrentPosition.X == 0 && this.pointer.CurrentPosition.Y == initialY;
                else
                    return this.pointer.CurrentPosition.X == columnPosition + 1 && this.pointer.CurrentPosition.Y == initialY;
            });
        }

        [Test]
        [TestCase(22)]
        [TestCase(0)]
        [TestCase(3)]
        [TestCase(13)]
        public void DoesNavigationWork_Up(int rowPosition)
        {
            var initialX = this.pointer.CurrentPosition.X;
            this.pointer.CurrentPointerDirection = Direction.Up;
            this.pointer.CurrentPosition.Y = rowPosition;
            this.pointer.Move();

            Assert.That(() =>
            {
                if (rowPosition == 0)
                    return this.pointer.CurrentPosition.Y == 24 && this.pointer.CurrentPosition.X == initialX;
                else
                    return this.pointer.CurrentPosition.Y == rowPosition - 1 && this.pointer.CurrentPosition.X == initialX;
            });
        }


        [Test]
        [TestCase(24)]
        [TestCase(0)]
        [TestCase(13)]
        [TestCase(7)]
        public void DoesNavigationWork_Down(int rowPosition)
        {
            var initialX = this.pointer.CurrentPosition.X;
            this.pointer.CurrentPointerDirection = Direction.Down;
            this.pointer.CurrentPosition.Y = rowPosition;
            this.pointer.Move();

            Assert.That(() =>
            {
                if (rowPosition == 24)
                    return this.pointer.CurrentPosition.Y == 0 && this.pointer.CurrentPosition.X == initialX;
                else
                    return this.pointer.CurrentPosition.Y == rowPosition + 1 && this.pointer.CurrentPosition.X == initialX;
            });
        }

        [Test]
        [TestCase(5)]
        [TestCase(0)]
        [TestCase(66)]
        [TestCase(79)]
        public void DoesNavigationWork_Left(int columnPosition)
        {
            var initialY = this.pointer.CurrentPosition.Y;
            this.pointer.CurrentPointerDirection = Direction.Left;
            this.pointer.CurrentPosition.X = columnPosition;
            this.pointer.Move();

            Assert.That(() =>
            {
                if (columnPosition == 0)
                    return this.pointer.CurrentPosition.X == 79 && this.pointer.CurrentPosition.Y == initialY;
                else
                    return this.pointer.CurrentPosition.X == columnPosition - 1 && this.pointer.CurrentPosition.Y == initialY;
            });
        }

        [Test]
        public void DoesCommandWork_UpDirectionCommand()
        {
            this.pointer.CurrentPointerDirection = Direction.Right;
            var command = new UpDirectionCommand(this.pointer);

            command.Execute();

            Assert.True(this.pointer.CurrentPointerDirection == Direction.Up);
        }


        [Test]
        public void DoesCommandWork_RightDirectionCommand()
        {
            this.pointer.CurrentPointerDirection = Direction.Left;
            var command = new RightDirectionCommand(this.pointer);

            command.Execute();

            Assert.True(this.pointer.CurrentPointerDirection == Direction.Right);
        }


        [Test]
        public void DoesCommandWork_DownDirectionCommand()
        {
            this.pointer.CurrentPointerDirection = Direction.Right;
            var command = new DownDirectionCommand(this.pointer);

            command.Execute();

            Assert.True(this.pointer.CurrentPointerDirection == Direction.Down);
        }


        [Test]
        public void DoesCommandWork_LeftDirectionCommand()
        {
            this.pointer.CurrentPointerDirection = Direction.Right;
            var command = new LeftDirectionCommand(this.pointer);

            command.Execute();

            Assert.True(this.pointer.CurrentPointerDirection == Direction.Left);
        }

        [TestCase(100)]
        [Test]
        public void DoesCommandWork_RandomDirectionCommand(int tryAmount)
        {
            this.pointer.CurrentPointerDirection = Direction.Right;

            var command = new RandomDirectionCommand(this.pointer, new Random());
            var directions = new List<Direction>();

            for (int i = 0; i < 1000; i++)
            {
                command.Execute();
                directions.Add(this.pointer.CurrentPointerDirection);
            }

            var up = directions.Where(p => p == Direction.Up).Count();
            var down = directions.Where(p => p == Direction.Down).Count();
            var right = directions.Where(p => p == Direction.Right).Count();
            var left = directions.Where(p => p == Direction.Left).Count();

            Assert.Multiple(() =>
            {
                Assert.GreaterOrEqual(up, 150);
                Assert.GreaterOrEqual(down, 150);
                Assert.GreaterOrEqual(right, 150);
                Assert.GreaterOrEqual(left, 150);

                Assert.LessOrEqual(up, 350);
                Assert.LessOrEqual(down, 350);
                Assert.LessOrEqual(right, 350);
                Assert.LessOrEqual(left, 350);
            });
        }
    }
}
