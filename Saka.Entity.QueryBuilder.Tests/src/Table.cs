using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Table
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Table_WithString()
        {
            builder.Table("Person").EndQuery();
            Assert.AreEqual("TABLE Person ;",builder.Query);
        }
        [TestMethod]
        public void Table_WithString_2()
        {
            builder.Table(true).EndQuery();
            Assert.AreEqual("TABLE Person ;", builder.Query);
        }
        [TestMethod]
        public void Table_Just()
        {
            builder.Table().EndQuery();
            Assert.AreEqual("TABLE ;", builder.Query);
        }
    }
}