using System;
using System.Collections.Generic;

namespace pipeline
{
    public class Pipeline<TInput, TOutput> : IPipeline<TInput, TOutput>
    {
        List<Func<object, object>> _pipelineSteps = new List<Func<object, object>>();

        public static IPipeline<TInput, TOutput> Create() => new Pipeline<TInput, TOutput>();

        public IPipeline<TInput, TOutput> AddStep<TStepIn, TStepOut>(Func<TStepIn, TStepOut> stepFunc)
        {
            var step = new Step<TStepIn, TStepOut>(stepFunc);

            _pipelineSteps.Add(input => step.StepFunction.Invoke((TStepIn)input));
            return this;
        }

        public TOutput Execute(TInput input)
        {
            object stepInput = input;
            object stepOutput = null;
            foreach (var pipelineStep in _pipelineSteps)
            {
                stepOutput = pipelineStep.Invoke(stepInput);
                stepInput = stepOutput;
            }

            return (TOutput) stepOutput;
        }
    }
}
