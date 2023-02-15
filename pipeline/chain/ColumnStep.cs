using System.Collections.Generic;

namespace pipeline.chain
{
    internal class ColumnStep: IChainStep<IEnumerable<string>,IEnumerable<IEnumerable<string>>>
    {
        public IEnumerable<IEnumerable<string>> Execute(IEnumerable<string> dataIn)
        {
            var lines = new List<IEnumerable<string>>();

            foreach (var line in dataIn)
            {
                lines.Add(line.Split(','));
            }
            
            return lines;
        }
    }
}
