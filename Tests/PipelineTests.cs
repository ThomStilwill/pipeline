using NUnit.Framework;
using pipeline;

namespace Tests
{
    [TestFixture]
    public class PipelineTests
    {
        [Test]
        public void TestChain()
        {
            var main = new Main();
            var result = main.CsvValidationChain();
            Assert.IsNotNull(result);
        }


        [Test]
        public void TestInnerPipeline()
        {
            var main = new Main();
            main.StartInnerPipeline();
        }
    }
}
