using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /*
     * GENERIC QUEUE
     * 
     * A Custom Queue for any generic data type
     * Used to store the queue of randomly generated Next Pieces
     * 
     */
    class GenericQueue<T>
    {
        private T[] Queue;
        private int front;
        private int back;
        private bool isFull;

        public GenericQueue(int size)
        {
            Queue = new T[size];
            front = 0;
            back = 0;
            isFull = false;
        }

        public void Enqueue(T toAdd)
        {
            // Adds the toAdd element to the end of the queue
            if (!isFull)
            {
                Queue[back] = toAdd;
                back = (back + 1) % Queue.Length;
            }

            if (front == back)
            {
                isFull = true;
            }
        }

        public T Dequeue()
        {
            // return T: current front element of the Queue
            T val;

            if (back == front && !isFull)
            {
                val = default(T);
            }
            else
            {
                val = Queue[front];
                front = (front + 1) % Queue.Length;
                isFull = false;
            }

            return val;
        }
        public T GetFrontPiece()
        {
            // Returns the front element of the queue without deleting it from the queue
            return Queue[front];
        }

    }
}
