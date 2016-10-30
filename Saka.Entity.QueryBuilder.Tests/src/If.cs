using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class If
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void If_WihtExpression()
        {
            builder.If(e => e.BusinessEntityID > 120).EndQuery();
            Assert.AreEqual("IF [BusinessEntityID] > 120 ;", builder.Query);
        }

        [TestMethod]
        public void If_WithString()
        {
            builder.If("State = 0").EndQuery();
            Assert.AreEqual("IF State = 0 ;", builder.Query);
        }
        [TestMethod]
        public void If_Just()
        {
            builder.If().EndQuery();
            Assert.AreEqual("IF ;", builder.Query);
        }
    }
}