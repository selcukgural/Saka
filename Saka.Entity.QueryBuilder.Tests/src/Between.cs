using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Between
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Between_WihtObjects()
        {
            builder.Between(125,589).EndQuery();
            Assert.AreEqual("BETWEEN 125 AND 589 ;",builder.Query);
        }
        [TestMethod]
        public void Between_WihtObjects_2()
        {
            builder.Between('C', 'M').EndQuery();
            Assert.AreEqual("BETWEEN 'C' AND 'M' ;", builder.Query);
        }
        [TestMethod]
        public void Between_Just()
        {
            builder.Between().EndQuery();
            Assert.AreEqual("BETWEEN ;", builder.Query);
        }
    }
}