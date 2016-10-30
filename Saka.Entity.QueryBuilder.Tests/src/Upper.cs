using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Upper
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void WithString()
        {
            builder.Upper("Test").EndQuery();
            Assert.AreEqual("UPPER ([Test]) ;",builder.Query);
        }
        [TestMethod]
        public void WithString_Comma()
        {
            builder.Upper("Test",true).EndQuery();
            Assert.AreEqual(",UPPER ([Test]) ;", builder.Query);
        }
        [TestMethod]
        public void WithExpression()
        {
            builder.Upper(e=> e.ModifiedDate).EndQuery();
            Assert.AreEqual("UPPER ([ModifiedDate]) ;", builder.Query);
        }
        [TestMethod]
        public void WithExpression_Comma()
        {
            builder.Upper(e => e.ModifiedDate,true).EndQuery();
            Assert.AreEqual(",UPPER ([ModifiedDate]) ;", builder.Query);
        }
        [TestMethod]
        public void JustUpper()
        {
            builder.Upper().EndQuery();
            Assert.AreEqual("UPPER ;", builder.Query);
        }
        [TestMethod]
        public void JustUpper_Comma()
        {
            builder.Upper(true).EndQuery();
            Assert.AreEqual(",UPPER ;", builder.Query);
        }
    }
}