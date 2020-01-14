using System;

namespace pipeline
{
    public interface IPipeline
    {
        void Execute(object input);
        event Action<object> Finished;
    }
}
