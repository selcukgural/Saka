using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Return
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Return_WihtInteger()
        {
            builder.Return(1).EndQuery();
            Assert.AreEqual("RETURN 1 ;", builder.Query);
        }
        [TestMethod]
        public void Return_Just()
        {
            builder.Return().EndQuery();
            Assert.AreEqual("RETURN ;", builder.Query);
        }
    }
}