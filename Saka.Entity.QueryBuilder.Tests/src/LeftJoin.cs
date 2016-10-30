using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class LeftJoin
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void LeftJoin_WihtGenericType()
        {
            builder.LeftJoin<Product>().EndQuery();
            Assert.AreEqual("LEFT JOIN Product ;", builder.Query);
        }
        [TestMethod]
        public void LeftJoin_WihtString()
        {
            builder.LeftJoin("Employee").EndQuery();
            Assert.AreEqual("LEFT JOIN Employee ;", builder.Query);
        }

        [TestMethod]
        public void LeftJoin_Just()
        {
            builder.LeftJoin().EndQuery();
            Assert.AreEqual("LEFT JOIN ;", builder.Query);
        }
    }
}