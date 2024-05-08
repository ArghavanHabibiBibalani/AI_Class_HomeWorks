using DataStructures.LinkedLists.SinglyLinkedList;

namespace DataStructures.Queue.LinkedListeBasedQueue
{
    public class LinkedQueue<E> : IQueue<E>
    {
        private ISinglyLinkedList<E> list;

        public LinkedQueue()
        {
            list = new SinglyLinkedList<E>();
        }
        public E Dequeue()
        {
            return list.RemoveFirst();
        }

        public void Enqueue(E e)
        {
            list.AddLast(e);
        }

        public E First()
        {
            return list.First();
        }

        public bool IsEmpty()
        {
            return list.IsEmpty();
        }

        public int Size()
        {
            return list.Size;
        }
    }
}
