using System;

namespace pipeline
{
    interface IChainStep<TChainStepIn, TChainStepOut> where TChainStepIn : class 
                                                      where TChainStepOut: class
    {
        TChainStepOut Execute(TChainStepIn dataIn);
    }
}
