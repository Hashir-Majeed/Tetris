using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class TetrisGame
    {
        private Board b;
        private Tetramino currentTetramino;
        public TetrisGame()
        {
            b = new Board();
            currentTetramino = new InverseLTetramino();
            currentTetramino.setX(7);
            currentTetramino.setY(6);
        }

        public Board GetBoard()
        {
            return b;
        }

        public void RotatePiece()
        {
            currentTetramino.Rotate();
            b.DeleteTetramino(currentTetramino, currentTetramino.getX(), currentTetramino.getY());
            b.PlaceTetramino(currentTetramino, currentTetramino.getX(), currentTetramino.getY());
        }

        public void ShiftRight()
        {
            if (CheckValidMove(2))
            {
                b.DeleteTetramino(currentTetramino, currentTetramino.getX(), currentTetramino.getY());
                currentTetramino.setX(currentTetramino.getX() + 1);
                b.PlaceTetramino(currentTetramino, currentTetramino.getX(), currentTetramino.getY());
            }

            
        }

        public void ShiftLeft()
        {
            if (CheckValidMove(1))
            {
                b.DeleteTetramino(currentTetramino, currentTetramino.getX(), currentTetramino.getY());
                currentTetramino.setX(currentTetramino.getX() - 1);
                b.PlaceTetramino(currentTetramino, currentTetramino.getX(), currentTetramino.getY());
            }

            
        }

        public void ShiftDown()
        {
            if (CheckValidMove(0))
            {
                b.DeleteTetramino(currentTetramino, currentTetramino.getX(), currentTetramino.getY());
                currentTetramino.setY(currentTetramino.getY() + 1);
                b.PlaceTetramino(currentTetramino, currentTetramino.getX(), currentTetramino.getY());
            }
            
        }

        private bool CheckValidMove(int move)
        {
            // 0 = shift down
            // 1 = shift left
            // 2 = shift right

            bool valid = false;

            if (move == 0)
            {
                valid = currentTetramino.getY() + currentTetramino.getPiece().GetLength(1) < b.getHeight();
            }

            if (move == 1)
            {
                valid = currentTetramino.getX() > 0;
            }

            if (move == 2)
            {
                valid = currentTetramino.getX() + currentTetramino.getPiece().GetLength(1) < b.getWidth();
            }

            return valid;
        }

    }
}
