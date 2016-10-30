using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Then
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Then_WihtExpression()
        {
            builder.Then(e=> e.Title).EndQuery();
            Assert.AreEqual("THEN 'Title' ;", builder.Query);
        }
        [TestMethod]
        public void Then_WihtObject()
        {
            builder.Then('T').EndQuery();
            Assert.AreEqual("THEN 'T' ;", builder.Query);
        }

        [TestMethod]
        public void Then_Just()
        {
            builder.Then().EndQuery();
            Assert.AreEqual("THEN ;", builder.Query);
        }
    }
}