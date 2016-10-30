using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Or
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void WithString()
        {
            builder.Or("FistName = 'Selçuk'").EndQuery();
            Assert.AreEqual("OR FistName = 'Selçuk' ;",builder.Query);
            builder.Clear();

            builder.Or("LastName = 'Güral'",true).EndQuery();
            Assert.AreEqual("OR (LastName = 'Güral') ;", builder.Query);
        }
        [TestMethod]
        public void JustOr()
        {
            builder.Or().EndQuery();
            Assert.AreEqual("OR ;", builder.Query);
        }
        [TestMethod]
        public void WithExpression()
        {
            builder.Or(e=> e.BusinessEntityID.Equals(10)).EndQuery();
            Assert.AreEqual("OR [BusinessEntityID] = 10 ;", builder.Query);

        }
    }
}