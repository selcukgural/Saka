using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Columns
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Columns_WithExpression()
        {
            var query =builder.Columns(e => e.BusinessEntityID, e => e.EmailPromotion, e => e.LastName, e => e.PersonType)
                    .EndQuery();
            Assert.AreEqual("([BusinessEntityID],[EmailPromotion],[LastName],[PersonType]) ;", query);
        }

        [TestMethod]
        public void Columns_WithIEnumerable()
        {
            var columns = new List<string>
            {
                "BusinessEntityID",
                "EmailPromotion",
                "LastName",
                "PersonType"
            };
            var query = builder.Columns(columns).EndQuery();
            Assert.AreEqual("([BusinessEntityID],[EmailPromotion],[LastName],[PersonType]) ;", query);
        }

        [TestMethod]
        public void Columns_WithParams()
        {
            var query = builder.Columns("BusinessEntityID", "EmailPromotion", "LastName", "PersonType").EndQuery();
            Assert.AreEqual("([BusinessEntityID],[EmailPromotion],[LastName],[PersonType]) ;", query);
        }
    }
}