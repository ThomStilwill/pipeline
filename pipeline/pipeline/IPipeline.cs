using System;

namespace pipeline.pipeline
{
    public interface IPipeline<TInput,TOutput>
    {
        IPipeline<TInput, TOutput> AddStep<TStepIn, TStepOut>(Func<TStepIn, TStepOut> stepFunc);
        TOutput Execute(TInput input);
    }
}
