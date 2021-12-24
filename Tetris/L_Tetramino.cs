using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class L_Tetramino :Tetramino
    {
        private int colour = 5;

        Coordinates[] Rotation1 = new Coordinates[] { new Coordinates(1, 2), new Coordinates(2, 2), new Coordinates(3, 2), new Coordinates(3, 1) };
        Coordinates[] Rotation2 = new Coordinates[] { new Coordinates(1, 1), new Coordinates(1, 2), new Coordinates(1, 3), new Coordinates(2, 3) };
        Coordinates[] Rotation4 = new Coordinates[] { new Coordinates(2, 3), new Coordinates(2, 1), new Coordinates(2, 2), new Coordinates(1, 1) };
        Coordinates[] Rotation3 = new Coordinates[] { new Coordinates(1, 1), new Coordinates(1, 2), new Coordinates(3, 1), new Coordinates(2, 1) };
        protected override Coordinates Deafult => new Coordinates(0, 0);

        protected override Coordinates[][] Piece => new Coordinates[][]
        {
            Rotation1,
            Rotation2,
            Rotation3,
            Rotation4
        };

        public int getColour()
        {
            return colour;
        }
    }
}
