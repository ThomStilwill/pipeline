using System.Collections.Generic;

namespace pipeline
{
    internal class Chain<TInput,TOutput> : IChain<TInput, TOutput>
    {
        private List<object> steps = new();

        public static Chain<TInput, TOutput> Create() => new Chain<TInput, TOutput>();

        public Chain<TInput, TOutput> Add<TChainStepIn,TChainStepOut>(IChainStep<TChainStepIn,TChainStepOut> step) where TChainStepIn: class
                                                                                                                   where TChainStepOut : class
        {
            steps.Add(step);
            return this;
        }

        public TOutput Execute(TInput inputData)
        {
            object stepInput = inputData;
            object stepOutput = null;

            foreach (var step in steps)
            {
                stepOutput = step.Execute(stepInput);
                stepInput = stepOutput;
            }

            return (TOutput)stepOutput;
        }
    }
}
