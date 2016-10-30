using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Delete
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Delete_Just()
        {
            builder.Delete().EndQuery();
            Assert.AreEqual("DELETE ;", builder.Query);
        }
    }
}