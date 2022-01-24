using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * COORDINATES CLASS
 * 
 * Contains X and Y coordinates for Pieces
 * 
 */


namespace Tetris
{
    class Coordinates
    {

        private int XPos;
        private int YPos;

        public Coordinates(int X, int Y)
        {
            XPos = X;
            YPos = Y;
        }

        public int getX()
        {
            return XPos;
        }

        public int getY()
        {
            return YPos;
        }

        public void setX(int x)
        {
            XPos = x;
        }

        public void setY(int y)
        {
            YPos = y;
        }
    }
}
