using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class When
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void When_WihtExpression()
        {
            builder.When(e => e.LastName.Equals("Atatürk")).EndQuery();
            Assert.AreEqual("WHEN [LastName] = 'Atatürk' ;", builder.Query);
        }
        [TestMethod]
        public void When_WihtString()
        {
            builder.When("Age = 25").EndQuery();
            Assert.AreEqual("WHEN Age = 25 ;", builder.Query);
        }

        [TestMethod]
        public void When_Just()
        {
            builder.When().EndQuery();
            Assert.AreEqual("WHEN ;", builder.Query);
        }
    }
}