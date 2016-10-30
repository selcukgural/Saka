using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Output
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Output_Just()
        {
            builder.Output().EndQuery();
            Assert.AreEqual("OUTPUT ;", builder.Query);
        }
    }
}