using System.Collections.Generic;
using pipeline.pipeline;
using pipeline.PubSub;

namespace pipeline.CvsImportSteps
{
    internal class StringToLines
    {
        private readonly ISubject<Message> _subject;

        public StringToLines(ISubject<Message> subject)
        {
            _subject = subject;
        }
        public IEnumerable<string> Execute(string dataIn)
        {
            var lines =  ((string)dataIn).Split('\n');
            _subject.NotifyObservers(new Message($"Generating {lines.Length} lines from CSV text."));
            return lines;
        }
    }
}
