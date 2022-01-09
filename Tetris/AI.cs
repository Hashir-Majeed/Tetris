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
        private const double holeWeight = 1;
        private const double bumpinessWeight = 1;
        private const double heightWeight = 1;
        private const double linesWeight = 1;
        public AI() : base()
        {
            board = GetBoard();
            currentTetramino = GetCurrentTetramino();
        }

        public void ComputeMove()
        {
            
            int numConfigurations = currentTetramino.GetAIMoves();
            double[] scores = new double[numConfigurations];
            int count = 0;
            bool hitEdge = false;



            for (int i = 0; i < currentTetramino.getRotationalSymmetry(); i++)
            {
                while (count < numConfigurations && !hitEdge)
                {
                    int rowsDropped = DropPiece();
                    scores[count] = ComputeMoveScore();
                    ShiftUp(rowsDropped);
                    count++;
                    if (!ShiftRight())
                    {
                        hitEdge = true;                 
                    }
                    

                }
                currentTetramino.ResetCoordinates();
                RotatePiece();
            }

            MaxIndex(scores);
            
        }

        private double ComputeMoveScore()
        {
            return  (linesWeight * GetLines()) - (bumpinessWeight*board.Bumpiness() + holeWeight * board.CountHoles() +heightWeight * board.TotalHeight());
        }

        private int MaxIndex(double[] array)
        {
            double max = -99999;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    index = i;
                }
            }

            return index;
        }
    }
}
