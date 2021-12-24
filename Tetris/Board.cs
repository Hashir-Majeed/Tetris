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
        private const int WIDTH = 12;
        private const int HEIGHT = 21;
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

            for (int i = 0; i < HEIGHT; i++)
            {
                board[0,i].setType(-1);

                board[WIDTH - 1, i].setType(-1);
            }
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

        public int getHeight()
        {
            return HEIGHT;
        }

        public int getWidth()
        {
            return WIDTH;
        }

        public Square[,] getBoard()
        {
            return board;
        }

        public void setBoard(int x, int y, int val)
        {
            board[x, y].setType(val);
        }

        public void DeletePiece(Coordinates[] coordinates)
        {
            for (int i = 0; i < coordinates.Length; i++)
            {
                board[coordinates[i].getX(), coordinates[i].getY()].setType(0);
            }
        }


    }
}
