using pipeline.PubSub;
using System.Collections.Generic;
using pipeline.pipeline;

namespace pipeline.CvsImportSteps
{
    internal class LineConverter
    {
        private readonly ISubject<Message> _subject;

        public LineConverter(ISubject<Message> subject)
        {
            _subject = subject;
        }
        public IEnumerable<IEnumerable<string>> Execute(IEnumerable<string> dataIn)
        {
            _subject.NotifyObservers(new Message("Starting Line Converter"));
            var lines = new List<IEnumerable<string>>();

            var lineNumber = 0;
            foreach (var line in dataIn)
            {
                if (string.IsNullOrEmpty(line))
                {
                    _subject.NotifyObservers(new Message($"Line {lineNumber} is empty.",Message.OpSeverity.Failure));
                    lineNumber++;
                    continue;
                }

                var elements = line.Split(',');
                var elementNumber = 0;
                foreach (var element in elements)
                {   
                    if (string.IsNullOrEmpty(element))
                    {
                        _subject.NotifyObservers(new Message($"Line {lineNumber} Element {elementNumber} has no data.", Message.OpSeverity.Warning));
                    }    
                    elementNumber++;
                }
                

                lines.Add(elements);

                lineNumber++;
            }
            
            return lines;
        }
    }
}
