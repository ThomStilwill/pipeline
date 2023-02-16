namespace pipeline.PubSub
{
    public interface IObserver
    {
        void Update(string message);
    }
}
