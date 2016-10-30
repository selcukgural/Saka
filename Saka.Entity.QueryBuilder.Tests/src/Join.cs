using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Join
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Join_WihtGenericType()
        {
            builder.Join<Product>().EndQuery();
            Assert.AreEqual("JOIN Product ;", builder.Query);
        }
        [TestMethod]
        public void Join_WihtString()
        {
            builder.Join("Employee").EndQuery();
            Assert.AreEqual("JOIN Employee ;", builder.Query);
        }

        [TestMethod]
        public void Join_Just()
        {
            builder.Join().EndQuery();
            Assert.AreEqual("JOIN ;", builder.Query);
        }
    }
}