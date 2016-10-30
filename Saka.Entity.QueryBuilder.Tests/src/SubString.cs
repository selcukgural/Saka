using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class SubString
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void WithString()
        {
            builder.SubString("Test",0,20).EndQuery();
            Assert.AreEqual("SUBSTRING ([Test],0,20) ;", builder.Query);
        }
        [TestMethod]
        public void WithString_Comma()
        {
            builder.SubString("Test", 0, 20,true).EndQuery();
            Assert.AreEqual(",SUBSTRING ([Test],0,20) ;", builder.Query);
        }
        [TestMethod]
        public void WithExpression()
        {
            builder.SubString(e=> e.LastName,2,3).EndQuery();
            Assert.AreEqual("SUBSTRING ([LastName],2,3) ;", builder.Query);
        }
        [TestMethod]
        public void WithExpression_Comma()
        {
            builder.SubString(e => e.LastName, 2, 3,true).EndQuery();
            Assert.AreEqual(",SUBSTRING ([LastName],2,3) ;", builder.Query);
        }
        [TestMethod]
        public void JustSubString()
        {
            builder.SubString().EndQuery();
            Assert.AreEqual("SUBSTRING ;", builder.Query);
        }
        [TestMethod]
        public void JustSubString_Comma()
        {
            builder.SubString(true).EndQuery();
            Assert.AreEqual(",SUBSTRING ;", builder.Query);
        }
    }
}