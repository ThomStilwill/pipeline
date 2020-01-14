using System.Diagnostics;
using System.Linq;

namespace pipeline
{
    public class Main
    {
        public void StartCastingPipeline()
        {
            var builder = new CastingPipelineBuilder();

            builder.AddStep(input => FindMostCommon(input as string));
            builder.AddStep(input => (input as string).Length);
            builder.AddStep(input => ((int) input) % 2 == 1);

            var pipeline = builder.GetPipeline();

            pipeline.Finished += res => Debug.WriteLine(res);
            pipeline.Execute("The pipeline pattern is the best pattern");
        }

        public void StartInnerPipeline()
        {
            var builder = new InnerPipelineBuilder();
            builder.AddStep<string, string>(input => FindMostCommon(input));
            builder.AddStep<string, int>(input => CountChars(input));
            builder.AddStep<int, bool>(input => IsOdd(input));
            var pipeline = builder.GetPipeline();

            pipeline.Finished += res => Debug.WriteLine(res);
            pipeline.Execute("The pipeline pattern is the best pattern");
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
