using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * TETRIS AI 
 * 
 * Uses 4 heuristics [holes, bumpiness, height and lines cleared] to evaluate the next best move.
 * Iterates through every rotation and every possible position. Chooses best move.
 * 
 * Inherits Tetris Game Class for common functions such as getScore, CheckWin, DropPiece, etc.
 * 
 */
namespace Tetris
{
    class AI : TetrisGame
    {
        private Board board;
        private Tetramino currentTetramino;
        private double holeWeight;
        private double bumpinessWeight;
        private double heightWeight;
        private double linesWeight;
        public AI(double holeWeight, double bumpinessWeight, double heightWeight, double linesWeight) : base()
        {
            this.holeWeight = holeWeight;
            this.bumpinessWeight = bumpinessWeight;
            this.heightWeight = heightWeight;
            this.linesWeight = linesWeight;

            board = GetBoard();
            currentTetramino = GetCurrentTetramino();
        }

        public void ComputeMove()
        {
            // Given the current game state, iterates through every possible move
            // Calls Score Function for each move
            // Records and makes Best Move


            currentTetramino = GetCurrentTetramino();
            int numConfigurations = currentTetramino.GetAIMoves();
            int count = 0;
            bool hitEdge = false;
            double moveScore;
            double bestScore = -9999;
            int bestRotation = -1;
            int bestPosition = -1;

            // Iterates through each rotation
            for (int i = 0; i < currentTetramino.GetRotationalSymmetry(); i++)
            {
                // Iterations through each horizontal position
                while (count < numConfigurations && !hitEdge)
                {
                    // Place piece and evaluate score
                    int rowsDropped = AIDrop();
                    moveScore = ComputeMoveScore();
                    if (moveScore > bestScore)
                    {
                        bestScore = moveScore;
                        bestRotation = i;
                        bestPosition = count;
                    }
                    // Undo Move
                    ShiftUp(rowsDropped - 1);
                    count++;

                    if (!ShiftRight())
                    {
                        hitEdge = true;                 
                    }
                    

                }
                // Prepare board for next Rotation
                board.DeletePiece(currentTetramino.GetPiece());
                currentTetramino.ResetCoordinates();
                PlacePiece();
                count = 0;
                hitEdge = false;
                RotatePiece();
            }
            // Reset board
            board.DeletePiece(currentTetramino.GetPiece());
            // Get the best recorded move
            currentTetramino.SetRotation(bestRotation);
            PlacePiece();
            for (int i = 0; i < bestPosition; i++)
            {
                ShiftRight();
            }
            // Make Best Move
            DropPiece();

        }

        private double ComputeMoveScore()
        {
            // Returns Double: MoveScore
            // Evaluates the 4 heuristics with their respective weights

            return  (linesWeight * GetLines()) + (bumpinessWeight*board.Bumpiness() + holeWeight * board.CountHoles() +heightWeight * board.TotalHeight());
        }

        private int AIDrop()
        {
            // Returns int: number of squares dropped
            // Drops a piece, but does NOT start the next move, since for the AI, other moves still need to be considered

            bool dropped = false;
            int count = 0;
            while (!dropped)
            {
                dropped = AIDown();
                count++;
            }

            return count;
        }

        private bool AIDown()
        {
            // Returns bool: has hit bottom?
            // Shifts a Piece Down. Does NOT start next move since for the AI, other moves still need to be considered


            Coordinates[] toDelete = currentTetramino.GetPiece();
            bool finished = false;

            currentTetramino.ShiftDown(1);

            if (!CheckValidMove(toDelete))
            {
                currentTetramino.ShiftDown(-1);
                finished = true;
            }
            else
            {
                board.DeletePiece(toDelete);

            }

            PlacePiece();

            return finished;
        }
    }
}
