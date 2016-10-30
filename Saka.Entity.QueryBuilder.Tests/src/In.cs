using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class In
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void IN_WihtEnumerable()
        {
            IEnumerable<object> t1 = new List<object>()
            {
                "price",
                "person",
                "age",
                12,2342f,
                54,
                'c'
            };
            builder.In(t1).EndQuery();
            Assert.AreEqual("IN ('price','person','age',12,2342,54,'c') ;", builder.Query);
        }
        [TestMethod]
        public void IN_WihtParams()
        {
            IEnumerable<object> t1 = new List<object>()
            {
                12,
                "selçuk",
                'b'
            };
            builder.In(t1).EndQuery();
            Assert.AreEqual("IN (12,'selçuk','b') ;", builder.Query);
        }

        [TestMethod]
        public void In_Just()
        {
            builder.In().EndQuery();
            Assert.AreEqual("IN ;", builder.Query);
        }

    }
}