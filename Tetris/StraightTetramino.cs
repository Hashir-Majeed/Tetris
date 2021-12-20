using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class StraightTetramino : Tetramino
    {
        public StraightTetramino() : base(2, 4)
        {

            
        }
        public override int[,] CreatePiece(int[,] piece)
        {
            piece[0, 0] = 2;
            piece[0, 1] = 2;
            piece[0, 2] = 2;
            piece[0, 3] = 2;

            return piece;
        }
    }
}
