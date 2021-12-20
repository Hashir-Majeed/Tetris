using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class SquareTetramino : Tetramino
    {

        public SquareTetramino() : base(1, 2)
        {

        }
        public override int[,] CreatePiece(int[,] piece)
        {
            piece[0, 0] = 1;
            piece[0, 1] = 1;
            piece[1, 1] = 1;
            piece[1, 0] = 1;

            return piece;
        }
    }
}
