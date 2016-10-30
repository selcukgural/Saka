using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Column
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Column_WihtExpression()
        {
            builder.Column(e => e.LastName).EndQuery();
            Assert.AreEqual("COLUMN [LastName] ;", builder.Query);
        }
        [TestMethod]
        public void Column_WithString()
        {
            builder.Column("Date").EndQuery();
            Assert.AreEqual("COLUMN [Date] ;", builder.Query);
        }
        [TestMethod]
        public void Column_Just()
        {
            builder.Column().EndQuery();
            Assert.AreEqual("COLUMN ;", builder.Query);
        }
    }
}