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
            var importSubject = new Subject("import operation");
            var observer = new Observer("import", importSubject);

            var stringToLines = new StringToLines(importSubject);
            var lineConverter = new LineConverter(importSubject);

            var csvData = "James,Kirk,jim.kirk@gmail.com\r\nLeonard,McCoy,leonard.mccoy@gmail.com";

            importSubject.NotifyObservers("create pipeline");
            var chain = Pipeline<string,IEnumerable<object>>
                .Create()       
                .AddStep<string, IEnumerable<string>>(x => stringToLines.Execute(x))
                .AddStep<IEnumerable<string>, IEnumerable<IEnumerable<string>>>(x => lineConverter.Execute(x));

            importSubject.NotifyObservers("execute pipeline");
            var result = chain.Execute(csvData);
            importSubject.NotifyObservers("complete pipeline");
            return result;
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
