using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stacks.ArrayBasedStack
{
    internal class ArrayStack<E> : IStack<E>
    {
        private int CAPACITY = 1000;
        private E[] data;
        private int indexOfTopElement = -1;

        public ArrayStack()
        {
            data = new E[CAPACITY];
        }

        public ArrayStack(int cap)
        {
            data = new E[cap];
        }

        public bool IsEmpty()
        {
            return (indexOfTopElement == -1);
        }

        public E Pop()
        {
            if (IsEmpty())
            {
                return default(E);
            }
            E answer = data[indexOfTopElement];
            data[indexOfTopElement] = default(E);
            indexOfTopElement--;
            return answer;
        }

        public void Push(E e) 
        {
            if (Size() == data.Length)
            {
                throw new InvalidOperationException("Stack is full!");
            }

            data[++indexOfTopElement] = e;
        }

        public int Size()
        {
            return (indexOfTopElement + 1);
        }

        public E Top()
        {
            if (IsEmpty())
            {
                return default(E);
            }

            return data[indexOfTopElement];
        }
    }
}
