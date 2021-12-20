using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    abstract class Tetramino
    {
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

            piece = CreatePiece(piece);
        }

        public int[,] Rotate(int[,] tetramino)
        {

            for (int i = 0; i < tetramino.GetLength(1) / 2; i++)
            {
                for (int j = 0; j < tetramino.GetLength(1) - i - 1; j++)
                {
                    int temp = tetramino[i, j];
                    tetramino[i, j] = tetramino[tetramino.GetLength(1) - j - 1, i];
                    tetramino[tetramino.GetLength(1) - j - 1, i] = tetramino[tetramino.GetLength(1) - i - 1, tetramino.GetLength(1) - j - 1];
                    tetramino[tetramino.GetLength(1) - i - 1, tetramino.GetLength(1) - j - 1] = tetramino[j, tetramino.GetLength(1) - i - 1];
                    tetramino[j, tetramino.GetLength(1) - i - 1] = temp;
                }
            }

            return tetramino;
        }

        public abstract int[,] CreatePiece(int[,] piece);
        public int[,] getPiece()
        {
            return piece;
        }

        public int getType()
        {
            return type;
        }
    }
}
