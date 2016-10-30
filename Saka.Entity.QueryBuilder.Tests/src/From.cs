using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class From
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void WithTableName()
        {
            builder.From("Test").EndQuery();
            Assert.AreEqual("FROM Test;",builder.Query);
            builder.Clear();

            builder.From().EndQuery();
            Assert.AreEqual("FROM Person;", builder.Query);

        }
        [TestMethod]
        public void WithOutTableName()
        {
            builder.From(true).EndQuery();
            Assert.AreEqual("FROM ;", builder.Query);
        }
    }
}