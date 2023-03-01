using System;

namespace pipeline.PubSub
{
    public class Observer<T> : IObserver<T>
    {
        private readonly Action<T> _action;
        public string Name { get; set; }
        public Observer(string name, ISubject<T> subject, Action<T> action)
        {
            _action = action;
            Name = name;
            subject.RegisterObserver(this);
        }

        public void Update(T message)
        {
            _action.Invoke(message);
        }
    }
}
