using System;

namespace pipeline.pipeline
{

    public abstract class NodeBase {
        public abstract Type InType { get; }
        public abstract Type OutType { get; }
    }

    public class Node<TNodeIn, TNodeOut>: NodeBase
    {
        public Node(Func<TNodeIn, TNodeOut> nodeFunction)
        {
            NodeFunction = BuildFunction<TNodeIn, TNodeOut>(nodeFunction);
        }

        public override Type InType => typeof(TNodeIn);
        public override Type OutType => typeof(TNodeOut);

        public  Func<object, object> NodeFunction { set; get; }

        public Func<object, object> BuildFunction<TNodeIn, TNodeOut>(Func<TNodeIn, TNodeOut> func)
        {
            return () => func();
        }

    }
    
}
