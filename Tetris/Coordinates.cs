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


        // Get Set Methods

        public int GetX()
        {
            return XPos;
        }

        public int GetY()
        {
            return YPos;
        }

        public void SetX(int x)
        {
            XPos = x;
        }

        public void SetY(int y)
        {
            YPos = y;
        }
    }
}
