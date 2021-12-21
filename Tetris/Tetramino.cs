using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    abstract class Tetramino
    {
        private int Xpos;
        private int Ypos;

        private int type;
        private int[,] piece;
        //private bool inPlay;
        public Tetramino(int num, int size)
        {
            type = num;
            piece = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    piece[i, j] = 0;
                }
            }
            Xpos = 0;
            Ypos = 0;
            piece = CreatePiece(piece);
        }

        public int[,] Rotate()
        {

            for (int i = 0; i < piece.GetLength(1) / 2; i++)
            {
                for (int j = 0; j < piece.GetLength(1) - i - 1; j++)
                {
                    int temp = piece[i, j];
                    piece[i, j] = piece[piece.GetLength(1) - j - 1, i];
                    piece[piece.GetLength(1) - j - 1, i] = piece[piece.GetLength(1) - i - 1, piece.GetLength(1) - j - 1];
                    piece[piece.GetLength(1) - i - 1, piece.GetLength(1) - j - 1] = piece[j, piece.GetLength(1) - i - 1];
                    piece[j, piece.GetLength(1) - i - 1] = temp;
                }
            }

            return piece;
        }

        public abstract int[,] CreatePiece(int[,] piece);
        public int[,] getPiece()
        {
            return piece;
        }

        public void setPiece(int[,] newPiece)
        {
            for (int i = 0; i < newPiece.GetLength(0); i++)
            {
                for (int j = 0; j < newPiece.GetLength(0); j++)
                {
                    piece[i, j] = newPiece[i, j];
                }
            }
        }
        public int getType()
        {
            return type;
        }

        public int getX()
        {
            return Xpos;
        }

        public void setX(int x)
        {
            Xpos = x;
        }

        public int getY()
        {
            return Ypos;
        }

        public void setY(int y)
        {
            Ypos = y;
        }
    }
}
