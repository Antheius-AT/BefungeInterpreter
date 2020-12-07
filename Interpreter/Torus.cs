﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter
{
    /// <summary>
    /// The torus class. Represents the 80x25 torus used for Befunge code.
    /// </summary>
    public class Torus
    {
        private string[,] torusContent;

        /// <summary>
        /// Initializes a new instance of the <see cref="Torus"/> class.
        /// </summary>
        /// <param name="width">The torus width.</param>
        /// <param name="height">The torus height.</param>
        public Torus(int width = 80, int height = 25)
        {
            this.Width = width;
            this.Height = height;
            this.TorusContent = new string[width, height];
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
        public string[,] TorusContent
        {
            get;
            private set;
        }
    }
}
