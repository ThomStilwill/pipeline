using System.Diagnostics;
using System.Linq;

namespace pipeline
{
    public class Main
    {
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
