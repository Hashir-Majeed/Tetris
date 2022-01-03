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

        public int CheckFullRows()
        {
            bool full = true;
            int count = 0;

            for (int i = 1; i < HEIGHT - 1; i++)
            {
                full = true;
                for (int j = 1; j < WIDTH - 1; j++)
                {
                    if (board[j,i].getType() == 0)
                    {
                        full = false;
                    }
                    
                }
                if (full)
                {
                    ClearRow(i);
                    count++;
                }
            }

            return count;

        }

        private void ClearRow(int row)
        {
            for (int i = 1; i < WIDTH - 1; i++)
            {
                board[i, row].setType(0);
            }

            for (int i = row; i > 1; i--)
            {
                for (int j = 0; j < WIDTH -1;j++)
                {
                    board[j, i].setType(board[j, i - 1].getType());
                }
            }
        }

        public bool CheckWin()
        {
            bool lost = false;
            int counter = 1;

            while (!lost && counter < WIDTH - 1)
            {
                if (board[counter, 1].getType() != 0)
                {
                    lost = true;
                }
                counter++;
            }

            return lost;
        }

        public int CountHoles()
        {
            int numHoles = 0;
            bool valid = false;

            for (int i = 1; i < WIDTH - 1; i++)
            {
                valid = false;
                for (int j = 0; j < HEIGHT - 1; j++)
                {
                    if (board[i, j].getType() != 0)
                    {
                        valid = true;
                    }else if (board[i,j].getType() == 0 && valid)
                    {
                        numHoles = numHoles + 1;
                    }
                }
            }

            return numHoles;
        }

        private int GetColumnHeight(int col)
        {
            //int totalHeight = 0;
            int height = 0;
            bool found = false;
            int j = 0;

            while (!found && j < HEIGHT - 1)
            {
                if (board[col, j].getType() > 0)
                {
                    found = true;
                    height = HEIGHT - 1 - j;
                    //totalHeight += HEIGHT - 1 - j;
                }
                else
                {
                    j++;
                }
            }

            return height;

        }

        public int TotalHeight()
        {
            int totalHeight = 0;

            for (int i = 1; i < WIDTH - 1; i++)
            {
                totalHeight += GetColumnHeight(i);
            }

            return totalHeight;
        }


        public int Bumpiness()
        {
            int totalBumpiness = 0;

            for (int i = 1; i < WIDTH - 2; i++)
            {
                totalBumpiness += Math.Abs(GetColumnHeight(i) - GetColumnHeight(i + 1));
            }
            return totalBumpiness;
        }
    }
}
