using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class T_Tetramino : Tetramino
    {
        public T_Tetramino() : base(3, 3)
        {
         
        }

        public override int[,] CreatePiece(int[,] piece)
        {
            piece[0, 0] = 3;
            piece[0, 1] = 3;
            piece[0, 2] = 3;
            piece[1, 1] = 3;

            return piece;
        }
    }
}
