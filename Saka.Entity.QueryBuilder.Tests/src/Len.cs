using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Len
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void WithString()
        {
            builder.Len("Test").EndQuery();
            Assert.AreEqual("LEN ([Test]) ;",builder.Query);
        }
        [TestMethod]
        public void WithString_Comma()
        {
            builder.Len("Test",true).EndQuery();
            Assert.AreEqual(",LEN ([Test]) ;", builder.Query);
        }
        [TestMethod]
        public void WithExpression()
        {
            builder.Len(e=> e.BusinessEntityID).EndQuery();
            Assert.AreEqual("LEN ([BusinessEntityID]) ;", builder.Query);
        }
        [TestMethod]
        public void WithExpression_Comma()
        {
            builder.Len(e => e.BusinessEntityID, true).EndQuery();
            Assert.AreEqual(",LEN ([BusinessEntityID]) ;", builder.Query);
        }
        [TestMethod]
        public void JustLen()
        {
            builder.Len().EndQuery();
            Assert.AreEqual("LEN ;", builder.Query);
        }
        [TestMethod]
        public void JustLen_Comma()
        {
            builder.Len(true).EndQuery();
            Assert.AreEqual(",LEN ;", builder.Query);
        }
    }
}