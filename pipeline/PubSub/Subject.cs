using System;
using System.Collections.Generic;

namespace pipeline.PubSub
{
    public class Subject<T> : ISubject<T>
    {
        private List<IObserver<T>> observers = new List<IObserver<T>>();
        private string Name { get; set; }
        public Subject(string name)
        {
            Name = name;
        }

        public void RegisterObserver(IObserver<T> observer)
        {
            Console.WriteLine("Observer Registered: " + observer.Name );
            observers.Add(observer);
        }

        public void AddObservers(IObserver<T> observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver<T> observer)
        {
            observers.Remove(observer);
        }

        public void SendMessage(T message)
        {
            NotifyObservers(message);
        }

        public void NotifyObservers(T message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }
    }
}
