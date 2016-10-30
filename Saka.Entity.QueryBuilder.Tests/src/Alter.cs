using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Alter
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Alter_Just()
        {
            builder.Alter().EndQuery();
            Assert.AreEqual("ALTER ;", builder.Query);
        }
    }
}