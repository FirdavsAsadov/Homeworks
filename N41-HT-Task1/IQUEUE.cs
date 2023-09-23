namespace N41_HT_Task1
{
    public interface IQUEUE<T>
    {
        void Enqueue(T item);
        T Dequeue();
    }
}