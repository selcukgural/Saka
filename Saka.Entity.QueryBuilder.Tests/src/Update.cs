using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Update
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void WithString()
        {
            builder.Update("Person").EndQuery();
            Assert.AreEqual("UPDATE [Person] ;",builder.Query);
        }
        [TestMethod]
        public void JustUpdate_WihtGenericType()
        {
            builder.Update(true).EndQuery();
            Assert.AreEqual("UPDATE [Person] ;", builder.Query);
        }
        [TestMethod]
        public void JustUpdate()
        {
            builder.Update().EndQuery();
            Assert.AreEqual("UPDATE ;", builder.Query);
        }
    }
}