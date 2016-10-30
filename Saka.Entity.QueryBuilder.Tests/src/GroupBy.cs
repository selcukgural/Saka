using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{

    [TestClass]
    public class GroupBy
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void GroupBy_With_Params_Expression()
        {
            builder.GroupBy(e => e.BusinessEntityID,e=>e.EmailPromotion,e=>e.MiddleName,e=> e.PersonType);
            Assert.AreEqual("GROUP BY [BusinessEntityID],[EmailPromotion],[MiddleName],[PersonType] ", builder.Query);
        }
        [TestMethod]
        public void GroupBy_With_Expression()
        {
            builder.GroupBy(e => e.BusinessEntityID);
            Assert.AreEqual("GROUP BY [BusinessEntityID] ", builder.Query);
        }
        [TestMethod]
        public void GroupBy_With_IEnumerable()
        {
            var groupBy = new List<string>
            {
                "BusinessEntityID","EmailPromotion","PersonType"
            };
            builder.GroupBy(groupBy);
            Assert.AreEqual("GROUP BY [BusinessEntityID],[EmailPromotion],[PersonType] ", builder.Query);
        }
        [TestMethod]
        public void GroupBy_With_HardQuery()
        {
            var groupBy = "[BusinessEntityID],[PersonType]";

            builder.GroupBy(groupBy);
            Assert.AreEqual("GROUP BY [BusinessEntityID],[PersonType] ", builder.Query);
        }
        [TestMethod]
        public void JustGroupBy()
        {
            builder.GroupBy().EndQuery();
            Assert.AreEqual("GROUP BY ;", builder.Query);
        }
    }
}
