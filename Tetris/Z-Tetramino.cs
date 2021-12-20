using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Z_Tetramino : Tetramino
    {
        public Z_Tetramino() : base(6, 3)
        {

        }
        public override int[,] CreatePiece(int[,] piece)
        {
            piece[0, 0] = 6;
            piece[0, 1] = 6;
            piece[1, 1] = 6;
            piece[1, 2] = 6;
            return piece;
        }
    }
}
