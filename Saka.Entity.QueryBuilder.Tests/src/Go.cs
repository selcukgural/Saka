using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Go
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Go_Just()
        {
            builder.Go().EndQuery();
            Assert.AreEqual("GO ;", builder.Query);
        }
    }
}