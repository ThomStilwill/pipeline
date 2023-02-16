using pipeline.PubSub;
using System.Collections.Generic;

namespace pipeline.CvsImportSteps
{
    internal class LineConverter
    {
        private readonly ISubject _subject;

        public LineConverter(ISubject subject)
        {
            _subject = subject;
        }
        public IEnumerable<IEnumerable<string>> Execute(IEnumerable<string> dataIn)
        {

            _subject.NotifyObservers("Line Converter");
            var lines = new List<IEnumerable<string>>();

            foreach (var line in dataIn)
            {
                lines.Add(line.Split(','));
            }
            
            return lines;
        }
    }
}
