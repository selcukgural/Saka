using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Transaction
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Transaction_Just()
        {
            builder.Transaction().EndQuery();
            Assert.AreEqual("TRANSACTION ;", builder.Query);
        }
    }
}