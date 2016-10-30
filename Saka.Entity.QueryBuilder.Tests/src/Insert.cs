using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Insert
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();
        [TestMethod]
        public void JustAs()
        {
            builder.Insert().EndQuery();
            Assert.AreEqual("INSERT ;", builder.Query);
        }
    }
}