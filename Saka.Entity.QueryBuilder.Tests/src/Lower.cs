using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Lower
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void WithString()
        {
            builder.Lower("Test").EndQuery();
            Assert.AreEqual("LOWER ([Test]) ;",builder.Query);
        }
        [TestMethod]
        public void WithString_Comma()
        {
            builder.Lower("Test",true).EndQuery();
            Assert.AreEqual(",LOWER ([Test]) ;", builder.Query);
        }
        [TestMethod]
        public void WithExpression()
        {
            builder.Lower(e=> e.BusinessEntityID).EndQuery();
            Assert.AreEqual("LOWER ([BusinessEntityID]) ;", builder.Query);
        }
        [TestMethod]
        public void WithExpression_Comma()
        {
            builder.Lower(e => e.BusinessEntityID,true).EndQuery();
            Assert.AreEqual(",LOWER ([BusinessEntityID]) ;", builder.Query);
        }
        [TestMethod]
        public void JustLower()
        {
            builder.Lower().EndQuery();
            Assert.AreEqual("LOWER ;", builder.Query);
        }
        [TestMethod]
        public void JustLower_Comma()
        {
            builder.Lower(true).EndQuery();
            Assert.AreEqual(",LOWER ;", builder.Query);
        }
    }
}