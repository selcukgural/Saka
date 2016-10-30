using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Truncate
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Truncate_Just()
        {
            builder.Truncate().EndQuery();
            Assert.AreEqual("TRUNCATE ;",builder.Query);
        }
    }
}