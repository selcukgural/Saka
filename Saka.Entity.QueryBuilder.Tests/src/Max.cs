using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{

    [TestClass]
    public class Max
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Max_With_Expression()
        {
            builder.Max(e => e.BusinessEntityID);
            Assert.AreEqual("MAX ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Max_With_Expression_And_Comma()
        {
            builder.Max(e => e.BusinessEntityID,true);
            Assert.AreEqual(",MAX ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Max_With_HardQuery()
        {
            builder.Max("BusinessEntityID");
            Assert.AreEqual("MAX ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Max_With_HardQuery_With_Comma()
        {
            builder.Max("BusinessEntityID",true);
            Assert.AreEqual(",MAX ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void JustMax()
        {
            builder.Max();
            Assert.AreEqual("MAX ", builder.Query);
        }
        [TestMethod]
        public void JustMax_Comma()
        {
            builder.Max(true);
            Assert.AreEqual(",MAX ", builder.Query);
        }
    }
}
