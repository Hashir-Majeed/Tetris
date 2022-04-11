using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

/*
 * BOARD CLASS
 * 
 * Stores Board Class as a 2D array of Square Objects. 
 * Contains functions for Board Manipulation such as ClearRows and CheckWin,as well as heuristic functions for the AI
 * 
 */

namespace Tetris
{
    class Board
    {
        private const int WIDTH = 12;
        private const int HEIGHT = 21;
        private Square[,] board;
        private Square[] UIBoard;

        // UIBoard is the one-dimensional array to enable binding. 
        // Each Element in UIBoard contains a reference to its respective Board Square
        public Board()
        {

            board = new Square[WIDTH, HEIGHT];
            UIBoard = new Square[WIDTH*HEIGHT];
            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    //Initialise Objects, set UIBoard References
                    board[i, j] = new Square(0, 0);
                    UIBoard[WIDTH * j + i] = board[i, j];
                }
            }
            // Set the board to be empty, and give the border a distinguishing value of -1
            for (int i = 0; i < HEIGHT; i++)
            {
                board[0,i].setType(-1);

                board[WIDTH - 1, i].setType(-1);
            }
        }      

        public void DeletePiece(Coordinates[] coordinates)
        {
            // Resets Values of a given input Coordinate Array back to 0 [deletes the piece]
            for (int i = 0; i < coordinates.Length; i++)
            {
                board[coordinates[i].GetX(), coordinates[i].GetY()].setType(0);
            }
        }

        public int CheckFullRows()
        {
            // Iterate through each row. If full, increment count
            // Returns int: number of full rows
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
            // Given a row, reset each of its Square Values to 0 [clear the row]
            for (int i = 1; i < WIDTH - 1; i++)
            {
                board[i, row].setType(0);
            }
            // Shift each row above down by 1
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
            // Check top row. If there is an element there, then the game is lost, so return true
            // Returns bool: is game lost?

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
            // If a piece has an empty value anywhere beneath a coloured picee, then numHoles is incremented
            // Return int: Number of Holes

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
            // Helper function for Bumpiness and Height functions
            // Returns height of a given column

            int height = 0;
            bool found = false;
            int j = 0;

            while (!found && j < HEIGHT - 1)
            {
                if (board[col, j].getType() > 0)
                {
                    found = true;
                    height = HEIGHT - 1 - j;
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
            // returns int: total heights
            // Gets Sum of Column Heights 

            int totalHeight = 0;

            for (int i = 1; i < WIDTH - 1; i++)
            {
                totalHeight += GetColumnHeight(i);
            }

            return totalHeight;
        }


        public int Bumpiness()
        {
            // return int: aggregate value for bumpiness
            // Gets average aggreagate change in height between columns

            int totalBumpiness = 0;

            for (int i = 1; i < WIDTH - 2; i++)
            {
                totalBumpiness += Math.Abs(GetColumnHeight(i) - GetColumnHeight(i + 1));
            }
            return totalBumpiness;
        }

        // Get Set Methods

        public Square[] GetUIBoard()
        {
            return UIBoard;
        }

        public int GetHeight()
        {
            return HEIGHT;
        }

        public int GetWidth()
        {
            return WIDTH;
        }

        public Square[,] GetBoard()
        {
            return board;
        }

        public void SetBoard(int x, int y, int val)
        {
            board[x, y].setType(val);
        }
    }
}
