﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    // CLASS FOR THE STRAIGHT TETRAMINO
    // Sub class of Tetramino
    class StraightTetramino : Tetramino
    {
        // Define constant values for the GUI and AI
        private const int COLOUR = 2;
        private const int POSSIBLE_POSITIONS = 17;

        // Define rotation matrix
        Coordinates[] Rotation1 = new Coordinates[] { new Coordinates(1, 1), new Coordinates(1, 2), new Coordinates(1, 3), new Coordinates(1, 4) };
        Coordinates[] Rotation2 = new Coordinates[] { new Coordinates(1, 1), new Coordinates(2, 1), new Coordinates(3, 1), new Coordinates(4, 1) };
        protected override Coordinates Deafult => new Coordinates(0, 0);

        protected override Coordinates[][] Piece => new Coordinates[][]
        {
            Rotation1,
            Rotation2
        };

        public override int GetColour()
        {
            return COLOUR;
        }

        public override int GetAIMoves()
        {
            return POSSIBLE_POSITIONS;
        }
    }
}
