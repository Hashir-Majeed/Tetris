using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class AI : TetrisGame
    {
        private Board board;
        private Tetramino currentTetramino;
        private const double holeWeight = -0.8;
        private const double bumpinessWeight = -0.3;
        private const double heightWeight = -0.5;
        private const double linesWeight = 0.7;
        public AI() : base()
        {
            board = GetBoard();
            currentTetramino = GetCurrentTetramino();
        }

        public void ComputeMove()
        {
            currentTetramino = GetCurrentTetramino();
            int numConfigurations = currentTetramino.GetAIMoves();
            //double[] scores = new double[numConfigurations];
            int count = 0;
            bool hitEdge = false;
            double moveScore;
            double bestScore = -9999;
            int bestRotation = -1;
            int bestPosition = -1;

            for (int i = 0; i < currentTetramino.getRotationalSymmetry(); i++)
            {
                while (count < numConfigurations && !hitEdge)
                {
                    int rowsDropped = AIDrop();
                    //scores[count] = ComputeMoveScore();
                    moveScore = ComputeMoveScore();
                    if (moveScore > bestScore)
                    {
                        bestScore = moveScore;
                        bestRotation = i;
                        bestPosition = count;
                    }
                    ShiftUp(rowsDropped - 1);
                    count++;
                    if (!ShiftRight())
                    {
                        hitEdge = true;                 
                    }
                    

                }
                board.DeletePiece(currentTetramino.getPiece());
                currentTetramino.ResetCoordinates();
                PlacePiece();
                count = 0;
                hitEdge = false;
                RotatePiece();
            }

            //MaxIndex(scores);
            board.DeletePiece(currentTetramino.getPiece());
            currentTetramino.SetRotation(bestRotation);
            PlacePiece();
            for (int i = 0; i < bestPosition; i++)
            {
                ShiftRight();
            }

            DropPiece();

        }

        private double ComputeMoveScore()
        {
            return  (linesWeight * GetLines()) + (bumpinessWeight*board.Bumpiness() + holeWeight * board.CountHoles() +heightWeight * board.TotalHeight());
        }

        private int AIDrop()
        {
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
            Coordinates[] toDelete = currentTetramino.getPiece();
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
