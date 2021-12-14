using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class TetrisGame
    {
        public Board b;
        public TetrisGame()
        {
            b = new Board();
        }

        public Board GetBoard()
        {

            return b;

        }

        public void Update()
        {
            b.Update(new Square(5));
        }

    }
}
