using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedLists.SinglyLinkedList
{
    public class SinglyLinkedList<E> : ISinglyLinkedList<E>
    {
        private class SinglyNode<E>
        {
            private E element;
            private SinglyNode<E> next;

            public SinglyNode(E e, SinglyNode<E> n)
            {
                element = e;
                next = n;
            }
            public E GetElement()
            {
                return element;
            }

            public SinglyNode<E> GetNext()
            {
                return next;
            }

            public void SetNext(SinglyNode<E> n)
            {
                next = n;
            }
        }

        private SinglyNode<E> head = null;
        private SinglyNode<E> tail;
        private int size = 0;

        public SinglyLinkedList()
        {
            head = new SinglyNode<E>(default(E), null);
            tail = new SinglyNode<E>(default(E), null);
            head.SetNext(tail);
        }
        public int Size => size;

        public bool IsEmpty()
        {
            return size == 0;
        }

        public E First()
        {
            if (IsEmpty())
            {
                return default(E);
            }
            return head.GetElement();
        }
        
        public E Last()
        {
            if (IsEmpty())
            {
                return default(E);
            }
            return tail.GetElement();
        }

        public void AddFirst(E e)
        {
            head = new SinglyNode<E>(e, head);

            if(size == 0)
            {
                tail = head;
            }
            size++;
        }

        public void AddLast(E e)
        {
            SinglyNode<E> newNode = new SinglyNode<E>(e, null);
            if (IsEmpty())
            {
                head = newNode;
            }
            else
            {
                tail.SetNext(newNode);
            }
            tail = newNode;
            size++;
        }

        public E RemoveFirst()
        {
            if (IsEmpty())
            {
                return default(E);
            }

            SinglyNode<E> final = head.GetNext();

            head = head.GetNext();
            size--;
            if (size == 0)
            {
                tail = null;
            }

            return final.GetElement();
        }

        public override string ToString()
        {
            string output = "{ ";
            SinglyNode<E> current = head.GetNext();
            for (int i = 0; i < size; i++)
            {
                output += current.GetElement().ToString();
                if (i != size - 1)
                {
                    output += ", ";
                }
                current = current.GetNext();
            }
            output += " }";
            return output;
        }

    }
}
