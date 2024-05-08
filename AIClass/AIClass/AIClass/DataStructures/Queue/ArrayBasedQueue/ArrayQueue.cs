using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue.ArrayBasedQueue
{
    public class ArrayQueue<E> : IQueue<E>
    {
        private E[] data;
        private int size = 0;
        private int indexOfFrontElement = 0;
        private int CAPACITY = 1000;

        public ArrayQueue()
        {
            data = new E[CAPACITY];
        }
        public ArrayQueue(int capacity)
        {
            data = new E[capacity];
        }
        public E Dequeue()
        {
            if (IsEmpty())
            {
                return default(E);
            }
            E answer = data[indexOfFrontElement];
            data[indexOfFrontElement] = default(E);

            indexOfFrontElement = (indexOfFrontElement + 1) % data.Length;
            size--;
            return answer;
        }

        public void Enqueue(E e)
        {
            if (Size() == data.Length)
            {
                throw new InvalidOperationException("Queue is full!");
            }

            int available = (indexOfFrontElement + size) % data.Length;

            data[available] = e;
            size++;
        }

        public E First()
        {
            if (IsEmpty())
            {
                return default(E);
            }
            return data[indexOfFrontElement];
        }

        public bool IsEmpty()
        {
            return (size == 0);
        }

        public int Size()
        {
            return size;
        }

        public E Get(int index)
        {
            return data[index];
        }
    }
}
