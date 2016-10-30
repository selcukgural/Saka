using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{

    [TestClass]
    public class Into
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Into_With_String()
        {
            builder.Into("Person").EndQuery();
            Assert.AreEqual("INTO Person ;", builder.Query);
        }

        [TestMethod]
        public void Into_Just()
        {
            builder.Into().EndQuery();
            Assert.AreEqual("INTO ;", builder.Query);
        }
        [TestMethod]
        public void Into_GenericTableName()
        {
            builder.Into(true).EndQuery();
            Assert.AreEqual("INTO Person ;", builder.Query);
        }
    }
}
