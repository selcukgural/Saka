using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class OrderBy
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();
        [TestMethod]
        public void WithExpression()
        {
            builder.OrderBy(e=> e.LastName,false).EndQuery();
            Assert.AreEqual("ORDER BY [LastName] DESC ;", builder.Query);
        }
        [TestMethod]
        public void WithString()
        {
            builder.OrderBy("[FirstName]").EndQuery();
            Assert.AreEqual("ORDER BY [FirstName] ASC ;",builder.Query);
        }
        [TestMethod]
        public void JustAs()
        {
            builder.OrderBy().EndQuery();
            Assert.AreEqual("ORDER BY ;", builder.Query);
        }
    }
}