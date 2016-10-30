using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Not
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Not_Just()
        {
            builder.Not().EndQuery();
            Assert.AreEqual("NOT ;",builder.Query);
        }

    }
}