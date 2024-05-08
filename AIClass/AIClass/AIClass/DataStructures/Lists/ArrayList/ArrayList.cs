using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists.ArrayList
{
    public class ArrayList<E> : IList<E> where E : IComparable<E>
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
        public void CountingSortDescending()
        {
            if (size == 0)
                return;
            E min = data[0];
            E max = data[0];
            Func<E, E, int> comparer = Comparer<E>.Default.Compare;

            foreach (E item in data)
            {
                if (comparer(item, min) < 0)
                    min = item;
                if (comparer(item, max) > 0)
                    max = item;
            }

            List<KeyValuePair<E, int>> countList = new List<KeyValuePair<E, int>>();

            foreach (E item in data)
            {
                bool found = false;
                for (int i = 0; i < countList.Count; i++)
                {
                    if (EqualityComparer<E>.Default.Equals(item, countList[i].Key))
                    {
                        countList[i] = new KeyValuePair<E, int>(countList[i].Key, countList[i].Value + 1);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    countList.Add(new KeyValuePair<E, int>(item, 1));
                }
            }

            List<E> sorted = new List<E>(size);

            for (int i = countList.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < countList[i].Value; j++)
                {
                    sorted.Add(countList[i].Key);
                }
            }

            for (int i = 0; i < size; i++)
            {
                data[i] = sorted[i];
            }
        }


        public void CountingSortAscending()
        {
            if (size == 0)
                return;

            E min = data[0];
            E max = data[0];
            Func<E, E, int> comparer = Comparer<E>.Default.Compare;

            for (int i = 1; i < size; i++)
            {
                if (comparer(data[i], min) < 0)
                    min = data[i];
                if (comparer(data[i], max) > 0)
                    max = data[i];
            }

            int range = Convert.ToInt32(max) - Convert.ToInt32(min) + 1;
            int[] count = new int[range];

            for (int i = 0; i < size; i++)
            {
                int index = Convert.ToInt32(data[i]) - Convert.ToInt32(min);
                count[index]++;
            }

            for (int i = 1; i < range; i++)
            {
                count[i] += count[i - 1];
            }

            E[] temp = new E[size];

            for (int i = size - 1; i >= 0; i--)
            {
                int index = Convert.ToInt32(data[i]) - Convert.ToInt32(min);
                temp[count[index] - 1] = data[i];
                count[index]--;
            }

            for (int i = 0; i < size; i++)
            {
                data[i] = temp[i];
            }
        }



    }
}
