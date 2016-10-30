using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Top
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void WithParams()
        {
            builder.Top(50,false,"FirstName","LastName").EndQuery();
            Assert.AreEqual("TOP 50 [FirstName],[LastName] ;",builder.Query);
        }
        public void WithIEnumerable()
        {
            builder.Top(500,true, new List<string> {"LastName","FirstName"}).EndQuery();
            Assert.AreEqual("TOP 500 PERCENT [LastName],[FirstName] ;", builder.Query);
        }
        public void WithExpression()
        {
            builder.Top(20,false,e=>e.EmailPromotion,e=> e.BusinessEntityID,e=> e.PersonType).EndQuery();
            Assert.AreEqual("TOP 20 [EmailPromotion],[BusinessEntityID],[PersonType] ;", builder.Query);
        }
        [TestMethod]
        public void JustTop()
        {
            builder.Top().EndQuery();
            Assert.AreEqual("TOP ;", builder.Query);
        }
    }
}