using NUnit.Framework;
using pipeline;

namespace Tests
{
    [TestFixture]
    public class PipelineTests
    {


        //https://michaelscodingspot.com/pipeline-pattern-implementations-csharp/



        [Test]
        public void TestInnerPipeline()
        {
            var main = new Main();
            main.StartInnerPipeline();
        }
    }
}
