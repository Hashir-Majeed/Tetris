namespace Tetris
{
    // CLASS FOR THE T TETRAMINO
    // Sub class of Tetramino
    class T_Tetramino : Tetramino
    {
        // Define constant values for the GUI and AI
        private const int COLOUR = 3;
        private const int POSSIBLE_POSITIONS = 34;

        // Define rotation matrix
        Coordinates[] Rotation1 = new Coordinates[] { new Coordinates(1, 1), new Coordinates(1, 2), new Coordinates(2, 2), new Coordinates(1, 3) };
        Coordinates[] Rotation2 = new Coordinates[] { new Coordinates(1, 2), new Coordinates(2, 2), new Coordinates(3,2), new Coordinates(2,3) };
        Coordinates[] Rotation4 = new Coordinates[] { new Coordinates(1, 2), new Coordinates(2, 2), new Coordinates(3, 2), new Coordinates(2, 1) };
        Coordinates[] Rotation3 = new Coordinates[] { new Coordinates(2, 2), new Coordinates(1, 2), new Coordinates(2, 1), new Coordinates(2, 3) };
        protected override Coordinates Deafult => new Coordinates(0, 0);

        protected override Coordinates[][] Piece => new Coordinates[][]
        {
            Rotation1,
            Rotation2,
            Rotation3,
            Rotation4
        };

        public override int getColour()
        {
            return COLOUR;
        }

        public override int GetAIMoves()
        {
            return POSSIBLE_POSITIONS;
        }
    }
}
