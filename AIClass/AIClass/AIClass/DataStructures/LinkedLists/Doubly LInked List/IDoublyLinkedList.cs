namespace DataStructures.LinkedLists.DoublyLinkedList
{
    public interface IDoublyLinkedList<E>
    {
        int Size { get; }
        bool IsEmpty();
        E FirstElement();
        E LastElement();
        void AddFirst(E e);
        void AddLast(E e);
        E RemoveFirst();
        E RemoveLast();
    }
}
