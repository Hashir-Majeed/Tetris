using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class L_Tetramino : Tetramino
    {
        public L_Tetramino() : base(4, 3)
        {

            
        }
        public override int[,] CreatePiece(int[,] piece)
        {
            piece[0, 0] = 4;
            piece[1, 0] = 4;
            piece[2, 0] = 4;
            piece[2, 1] = 4;

            return piece;
        }
    }
}
