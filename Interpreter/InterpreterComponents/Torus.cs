using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter
{
    /// <summary>
    /// The torus class. Represents the 80x25 torus used for Befunge code.
    /// </summary>
    public class Torus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Torus"/> class.
        /// </summary>
        /// <param name="width">The torus width.</param>
        /// <param name="height">The torus height.</param>
        public Torus(int width = 80, int height = 25)
        {
            this.Width = width;
            this.Height = height;
            this.TorusContent = new char[width, height];

            for (int i = 0; i < this.TorusContent.GetLength(1); i++)
            {
                for (int j = 0; j < this.TorusContent.GetLength(0); j++)
                {
                    this.TorusContent[j, i] = ' ';
                }
            }
        }

        /// <summary>
        /// Gets the width of the torus.
        /// </summary>
        public int Width
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the height of the torus.
        /// </summary>
        public int Height
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the torus content.
        /// </summary>
        public char[,] TorusContent
        {
            get;
            private set;
        }
    }
}
