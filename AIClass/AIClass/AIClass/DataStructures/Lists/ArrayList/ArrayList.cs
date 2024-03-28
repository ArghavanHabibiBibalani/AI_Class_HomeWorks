using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists.ArrayList
{
    internal class ArrayList<E> : IList<E>
    {
        private static int CAPACITY = 16;
        private E[] data;
        private int size = 0;

        public ArrayList()
        {
            data = new E[CAPACITY];
        }
        public ArrayList(int capacity)
        {
            data = new E[capacity];
        }
        public void Add(int index, E value)
        { 
            CheckIndex(index, size + 1);

            if (Size() == data.Length)
            {
                throw new InvalidOperationException("Array is full!");
            }

            for (int i = size - 1; i >= index; i--)
            {
                data[i + 1] = data[i];
            }

            data[index] = value;
            size++;
        }

        public E Get(int index)
        {
            CheckIndex(index, size);

            return data[index];
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public E Remove(int index)
        {
            CheckIndex(index, size);

            E temp = data[index];

            for(int i = index; i < size - 1; i++)
            {
                data[i] = data[i + 1];
            }
            data[size - 1] = default(E);
            size--;

            return temp;
        }

        public E Set(int index, E value)
        {
            CheckIndex(index, size);

            E temp = data[index];
            data[index] = value;

            return temp;
        }

        public int Size()
        {
            return size;
        }

        private void CheckIndex(int index, int range)
        {
            if(index < 0 || index >= range)
            {
                throw new IndexOutOfRangeException("Illigal Index: " + index);
            }
        }
    }
}
