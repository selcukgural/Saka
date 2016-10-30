using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{

    [TestClass]
    public class Now
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();
        [TestMethod]
        public void JustFormat_Comma()
        {
            builder.Now(true).EndQuery();
            Assert.AreEqual(",NOW() ;", builder.Query);
        }
        [TestMethod]
        public void JustFormat()
        {
            builder.Now(false).EndQuery();
            Assert.AreEqual("NOW() ;", builder.Query);
        }
    }
}
