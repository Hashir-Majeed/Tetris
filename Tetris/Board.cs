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
        private ObservableCollection<Square> C = new ObservableCollection<Square>();
        private const int WIDTH = 10;
        private const int HEIGHT = 20;
        private Square[,] board;
        public Board()
        {
            for (int x = 0; x < 52; x = x + 1)
            {
                C.Add(null);
                
            }

            board = new Square[WIDTH, HEIGHT];
            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    board[i, j] = new Square(0);
                }
            }
        }

        public ObservableCollection<Square> pos
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


        public Square[,] GetBoard()
        {
            return board;
        }

        /*public void PlaceTetramino(Tetramino t)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j].SetValue(t.GetTetramino()[i, j].GetValue());
                }
            }
        }*/


    }
}
