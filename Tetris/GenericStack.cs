using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /*
     * GENERIC STACK
     * 
     * Custom Stack for any generic data type
     * Used to hold the Hold Piece by the user
     */

    class GenericStack<T>
    {
        private T[] objects;
        private int top;
        private int depth;
        private bool isFull;
        public GenericStack(int depth)
        {
            objects = new T[depth];
            top = 0;
            isFull = false;
            this.depth = depth;
        }

        public void Push(T s)
        {

            if(!(top == depth)){ 
                objects[top] = s;
                top++;
            }
            if(top == depth)
            {
                isFull = true;
            }

        }

        public T Pop()
        {

            if (! (top==0))
            {
                top--;
                isFull = false;
                return objects[top];
            }
            else
            {
                return default(T);
            }

        }

        public bool Full()
        {
            return isFull;
        }
    }
}
