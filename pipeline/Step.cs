using System;

namespace pipeline
{
    public class Step<TStepIn, TStepOut>
    {
        public Step(Func<TStepIn, TStepOut> stepFunction)
        {
            StepFunction = stepFunction;
        }

        public Func<TStepIn, TStepOut> StepFunction { set; get; }
    }
}
