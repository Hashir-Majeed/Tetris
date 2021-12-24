using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    abstract class Tetramino
    {
        protected abstract Coordinates[][] Piece { get; }
        protected abstract Coordinates Deafult { get; }

        private Coordinates coordinates;
        private int currentRotation;

        public Tetramino()
        {
            coordinates = new Coordinates(Deafult.getX(), Deafult.getY());
            currentRotation = 0;
        }

        public void Rotate()
        {
            currentRotation = (currentRotation + 1) % Piece.Length;
        }

        public void ShiftDown(int rows)
        {
            int current = coordinates.getY();
            coordinates.setY(current + rows);
        }

        public void ShiftHorizontal(int columns)
        {
            coordinates.setX(coordinates.getX() + columns);
        }

        public Coordinates getCoordinates()
        {
            return coordinates;
        }

        public Coordinates[] getPiece()
        {
            Coordinates[] currentCoordinates = new Coordinates[Piece[currentRotation].Length];

            for (int i = 0; i < Piece[currentRotation].Length; i++)
            {
                currentCoordinates[i] = new Coordinates(Piece[currentRotation][i].getX() + coordinates.getX(), Piece[currentRotation][i].getY() + coordinates.getY());
            }

            return currentCoordinates;
        }

    }
}
