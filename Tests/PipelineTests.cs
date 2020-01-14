using NUnit.Framework;
using pipeline;

namespace Tests
{
    [TestFixture]
    public class PipelineTests
    {
        [Test]
        public void TestCastingPipeline()
        {
            var main = new Main();
            main.StartCastingPipeline();
        }

        [Test]
        public void TestInnerPipeline()
        {
            var main = new Main();
            main.StartInnerPipeline();
        }
    }
}
