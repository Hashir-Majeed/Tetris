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
            
            currentTetramino = new T_Tetramino();
            PlacePiece();
        }

        public Board GetBoard()
        {
            return b;
        }

        public bool CheckValidMove(Coordinates[] previousCoordinates)
        {           
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

        public void RotatePiece()
        {
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
        }

        public void ShiftDown()
        {
            Coordinates[] toDelete = currentTetramino.getPiece();

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

        }

        public void ShiftLeft()
        {

            Coordinates[] toDelete = currentTetramino.getPiece();
            currentTetramino.ShiftHorizontal(-1);

            if (!CheckValidMove(toDelete))
            {
                currentTetramino.ShiftHorizontal(1);
            }
            else
            {
                b.DeletePiece(toDelete);
            }


            PlacePiece();
        }

        public void ShiftRight()
        {
            Coordinates[] toDelete = currentTetramino.getPiece();
            currentTetramino.ShiftHorizontal(1);

            if (!CheckValidMove(toDelete))
            {
                currentTetramino.ShiftHorizontal(-1);
            }
            else
            {
                b.DeletePiece(toDelete);
            }


            PlacePiece();
        }

        public void PlacePiece()
        {
            Coordinates[] temp = currentTetramino.getPiece();

            for (int i = 0; i < temp.Length; i++)
            {
                b.setBoard(temp[i].getX(), temp[i].getY(), currentTetramino.getColour());
            }
        }


    }
}
