using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Begin
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Begin_Just()
        {
            builder.Begin().EndQuery();
            Assert.AreEqual("BEGIN ;", builder.Query);
        }
    }
}