using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Set
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();


        [TestMethod]
        public void WithExpression()
        {
            builder.Set(e=> e.BusinessEntityID == 567,e=> e.PersonType == "PM",e=> e.Title == "developer").EndQuery();
            Assert.AreEqual("SET ([BusinessEntityID] = 567 ,[PersonType] = 'PM' ,[Title] = 'developer' ) ;", builder.Query);
        }
        [TestMethod]
        public void WithDicitonary()
        {
            var dictionary = new Dictionary<string, object> {{ "FirstName", "Selçuk"}, {"LastName", "Güral"}, {"Age", 34}};
            builder.Set(dictionary).EndQuery();
            Assert.AreEqual("SET ([FirstName] = 'Selçuk',[LastName] = 'Güral',[Age] = 34) ;",builder.Query);
        }
        [TestMethod]
        public void WihtEnumerable()
        {
            var columns = new List<string>
            {
                "FirstName",
                "LastName",
                "Age"
            };
            var values = new List<object>
            {
                "Selçuk",
                "Güral",
                34
            };
            builder.Set(columns, values).EndQuery();
            Assert.AreEqual("SET ([FirstName] = 'Selçuk',[LastName] = 'Güral',[Age] = 34) ;", builder.Query);
        }
        [TestMethod]
        public void WithSingle()
        {
            builder.Set("FirstName", 34).EndQuery();
            Assert.AreEqual("SET ([FirstName] = 34) ;", builder.Query);
        }
        [TestMethod]
        public void JustSet()
        {
            builder.Set().EndQuery();
            Assert.AreEqual("SET ;", builder.Query);
        }
    }
}