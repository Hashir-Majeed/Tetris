using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Tetris
{
    class Board
    {
        private ObservableCollection<Position> C = new ObservableCollection<Position>();
        public Board()
        {
            for (int x = 0; x < 52; x = x + 1)
            {
                C.Add(new Position(null));
            }
        }

        public ObservableCollection<Position> pos
        {
            get
            {
                return C;
            }


        }

        public void Update(Square v)
        {
            /*if (C[v.getSuit() * 13 + v.getPos()].c == null)
            {
                C[v.getSuit() * 13 + v.getPos()].c = v;
            }
            else
            {

            }*/
        }

    }
}
