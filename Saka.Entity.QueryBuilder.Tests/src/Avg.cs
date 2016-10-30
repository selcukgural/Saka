using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{

    [TestClass]
    public class Avg
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Avg_With_Expression()
        {
            builder.Avg(e => e.BusinessEntityID);
            Assert.AreEqual("AVG ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Avg_With_Expression_And_Comma()
        {
            builder.Avg(e => e.BusinessEntityID,true);
            Assert.AreEqual(",AVG ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Avg_With_HardQuery()
        {
            builder.Avg("BusinessEntityID");
            Assert.AreEqual("AVG ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Avg_With_HardQuery_With_Comma()
        {
            builder.Avg("BusinessEntityID",true);
            Assert.AreEqual(",AVG ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Avg_Just_Avg()
        {
            builder.Avg();
            Assert.AreEqual("AVG ", builder.Query);
        }
    }
}
