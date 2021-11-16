using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Tetris
{
    class Position : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Square square = null;
        public Position(Square x)
        {
            square = x;
        }
        public Square c
        {
            get
            {
                return square;
            }

            set
            {
                square = value;
                OnPropertyChanged("c");
            }
        }
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
