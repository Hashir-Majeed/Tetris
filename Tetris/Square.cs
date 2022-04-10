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
        private int type;
        public Square(int position, int type)
        {
            pos = position;
            this.type = type;
        }

        public void setType(int type)
        {
            this.type = type;
        }

        public int getType()
        {
            return type;
        }
        public int getPos()
        {
            return pos;
        }
    }
}
