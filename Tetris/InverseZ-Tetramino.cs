using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class InverseZ_Tetramino : Tetramino
    {

        public InverseZ_Tetramino() : base(7, 3)
        {
            
            
        }
        public override int[,] CreatePiece(int[,] piece)
        {
            piece[0, 2] = 7;
            piece[0, 1] = 7;
            piece[1, 1] = 7;
            piece[1, 0] = 7;

            return piece;
        }
    }
}
