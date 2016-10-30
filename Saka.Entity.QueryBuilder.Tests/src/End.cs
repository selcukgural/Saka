using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class End
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void End_Just()
        {
            builder.End().EndQuery();
            Assert.AreEqual("END ;", builder.Query);
        }
    }
}