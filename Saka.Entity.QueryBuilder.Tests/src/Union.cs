using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Uninon
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Union_Just()
        {
            builder.Union().EndQuery();
            Assert.AreEqual("UNION ;",builder.Query);
        }
        [TestMethod]
        public void Union_All()
        {
            builder.Union(true).EndQuery();
            Assert.AreEqual("UNION ALL ;", builder.Query);
        }
    }
}