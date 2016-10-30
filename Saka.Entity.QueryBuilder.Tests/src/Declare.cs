using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Declare
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Declare_WihtString()
        {
            builder.Declare("Temp").EndQuery();
            Assert.AreEqual("DECLARE @Temp ;", builder.Query);
        }

        [TestMethod]
        public void Declare_Just()
        {
            builder.Declare().EndQuery();
            Assert.AreEqual("DECLARE ;", builder.Query);
        }
    }
}