using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /* 
     * ABSTRACT CLASS - TETRAMINO
     * 
     * Contains common attributes and methods for all Tetramino Pieces e.g Deafult Coordinates, Offset, Rotations etc
     * Polymorphism used in Coordinates and Deafult data, as well Colour and AI Permutations methods.
     * 
     */
    abstract class Tetramino
    {
        protected abstract Coordinates[][] Piece { get; }
        protected abstract Coordinates Deafult { get; }

        private Coordinates coordinates;
        private int currentRotation;

        public Tetramino()
        {
            coordinates = new Coordinates(Deafult.GetX(), Deafult.GetY());
            currentRotation = 0;
            
        }

        public void Rotate()
        {
            currentRotation = (currentRotation + 1) % Piece.Length;
        }

        public void ShiftDown(int rows)
        {
            int current = coordinates.GetY();
            coordinates.SetY(current + rows);
        }

        public void ShiftHorizontal(int columns)
        {
            coordinates.SetX(coordinates.GetX() + columns);
        }

        public void ResetCoordinates()
        {
            coordinates.SetX(Deafult.GetX());
            coordinates.SetY(Deafult.GetY());
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
                currentCoordinates[i] = new Coordinates(Piece[currentRotation][i].GetX() + coordinates.GetX(), Piece[currentRotation][i].GetY() + coordinates.GetY());
            }

            return currentCoordinates;
        }

        public int getRotationalSymmetry()
        {
            return Piece.Length;
        }

        public void SetRotation(int rotation)
        {
            currentRotation = rotation;
        }
        public abstract int getColour();
        public abstract int GetAIMoves();
    }
}
