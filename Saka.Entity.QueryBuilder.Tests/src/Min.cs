using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{

    [TestClass]
    public class Min
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Min_With_Expression()
        {
            builder.Min(e => e.BusinessEntityID);
            Assert.AreEqual("MIN ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Min_With_Expression_And_Comma()
        {
            builder.Min(e => e.BusinessEntityID,true);
            Assert.AreEqual(",MIN ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Min_With_HardQuery()
        {
            builder.Min("BusinessEntityID");
            Assert.AreEqual("MIN ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Min_With_HardQuery_With_Comma()
        {
            builder.Min("BusinessEntityID",true);
            Assert.AreEqual(",MIN ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Min_Just_Min()
        {
            builder.Min();
            Assert.AreEqual("MIN ", builder.Query);
        }
        [TestMethod]
        public void Min_Just_Min_Comma()
        {
            builder.Min(true);
            Assert.AreEqual(",MIN ", builder.Query);
        }
    }
}
