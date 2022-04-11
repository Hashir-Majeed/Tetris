using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    // CLASS FOR THE Square TETRAMINO
    // Sub class of Tetramino
    class SquareTetramino : Tetramino
    {
        // Define constant values for the GUI and AI
        private const int COLOUR = 1;
        private const int POSSIBLE_POSITIONS = 9;

        // Define rotation matrix
        Coordinates[] Rotation1 = new Coordinates[] { new Coordinates(1, 1), new Coordinates(1, 2), new Coordinates(2, 2), new Coordinates(2,1) };
        protected override Coordinates Deafult => new Coordinates(0, 0);

        protected override Coordinates[][] Piece => new Coordinates[][]
        {
            Rotation1
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
