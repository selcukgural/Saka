using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class As
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void WithString()
        {
            builder.As("Test").EndQuery();
            Assert.AreEqual("AS [Test] ;",builder.Query);
        }
        [TestMethod]
        public void JustAs()
        {
            builder.As().EndQuery();
            Assert.AreEqual("AS ;", builder.Query);
        }
    }
}