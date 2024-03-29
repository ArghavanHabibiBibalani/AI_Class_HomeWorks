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
        public void QuickSortAscending()
        {
            QuickSortAscending(0, size - 1);
        }
        private void QuickSortAscending(int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = PartitionAscending(low, high);
                QuickSortAscending(low, partitionIndex - 1);
                QuickSortAscending(partitionIndex + 1, high);
            }
        }
        private int PartitionAscending(int low, int high)
        {
            E pivot = data[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (Comparer<E>.Default.Compare(data[j], pivot) <= 0)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, high);
            return i + 1;
        }
        public void QuickSortDescending()
        {
            QuickSortDescending(0, size - 1);
        }
        private void QuickSortDescending(int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = PartitionDescending(low, high);
                QuickSortDescending(low, partitionIndex - 1);
                QuickSortDescending(partitionIndex + 1, high);
            }
        }
        private int PartitionDescending(int low, int high)
        {
            E pivot = data[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (Comparer<E>.Default.Compare(data[j], pivot) >= 0)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, high);
            return i + 1;
        }
        private void Swap(int i, int j)
        {
            E temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }
}
