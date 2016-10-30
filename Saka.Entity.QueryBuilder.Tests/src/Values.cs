using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Values
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Values_WithIEnumerable()
        {
            var columns = new List<object>
            {
               1,
               "LastName"
            };
            var query = builder.Values(columns).EndQuery();
            Assert.AreEqual("VALUES (1,'LastName') ;", query);
        }

        [TestMethod]
        public void Values_WithParams()
        {
            var query = builder.Values(215, "FirstName", 'S').EndQuery();
            Assert.AreEqual("VALUES (215,'FirstName','S') ;", query);
        }
    }
}