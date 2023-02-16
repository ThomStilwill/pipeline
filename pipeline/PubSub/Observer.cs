using System;

namespace pipeline.PubSub
{
    public class Observer : IObserver
    {
        public string Name { get; set; }
        public Observer(string name, ISubject subject)
        {
            Name = name;
            subject.RegisterObserver(this);
        }
        
        public void Update(string message)
        {
            Console.WriteLine(message);
        }
    }
}
