using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{

    [TestClass]
    public class Database
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Database_WithString()
        {
            builder.Database("AdventureWorks2014").EndQuery();
            Assert.AreEqual("DATABASE AdventureWorks2014 ;", builder.Query);
        }

        [TestMethod]
        public void Database_Just()
        {
            builder.Database().EndQuery();
            Assert.AreEqual("DATABASE ;", builder.Query);
        }
        [TestMethod]
        public void Database_GenericTableName()
        {
            builder.Database(true).EndQuery();
            Assert.AreEqual("DATABASE Person ;", builder.Query);
        }
    }
}
