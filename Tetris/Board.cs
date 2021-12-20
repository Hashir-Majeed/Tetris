using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Tetris
{
    class Board
    {
        //private ObservableCollection<Square> C = new ObservableCollection<Square>();
        private const int WIDTH = 10;
        private const int HEIGHT = 20;
        private Square[,] board;
        private Square[] UIBoard;
        public Board()
        {
            /*for (int x = 0; x < 52; x = x + 1)
            {
                C.Add(null);
                
            }*/

            board = new Square[WIDTH, HEIGHT];
            UIBoard = new Square[WIDTH*HEIGHT];
            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    board[i, j] = new Square(0, 0);
                    UIBoard[WIDTH * j + i] = board[i, j];
                }
            }
            board[0, 0].setType(1);
        }

        /*public ObservableCollection<Square> pos
        {
            get
            {
                return C;
            }


        }

        public void Update(Square x)
        {
            C[x.getPos()] = x;
        }

        */
        public Square[] GetUIBoard()
        {
            return UIBoard;
        }

        public void PlaceTetramino(Tetramino t, int startX, int startY)
        {
            for (int i = startX; i < startX + t.getPiece().GetLength(1); i++)
            {
                for (int j = startY; j < startY + t.getPiece().GetLength(1); j++)
                {
                    board[i, j].setType(t.getPiece()[i - startX, j - startY]);
                }
            }
        }


    }
}
