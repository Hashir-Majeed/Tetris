﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class SquareTetramino : Tetramino
    {
        private int colour = 1;

        Coordinates[] Rotation1 = new Coordinates[] { new Coordinates(1, 1), new Coordinates(1, 2), new Coordinates(2, 2), new Coordinates(2,1) };
        protected override Coordinates Deafult => new Coordinates(0, 0);

        protected override Coordinates[][] Piece => new Coordinates[][]
        {
            Rotation1
        };

        public int getColour()
        {
            return colour;
        }
    }
}