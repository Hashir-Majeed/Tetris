using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /*
     * SQUARE CLASS
     * Contains the data about the squares - 252 of which make up the game board
     */
    class Square
    {
        private int pos;
        private int type;
        public Square(int position, int type)
        {
            pos = position;
            this.type = type;
        }

        public void SetType(int type)
        {
            this.type = type;
        }

        public int GetSquareType()
        {
            return type;
        }
        public int GetPos()
        {
            return pos;
        }
    }
}
