using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{

    [TestClass]
    public class Count
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Count_With_Expression()
        {
            builder.Count(e => e.BusinessEntityID);
            Assert.AreEqual("COUNT ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Count_With_HardQuery()
        {
            builder.Count("BusinessEntityID");
            Assert.AreEqual("COUNT ([BusinessEntityID]) ", builder.Query);
        }
        [TestMethod]
        public void Count_With_IsStar()
        {
            builder.Count(true);
            Assert.AreEqual("COUNT (*) ", builder.Query);
        }
        [TestMethod]
        public void Count_With_Comma()
        {
            builder.Count(comma:true);
            Assert.AreEqual(",COUNT ", builder.Query);
        }
        [TestMethod]
        public void Count_With_Is_Not_Star()
        {
            builder.Count();
            Assert.AreEqual("COUNT ", builder.Query);
        }
    }
}
