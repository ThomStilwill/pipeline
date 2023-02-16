using System.Collections.Generic;
using pipeline.PubSub;

namespace pipeline.CvsImportSteps
{
    internal class StringToLines
    {
        private readonly ISubject _subject;

        public StringToLines(ISubject subject)
        {
            _subject = subject;
        }
        public IEnumerable<string> Execute(string dataIn)
        {
            var lines =  ((string)dataIn).Split('\n');
            _subject.NotifyObservers($"break csv string into {lines.Length} lines");
            return lines;
        }
    }
}
