using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Like
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Like_WihtString()
        {
            builder.Like("se%").EndQuery();
            Assert.AreEqual("LIKE 'se%' ;",builder.Query);
        }
        [TestMethod]
        public void Like_Just()
        {
            builder.Like().EndQuery();
            Assert.AreEqual("LIKE ;", builder.Query);
        }
    }
}