using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{

    [TestClass]
    public class Format
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Format_WithIEnumerable()
        {
            var format = new List<string>()
            {
                "5",
                "'00.000%'"
            };
            builder.Format(format);
            Assert.AreEqual("FORMAT (5,'00.000%') ", builder.Query);
        }
        [TestMethod]
        public void Format_Array()
        {
            var format = new[] {"getdate()", "'dd/mm/yyyy H:mm tt'", "'tr-TR'"};
            builder.Format(format);
            Assert.AreEqual("FORMAT (getdate(),'dd/mm/yyyy H:mm tt','tr-TR') ", builder.Query);
        }
        [TestMethod]
        public void JustFormat()
        {
            builder.Format().EndQuery();
            Assert.AreEqual("FORMAT ;", builder.Query);
        }
        [TestMethod]
        public void JustFormat_Comma()
        {
            builder.Format(true).EndQuery();
            Assert.AreEqual(",FORMAT ;", builder.Query);
        }
    }
}
