using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Case
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Case_WihtExpression()
        {
            builder.Case(e => e.Title).EndQuery();
            Assert.AreEqual("CASE [Title] ;", builder.Query);
        }
        [TestMethod]
        public void Case_WihtString()
        {
            builder.Case("FirstName").EndQuery();
            Assert.AreEqual("CASE [FirstName] ;", builder.Query);
        }
        [TestMethod]
        public void Case_Just()
        {
            builder.Case().EndQuery();
            Assert.AreEqual("CASE ;", builder.Query);
        }
    }
}