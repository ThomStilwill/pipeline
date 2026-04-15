using System;
using System.Collections.Generic;

namespace pipeline.pipeline
{

    public interface IGraph<TInput, TOutput>
    {
        IGraph<TInput, TOutput> AddStep<TStepIn, TStepOut>(Func<TStepIn, TStepOut> stepFunc);
        TOutput Execute(TInput input);
    }

    public class Graph<TInput, TOutput> : IGraph<TInput, TOutput>
    {
        //private readonly List<Func<object, object>> _nodes = new List<Func<object, object>>();
        private readonly List<NodeBase> _nodes = new List<NodeBase>();


        public static IGraph<TInput, TOutput> Create() => new Graph<TInput, TOutput>();

        public IGraph<TInput, TOutput> AddStep<TStepIn, TStepOut>(Func<TStepIn, TStepOut> stepFunc)
        {
            var node = new Node<TStepIn, TStepOut>(stepFunc);

            //_nodes.Add(input => node.NodeFunction.Invoke((TStepIn)input));
            _nodes.Add(node);


            return this;
        }

        public TOutput Execute(TInput input)
        {
            object stepInput = input;
            object stepOutput = null;
            foreach (var node in _nodes)
            {
                stepOutput = node.Invoke(stepInput);
                stepInput = stepOutput;
            }

            return (TOutput) stepOutput;
        }
    }
}
