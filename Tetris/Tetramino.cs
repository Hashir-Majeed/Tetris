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
            // Increment the rotation matrix index
            currentRotation = (currentRotation + 1) % Piece.Length;
        }

        public void ShiftDown(int rows)
        {
            // Shift the piece down by the specified rows
            int current = coordinates.GetY();
            coordinates.SetY(current + rows);
        }

        public void ShiftHorizontal(int columns)
        {
            // Shift the piece laterally by the specified columns
            coordinates.SetX(coordinates.GetX() + columns);
        }

        public void ResetCoordinates()
        {
            // Set coordinates to their deafults
            coordinates.SetX(Deafult.GetX());
            coordinates.SetY(Deafult.GetY());
        }

        // Get Set methods
        public Coordinates GetCoordinates()
        {
            return coordinates;
        }

        public Coordinates[] GetPiece()
        {
            Coordinates[] currentCoordinates = new Coordinates[Piece[currentRotation].Length];

            for (int i = 0; i < Piece[currentRotation].Length; i++)
            {
                currentCoordinates[i] = new Coordinates(Piece[currentRotation][i].GetX() + coordinates.GetX(), Piece[currentRotation][i].GetY() + coordinates.GetY());
            }

            return currentCoordinates;
        }

        public int GetRotationalSymmetry()
        {
            return Piece.Length;
        }

        public void SetRotation(int rotation)
        {
            currentRotation = rotation;
        }

        // Abstract Methods
        public abstract int GetColour();
        public abstract int GetAIMoves();
    }
}
