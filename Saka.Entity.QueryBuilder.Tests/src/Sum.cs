using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{

    [TestClass]
    public class Sum
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Sum_With_Expression()
        {
            builder.Sum(e => e.BusinessEntityID);
            Assert.AreEqual("SUM ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Sum_With_Expression_And_Comma()
        {
            builder.Sum(e => e.BusinessEntityID,true);
            Assert.AreEqual(",SUM ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Sum_With_HardQuery()
        {
            builder.Sum("BusinessEntityID");
            Assert.AreEqual("SUM ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Sum_With_HardQuery_With_Comma()
        {
            builder.Sum("BusinessEntityID",true);
            Assert.AreEqual(",SUM ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Sum_Just_Sum()
        {
            builder.Sum();
            Assert.AreEqual("SUM ", builder.Query);
        }
        [TestMethod]
        public void Sum_Just_Sum_Comma()
        {
            builder.Sum(true);
            Assert.AreEqual(",SUM ", builder.Query);
        }
    }
}
