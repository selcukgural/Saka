using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Else
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Else_WihtExpression()
        {
            builder.Else(e=> e.BusinessEntityID).EndQuery();
            Assert.AreEqual("ELSE 'BusinessEntityID' ;", builder.Query);
        }
        [TestMethod]
        public void Else_WihtObject()
        {
            builder.Else(34).EndQuery();
            Assert.AreEqual("ELSE 34 ;", builder.Query);
        }

        [TestMethod]
        public void Else_Just()
        {
            builder.Else().EndQuery();
            Assert.AreEqual("ELSE ;", builder.Query);
        }
    }
}