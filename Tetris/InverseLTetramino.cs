using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class InverseLTetramino : Tetramino
    {

        public InverseLTetramino() : base(5, 3)
        {
            
            
        }
        public override int[,] CreatePiece(int[,] piece)
        {
            piece[0, 0] = 5;
            piece[0, 1] = 5;
            piece[0, 2] = 5;
            piece[1, 2] = 5;

            return piece;
        }
    }
}
