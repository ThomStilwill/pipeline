namespace pipeline.pipeline
{
    public interface IHandler<TInput, TOutput>
    {
        public TOutput Execute(TInput input);
    }
}
