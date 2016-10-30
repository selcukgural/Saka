using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Inserted
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Inserted_WihtExpression()
        {
            builder.Inserted(e => e.LastName, e => e.EmailPromotion, e => e.Title).EndQuery();
            Assert.AreEqual("INSERTED.LastName,INSERTED.EmailPromotion,INSERTED.Title ;", builder.Query);
        }
        [TestMethod]
        public void Inserted_WihtIEnumerable()
        {
            var inserted = new List<string>
            {
                "Id",
                "TempId"
            };
            builder.Inserted(inserted).EndQuery();
            Assert.AreEqual("INSERTED.Id,INSERTED.TempId ;", builder.Query);
        }

        [TestMethod]
        public void Inserted_WithParams()
        {
            builder.Inserted("Id").EndQuery();
            Assert.AreEqual("INSERTED.Id ;", builder.Query);
        }
        [TestMethod]
        public void Inserted_Just()
        {
            builder.Inserted().EndQuery();
            Assert.AreEqual("INSERTED;", builder.Query);
        }
    }
}