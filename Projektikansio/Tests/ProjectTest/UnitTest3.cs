using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Assert = Xunit.Assert; // Tarkentaa, että käytetään XUnit Assertia

namespace ProjectTest
{
    [TestClass]
    public class FuckYouTest : TestContext
    {
        public override IDictionary Properties => throw new NotImplementedException();

        public override void AddResultFile(string fileName)
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void TestMethod1()
        {
            bool result = true;
            Assert.True(result);
        }

        public override void Write(string? message)
        {
            throw new NotImplementedException();
        }

        public override void Write(string format, params object?[] args)
        {
            throw new NotImplementedException();
        }

        public override void WriteLine(string? message)
        {
            throw new NotImplementedException();
        }

        public override void WriteLine(string format, params object?[] args)
        {
            throw new NotImplementedException();
        }
    }
}
