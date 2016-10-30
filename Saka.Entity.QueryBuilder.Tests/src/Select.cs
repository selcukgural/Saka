using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Select_
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Select_With_Linq_Expression()
        {
            var query =
                builder.Select(e => e.BusinessEntityID, e => e.EmailPromotion, e => e.LastName, e => e.PersonType)
                    .EndQuery();
            Assert.AreEqual("SELECT [BusinessEntityID],[EmailPromotion],[LastName],[PersonType] ;", query);
        }

        [TestMethod]
        public void Select_With_IEnumerable()
        {
            var columns = new List<string>
            {
                "BusinessEntityID",
                "EmailPromotion",
                "LastName",
                "PersonType"
            };
            var query = builder.Select(columns).EndQuery();
            Assert.AreEqual("SELECT [BusinessEntityID],[EmailPromotion],[LastName],[PersonType] ;", query);
        }

        [TestMethod]
        public void Select_With_params()
        {
            var query = builder.Select("BusinessEntityID", "EmailPromotion", "LastName", "PersonType").EndQuery();
            Assert.AreEqual("SELECT [BusinessEntityID],[EmailPromotion],[LastName],[PersonType] ;", query);
        }
        [TestMethod]
        public void Select_AlllProperties()
        {
            var query = builder.SelectAllProperties().EndQuery();
            Assert.AreEqual("SELECT [BusinessEntityID],[PersonType],[LastName],[Title],[MiddleName],[EmailPromotion],[ModifiedDate] ;", query);
        }
        [TestMethod]
        public void Select()
        {
            var query = builder.Select().EndQuery();
            Assert.AreEqual("SELECT ;", query);
        }
        [TestMethod]
        public void Select_With_Star()
        {
            var query = builder.SelectAllWithStar().EndQuery();
            Assert.AreEqual("SELECT * ;", query);
        }
    }
}