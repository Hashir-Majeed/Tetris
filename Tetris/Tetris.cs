using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /*
     * TETRIS GAME
     * 
     * Main Game Class
     * Contains Game Functionality - Moving Pieces, Check Lost, Next Piece Queue etc
     * 
     */
    class TetrisGame
    {
        private Board b;
        private int linesCleared;
        private int TotalLines;
        private GenericQueue<Tetramino> PieceQueue;
        private GenericStack<Tetramino> HoldStack;
        private Tetramino currentTetramino;
        private Random randomGenerator = new Random();
        private const int NUM_PIECES = 7;
        private int score;
        private int level;
        private Dictionary<int, int> pointMapping;
        private bool lost;
        private bool canUserHold;
        public TetrisGame()
        {
            // Initialise Game
            // Create Initial Piece Queue
            // Creates Board
            // Places first piece
            lost = false;
            canUserHold = true;
            TotalLines = 0;
            score = 0;
            level = 1;
            pointMapping = new Dictionary<int, int>();
            pointMapping.Add(1, 100);
            pointMapping.Add(2, 300);
            pointMapping.Add(3, 500);
            pointMapping.Add(4, 800);
            b = new Board();
            PieceQueue = new GenericQueue<Tetramino>(NUM_PIECES);
            HoldStack = new GenericStack<Tetramino>(1);
            PieceQueue.Enqueue(new SquareTetramino());
            PieceQueue.Enqueue(new StraightTetramino());
            PieceQueue.Enqueue(new T_Tetramino());
            PieceQueue.Enqueue(new InverseL_Tetramino());
            PieceQueue.Enqueue(new L_Tetramino());
            PieceQueue.Enqueue(new InverseZ_Tetramino());
            PieceQueue.Enqueue(new Z_Tetramino());

            currentTetramino = PieceQueue.Dequeue();       
            PieceQueue.Enqueue(AddRandomPiece());
            PlacePiece();
        } 

        public bool CheckValidMove(Coordinates[] previousCoordinates)
        {
            // Given the previous piece coordinates, check if the current move was valid
            // Checks that a) There is no other piece in its current position and b) that it's still in the bounds of the board

            bool valid = true;
            Coordinates[] temp = currentTetramino.getPiece();

            for (int i = 0; i < temp.Length; i++)
            {
                try
                {
                    if ((b.getBoard()[temp[i].getX(), temp[i].getY()].getType() > 0 && !CheckExistsInPreviousPiece(temp[i], previousCoordinates)) || temp[i].getX() == 0 || temp[i].getX() == b.getWidth() - 1 || temp[i].getY() == b.getHeight() - 1)
                    {
                        valid = false;
                    }
                }
                catch
                {
                    valid = false;
                }
                
            }
            

            return valid;
        }

        private bool CheckExistsInPreviousPiece(Coordinates toCheck, Coordinates[] previous)
        {
            // Given previous Coordinates, and current Coordinates, Checks that there is no overlap

            bool exists = false;

            for (int i = 0; i < previous.Length; i++)
            {
                if (toCheck.getX() == previous[i].getX() && toCheck.getY() == previous[i].getY())
                {
                    exists = true;
                }
            }

            return exists;
        }

        public int DropPiece()
        {
            // Hard Drops a piece
            // Iterates shifting down until another piece is hit

            bool dropped = false;
            int count = 0;
            while (!dropped)
            {
                dropped = ShiftDown();
                count++;
            }

            return count;
            
        }
        public void RotatePiece()
        {
            // Increments Current Rotation for the Current Tetramino
            // If not a valid move, then the rotation is undone

            Coordinates[] toDelete = currentTetramino.getPiece();
            currentTetramino.Rotate();

            if (!CheckValidMove(toDelete))
            {
                for (int i = 0; i < currentTetramino.getRotationalSymmetry() - 1; i++)
                {
                    currentTetramino.Rotate();
                }
            }
            else
            {
                b.DeletePiece(toDelete);
            }

            PlacePiece();
            lost = b.CheckWin();

            // If move has ended, the piece is placed, and the next move is begun

            if (CheckEndMove(currentTetramino.getPiece()) && !lost)
            {
                StartNextMove();
            }
        }

        public bool ShiftDown()
        {
            // Shifts Current Tetramino's Coordinates Down 1
            // If not valid move, then it moves it back up 1 to its original position

            Coordinates[] toDelete = currentTetramino.getPiece();
            bool finished = false;

            currentTetramino.ShiftDown(1);

            if (!CheckValidMove(toDelete))
            {
                currentTetramino.ShiftDown(-1);
            }
            else
            {
                b.DeletePiece(toDelete);
            }

            PlacePiece();
            lost = b.CheckWin();

            if (lost && CheckEndMove(currentTetramino.getPiece())) 
            {
                finished = true;
            }

            // If move has ended, the piece is placed, and the next move is begun

            if (CheckEndMove(currentTetramino.getPiece()) && !lost)
            {
                StartNextMove();
                finished = true;
            }

            return finished;
        }

        public void ShiftUp(int rows)
        {
            // Given a number of rows, shifts the current Tetramino up that many times
            // Used by the AI to undo a move

            Coordinates[] toDelete = currentTetramino.getPiece();

            currentTetramino.ShiftDown(-1 * rows);

            if (!CheckValidMove(toDelete))
            {
                currentTetramino.ShiftDown(rows);
            }
            else
            {
                b.DeletePiece(toDelete);
            }

            PlacePiece();
        }

        public bool ShiftLeft()
        {
            // Shifts Current Tetramino's Coordinates Left 1
            // If not valid move, then it moves it back Right 1 to its original position

            bool valid = true;
            Coordinates[] toDelete = currentTetramino.getPiece();
            currentTetramino.ShiftHorizontal(-1);

            if (!CheckValidMove(toDelete))
            {
                currentTetramino.ShiftHorizontal(1);
                valid = false;
            }
            else
            {
                b.DeletePiece(toDelete);
            }


            PlacePiece();
            lost = b.CheckWin();

            // If move has ended, the piece is placed, and the next move is begun

            if (CheckEndMove(currentTetramino.getPiece()) && !lost)
            {
                StartNextMove();
            }

            return valid;
        }

        public bool ShiftRight()
        {
            // Shifts Current Tetramino's Coordinates Right 1
            // If not valid move, then it moves it back Left 1 to its original position

            bool valid = true;
            Coordinates[] toDelete = currentTetramino.getPiece();
            currentTetramino.ShiftHorizontal(1);

            if (!CheckValidMove(toDelete))
            {
                currentTetramino.ShiftHorizontal(-1);
                valid = false;
            }
            else
            {
                b.DeletePiece(toDelete);
            }


            PlacePiece();
            lost = b.CheckWin();

            // If move has ended, the piece is placed, and the next move is begun

            if (CheckEndMove(currentTetramino.getPiece()) && !lost)
            {
                StartNextMove();
            }
            return valid;
        }

        public void HoldPiece()
        {
            // Holds the current piece

            Tetramino tempTetramino;
            Coordinates[] toDelete = currentTetramino.getPiece();

            if (HoldStack.Full())
            {
                // If there already exists a Hold Piece
                // Then swap the pieces
                tempTetramino = currentTetramino;
                b.DeletePiece(toDelete);
                currentTetramino = HoldStack.Pop();
                currentTetramino.ResetCoordinates();
                HoldStack.Push(tempTetramino);

                canUserHold = false;
            }
            else
            {
                //If no piece is currently being held, push the current piece to Hold Piece, and start the next move
                HoldStack.Push(currentTetramino);
                b.DeletePiece(toDelete);
                StartNextMove();
            }

            
        }

        private bool CheckEndMove(Coordinates[] piece)
        {
            // Checks if a piece has landed or the piece has hit the top [returns bool true if move has ended]

            bool landed = false;
            int Ypos = 0;
            int Xpos = 0;
            Coordinates tempCoordinates;

            for (int i = 0; i < piece.Length; i++)
            {
                Ypos = piece[i].getY();
                Xpos = piece[i].getX();
                tempCoordinates = new Coordinates(Xpos, Ypos + 1);
                
                if (Ypos == b.getHeight() - 2 || (b.getBoard()[Xpos, Ypos + 1].getType() > 0 && !CheckExistsInPreviousPiece(tempCoordinates, piece)))
                {
                    landed = true;
                }

            }

            return landed;
        }

        

        public void PlacePiece()
        {
            // Places a piece on the board

            Coordinates[] temp = currentTetramino.getPiece();

            for (int i = 0; i < temp.Length; i++)
            {
                b.setBoard(temp[i].getX(), temp[i].getY(), currentTetramino.getColour());
            }
        }

        private void StartNextMove()
        {
            linesCleared = b.CheckFullRows();
            canUserHold = true;
            if(linesCleared != 0)
            {
                TotalLines += linesCleared;
                score += pointMapping[linesCleared] * level;
                level = 1 + (TotalLines/5);
            }
            score += 4;
            currentTetramino = PieceQueue.Dequeue();
            PieceQueue.Enqueue(AddRandomPiece());
            PlacePiece();
        }

        private Tetramino AddRandomPiece()
        {
            // Returns a new random tetramino

            Tetramino nextPiece = null;
            int randomNum = randomGenerator.Next(NUM_PIECES);

            if (randomNum == 0)
            {
                nextPiece = new StraightTetramino();
            }
            if (randomNum == 1)
            {
                nextPiece = new SquareTetramino();
            }
            if (randomNum == 2)
            {
                nextPiece = new T_Tetramino();
            }
            if (randomNum == 3)
            {
                nextPiece = new InverseL_Tetramino();
            }
            if (randomNum == 4)
            {
                nextPiece = new L_Tetramino();
            }
            if (randomNum == 5)
            {
                nextPiece = new InverseZ_Tetramino();
            }
            if (randomNum == 6)
            {
                nextPiece = new Z_Tetramino();
            }

            return nextPiece;
        }

        public int GetLevel()
        {
            return level;
        }

        public int GetScore()
        {
            return score;
        }

        public Tetramino GetCurrentTetramino()
        {
            return currentTetramino;
        }

        public int GetLines()
        {
            return linesCleared;
        }

        public Tetramino GetNextPiece()
        {
            return PieceQueue.GetFrontPiece();
        }

        public bool IsLost()
        {
            return lost;
        }

        public int GetDelay()
        {
            int delay = 1000 - 400*level;

            if (delay < 0)
            {
                delay = 200;
            }

            return delay;
        }

        public bool CanUserHold()
        {
            return canUserHold;
        }

        public Board GetBoard()
        {
            return b;
        }
        public Tetramino GetHoldPiece()
        {
            Tetramino holding = HoldStack.Pop();
            holding.ResetCoordinates();
            HoldStack.Push(holding);
            return holding;
        }
    }
}
