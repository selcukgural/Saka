using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Distinct
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void WihtExpression()
        {
            var query =
                builder.Distinct(e => e.BusinessEntityID, e => e.EmailPromotion, e => e.LastName, e => e.PersonType)
                    .EndQuery();
            Assert.AreEqual("DISTINCT [BusinessEntityID],[EmailPromotion],[LastName],[PersonType] ;", query);
        }

        [TestMethod]
        public void WithIEnumerable()
        {
            var columns = new List<string>
            {
                "BusinessEntityID",
                "EmailPromotion",
                "LastName",
                "PersonType"
            };
            var query = builder.Distinct(columns).EndQuery();
            Assert.AreEqual("DISTINCT [BusinessEntityID],[EmailPromotion],[LastName],[PersonType] ;", query);
        }

        [TestMethod]
        public void WihtParams()
        {
            var query = builder.Distinct("BusinessEntityID", "EmailPromotion", "LastName", "PersonType").EndQuery();
            Assert.AreEqual("DISTINCT [BusinessEntityID],[EmailPromotion],[LastName],[PersonType] ;", query);
        }

        [TestMethod]
        public void JustDistinct()
        {
            var query = builder.Distinct().EndQuery();
            Assert.AreEqual("DISTINCT ;", query);
        }
    }
}