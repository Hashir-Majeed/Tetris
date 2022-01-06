using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class GenericStack<T>
    {
        private T[] objects;
        private int top;
        private int depth;
        public GenericStack(int depth)
        {
            objects = new T[depth];
            top = 0;
            this.depth = depth;
        }

        public void Push(T s)
        {

            if(!(top == depth)){ 
                objects[top] = s;
                top++;
            }


        }

        public T Pop()
        {

            if (! (top==0))
            {
                top--;
                return objects[top];
            }
            else
            {
                return default(T);
            }

        }
    }
}
