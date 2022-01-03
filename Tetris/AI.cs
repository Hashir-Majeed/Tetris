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
        private double holeWeight;
        private double bumpinessWeight;
        private double heightWeight;
        private double linesWeight;
        public AI() : base()
        {
            board = GetBoard();
            currentTetramino = GetCurrentTetramino();
        }

        public void ComputeMove()
        {
            int currentBest = -99999;
            Coordinates[] currentRotation = currentTetramino.getPiece();

            for (int i = 0; i < currentTetramino.getRotationalSymmetry(); i++)
            {

            }
        }

        private double ComputeMoveScore()
        {
            return  (linesWeight * GetLines()) - (bumpinessWeight*board.Bumpiness() + holeWeight * board.CountHoles() +heightWeight * board.TotalHeight());
        }
    }
}
