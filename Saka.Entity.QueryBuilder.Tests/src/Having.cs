using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Having
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void JustHaving()
        {
            builder.Having().EndQuery();
            Assert.AreEqual("HAVING ;",builder.Query);
        }
    }
}