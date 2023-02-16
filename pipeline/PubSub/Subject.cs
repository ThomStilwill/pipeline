using System;
using System.Collections.Generic;

namespace pipeline.PubSub
{
    public class Subject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private string Name { get; set; }
        public Subject(string name)
        {
            Name = name;

        }

        public void SendMessage(string message)
        {
            NotifyObservers(message);
        }
        public void RegisterObserver(IObserver observer)
        {
            Console.WriteLine("Observer Added : " + ((Observer)observer).Name );
            observers.Add(observer);
        }
        public void AddObservers(IObserver observer)
        {
            observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
        public void NotifyObservers(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }
    }
}
