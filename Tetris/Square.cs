using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Square
    {
        private int pos;
        public Square(int position)
        {
            pos = position;   
        }

        public int getPos()
        {
            return pos;
        }
    }
}
