using DataStructures.LinkedLists.SinglyLinkedList;
using System.Collections.Generic;

namespace DataStructures.LinkedLists.DoublyLinkedList
{
    public class DoublyLinkedList<E> : IDoublyLinkedList<E>
    {
        private class DoublyNode<E>
        {
            private E element;
            private DoublyNode<E> prev;
            private DoublyNode<E> next;

            public DoublyNode(E e, DoublyNode<E> p, DoublyNode<E> n)
            {
                element = e;
                prev = p;
                next = n;
            }
            public E GetElement()
            {
                return element;
            }

            public DoublyNode<E> GetNext()
            {
                return next;
            }

            public DoublyNode<E> GetPrev()
            {
                return prev;
            }

            public void SetPrev(DoublyNode<E> p)
            {
                prev = p;
            }

            public void SetNext(DoublyNode<E> n)
            {
                next = n;
            }

            public void SetElement(E e)
            {
                element = e;
            }
        }

        private DoublyNode<E> header;
        private DoublyNode<E> trailer;
        private int size = 0;

        public DoublyLinkedList()
        {
            header = new DoublyNode<E>(default(E), null, null);
            trailer = new DoublyNode<E>(default(E), header, null);
            header.SetNext(trailer);
        }

        public int Size => size;

        public bool IsEmpty()
        {
            return size == 0;
        }

        public E FirstElement()
        {
            if (IsEmpty())
            {
                return default(E);
            }
            return header.GetNext().GetElement();
        }

        public E LastElement()
        {
            if (IsEmpty())
            {
                return default(E);
            }
            return trailer.GetPrev().GetElement();
        }

        public void AddFirst(E e)
        {
            AddBetween(e, header, header.GetNext());
        }

        public void AddLast(E e)
        {
            AddBetween(e, trailer.GetPrev(), trailer);
        }

        public E RemoveFirst()
        {
            if (IsEmpty())
            {
                return default(E);
            }
            return RemoveNode(header.GetNext());
        }

        public E RemoveLast()
        {
            if (IsEmpty())
            {
                return default(E);
            }
            return RemoveNode(trailer.GetPrev());
        }

        private void AddBetween(E e, DoublyNode<E> predecessor, DoublyNode<E> successor)
        {
            DoublyNode<E> newNode = new DoublyNode<E>(e, predecessor, successor);

            predecessor.SetNext(newNode);
            successor.SetPrev(newNode);

            size++;
        }

        private E RemoveNode(DoublyNode<E> node)
        {
            DoublyNode<E> predecessor = node.GetPrev();
            DoublyNode<E> successor = node.GetNext();

            predecessor.SetNext(successor);
            successor.SetPrev(predecessor);

            size--;

            return node.GetElement();
        }

        public override string ToString()
        {
            string output = "{ ";
            DoublyNode<E> current = header.GetNext();
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
