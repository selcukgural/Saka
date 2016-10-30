using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Drop
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Drop_Just()
        {
            builder.Drop().EndQuery();
            Assert.AreEqual("DROP ;",builder.Query);
        }

    }
}