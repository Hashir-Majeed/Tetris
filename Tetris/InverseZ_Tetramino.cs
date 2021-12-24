using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class InverseZ_Tetramino : Tetramino
    {

        private int colour = 6;

        Coordinates[] Rotation1 = new Coordinates[] { new Coordinates(2, 1), new Coordinates(1, 2), new Coordinates(2, 2), new Coordinates(3, 1) };
        Coordinates[] Rotation2 = new Coordinates[] { new Coordinates(1, 1), new Coordinates(2, 2), new Coordinates(1, 2), new Coordinates(2, 3) };
        protected override Coordinates Deafult => new Coordinates(0, 0);

        protected override Coordinates[][] Piece => new Coordinates[][]
        {
            Rotation1,
            Rotation2
        };

        public override int getColour()
        {
            return colour;
        }
    }
}
