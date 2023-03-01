using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using pipeline.CvsImportSteps;
using pipeline.pipeline;
using pipeline.PubSub;

namespace pipeline
{
    public class Main
    {
        public IEnumerable<object> CsvValidationChain()
        {
            var importSubject = new Subject<Message>("import operation");
            var observer = new Observer<Message>("import", importSubject, ObserverAction);

            var stringToLines = new StringToLines(importSubject);
            var lineConverter = new LineConverter(importSubject);

            var csvData = "James,Kirk,jim.kirk@gmail.com\n,X,\nLeonard,McCoy,leonard.mccoy@gmail.com\n\n";

            importSubject.NotifyObservers(new Message("create pipeline"));

            var chain = Pipeline<string,IEnumerable<object>>
                .Create()       
                .AddStep<string, IEnumerable<string>>(x => stringToLines.Execute(x))
                .AddStep<IEnumerable<string>, IEnumerable<IEnumerable<string>>>(x => lineConverter.Execute(x));

            importSubject.NotifyObservers(new Message("execute pipeline"));
            
            var result = chain.Execute(csvData);

            importSubject.NotifyObservers(new Message("complete pipeline"));

            return result;
        }

        void ObserverAction(Message message)
        {
            var severity = message.Severity.ToString().PadRight(7, ' ');
            Console.WriteLine($"{severity} : {message.Description}");
        }
        
        public void StartInnerPipeline()
        {
            var pipeline = Pipeline<string,bool>
                .Create()
                .AddStep<string, string>(input => FindMostCommon(input))
                .AddStep<string, int>(input => CountChars(input))
                .AddStep<int, bool>(input => IsOdd(input));
            
            var result = pipeline.Execute("The pipeline pattern is the best pattern");

            Debug.WriteLine(result);
        }

        private static string FindMostCommon(string input)
        {
            return input.Split(' ')
                .GroupBy(word => word)
                .OrderBy(group => group.Count())
                .Last()
                .Key;
        }

        private static int CountChars(string mostCommon)
        {
            return mostCommon.Length;
        }

        private static bool IsOdd(int number)
        {
            var res = number % 2 == 1;
            return res;
        }
    }
}
