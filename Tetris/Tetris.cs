using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class TetrisGame
    {
        public TetrisGame()
        {
            Board b = new Board();
        }

        public Board board
        {
            get
            {
                return board;
            }

        }
    }
}
