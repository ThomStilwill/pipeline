using System;
using System.Linq;
using pipeline.pipeline;

namespace pipeline.StepClasses
{
    public class ActionOneHandler: IHandler<string, string>
    {
        public string Execute(string input)
        {
            Console.WriteLine("ActionOneHandler: " + input);
            var result = new string(input.ToCharArray().Reverse().ToArray());
            Console.WriteLine("ActionOneHandler after: " + result);
            return result;
        }
    }
}
