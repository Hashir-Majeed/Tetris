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
            b.DeleteTetramino(currentTetramino, currentTetramino.getX(), currentTetramino.getY());
            currentTetramino.setX(currentTetramino.getX() + 1);
            b.PlaceTetramino(currentTetramino, currentTetramino.getX(), currentTetramino.getY());
        }

        public void ShiftLeft()
        {
            b.DeleteTetramino(currentTetramino, currentTetramino.getX(), currentTetramino.getY());
            currentTetramino.setX(currentTetramino.getX() - 1);
            b.PlaceTetramino(currentTetramino, currentTetramino.getX(), currentTetramino.getY());
        }

        public void ShiftDown()
        {
            b.DeleteTetramino(currentTetramino, currentTetramino.getX(), currentTetramino.getY());
            currentTetramino.setY(currentTetramino.getY() + 1);
            b.PlaceTetramino(currentTetramino, currentTetramino.getX(), currentTetramino.getY());
        }

    }
}
