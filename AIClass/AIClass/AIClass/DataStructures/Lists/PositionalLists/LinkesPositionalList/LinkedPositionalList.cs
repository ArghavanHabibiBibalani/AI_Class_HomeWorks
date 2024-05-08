using DataStructures.Lists.PositionalLists;
using DataStructures.LinkedLists.DoublyLinkedList;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace DataStructures.Lists.PositionalLists.LinkesPositionalList
{
    public class LinkedPositionalList<E> : IPositionalList<E>
    {

        private class PositionalListNode<E>: IPosition<E>
        {
            private E element;
            private PositionalListNode<E> prev;
            private PositionalListNode<E> next;

            public PositionalListNode(E e, PositionalListNode<E> p, PositionalListNode<E> n)
            {
                element = e;
                prev = p;
                next = n;
            }
            public E GetElement()
            {
                if(next == null)
                {
                    throw new InvalidOperationException("Position is not valid!");
                }

                return element;
            }

            public PositionalListNode<E> GetNext()
            {
                return next;
            }

            public PositionalListNode<E> GetPrev()
            {
                return prev;
            }

            public void SetPrev(PositionalListNode<E> p)
            {
                prev = p;
            }

            public void SetNext(PositionalListNode<E> n)
            {
                next = n;
            }

            public void SetElement(E e)
            {
                element = e;
            }

        }

        private PositionalListNode<E> header;
        private PositionalListNode<E> trailer;
        private int size = 0;

        public LinkedPositionalList()
        {
            header = new PositionalListNode<E>(default(E), null, null);
            trailer = new PositionalListNode<E>(default(E), header, null);

            header.SetNext(trailer);
        }

        public IPosition<E> AddAfter(IPosition<E> position, E element)
        {
            PositionalListNode<E> node = Validate(position);

            return AddBetween(element, node, node.GetNext());
        }

        public IPosition<E> AddBefore(IPosition<E> position, E element)
        {
            PositionalListNode<E> node = Validate(position);

            return AddBetween(element, node.GetPrev(), node);
        }

        public IPosition<E> AddFirst(E element)
        {
            return AddBetween(element, header, header.GetNext());
        }

        public IPosition<E> AddLast(E element)
        {
            return AddBetween(element, trailer.GetPrev(), trailer);
        }

        public IPosition<E> After(IPosition<E> position)
        {
            PositionalListNode<E> node = Validate(position);
            return Position(node.GetNext());
        }

        public IPosition<E> Befor(IPosition<E> position)
        {
            PositionalListNode<E> node = Validate(position);
            return Position(node.GetPrev());
        }

        public IPosition<E> First()
        {
            return Position(header.GetNext());
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public IPosition<E> Last()
        {
            return Position(trailer.GetPrev());
        }

        public E Remove(IPosition<E> position)
        {
            PositionalListNode<E> node = Validate(position);
            PositionalListNode<E> predecessor = node.GetPrev();
            PositionalListNode<E> successor = node.GetNext();

            predecessor.SetNext(successor);
            successor.SetPrev(predecessor);

            size--;

            E answer = node.GetElement();
            node.SetElement(default(E));
            node.SetNext(null);
            node.SetPrev(null);

            return answer;
        }

        public E Set(IPosition<E> position, E element)
        {
            PositionalListNode<E> node = Validate(position);

            E answer = node.GetElement();
            node.SetElement(element);

            return answer;
        }

        public int Size()
        {
            return size;
        }

        private PositionalListNode<E> Validate(IPosition<E> position)
        {
            if(!(position is PositionalListNode<E>))
            {
                throw new ArgumentException("Invalid position!");
            }

            PositionalListNode<E> node = (PositionalListNode<E>)position;

            if(node.GetNext() == null)
            {
                throw new ArgumentException("Position is no longer in the list!");
            }
            return node;
        }

        private IPosition<E> Position(PositionalListNode<E> node)
        {
            if(node == header || node == trailer)
            {
                return null;
            }

            return node;
        }

        private IPosition<E> AddBetween(E e, PositionalListNode<E> pred, PositionalListNode<E> succ)
        {
            PositionalListNode<E> newNode = new PositionalListNode<E>(e, pred, succ);
            pred.SetNext(newNode);
            succ.SetPrev(newNode);
            size++;
            return newNode;
        }

    }
}
