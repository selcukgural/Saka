using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Use
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Use_WihtString()
        {
            builder.Use("AdventureWorks2014").EndQuery();
            Assert.AreEqual("USE [AdventureWorks2014] ;", builder.Query);
        }
        [TestMethod]
        public void Use_Just()
        {
            builder.Use().EndQuery();
            Assert.AreEqual("USE ;", builder.Query);
        }
    }
}