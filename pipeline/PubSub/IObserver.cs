namespace pipeline.PubSub
{
    public interface IObserver<in T>
    {
        string Name { get; }
        void Update(T message);
    }
}
