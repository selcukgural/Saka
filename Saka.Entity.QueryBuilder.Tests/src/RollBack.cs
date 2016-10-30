using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class RollBack
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void RollBack_Just()
        {
            builder.RollBack().EndQuery();
            Assert.AreEqual("ROLLBACK ;", builder.Query);
        }
    }
}