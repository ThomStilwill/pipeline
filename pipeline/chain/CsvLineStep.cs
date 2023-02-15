using System.Collections.Generic;

namespace pipeline.chain
{
    internal class CsvLineStep: IChainStep<string,IEnumerable<string>>
    {

        public IEnumerable<string> Execute(string dataIn)
        {
            return dataIn.Split('\n');
        }
        
    }
}
