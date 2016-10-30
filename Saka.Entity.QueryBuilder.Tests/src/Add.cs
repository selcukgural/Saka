using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Add
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Add_WihtExpression()
        {
            builder.Add(e => e.LastName, SqlDbType.NVarChar, 20, true).EndQuery();
            Assert.AreEqual("ADD [LastName] NVarChar(20) NULL ;", builder.Query);
        }
        [TestMethod]
        public void Add_WihtExpression_2()
        {
            builder.Add(e => e.BusinessEntityID, SqlDbType.BigInt, false).EndQuery();
            Assert.AreEqual("ADD [BusinessEntityID] BigInt NOT NULL ;", builder.Query);
        }

        [TestMethod]
        public void Add_WithParameters()
        {
            builder.Add("FirstName",SqlDbType.NVarChar, 50,true).EndQuery();
            Assert.AreEqual("ADD [FirstName] NVarChar(50) NULL ;", builder.Query);
        }
        [TestMethod]
        public void Add_WithParameters_2()
        {
            builder.Add("State", SqlDbType.Bit, true).EndQuery();
            Assert.AreEqual("ADD [State] Bit NULL ;", builder.Query);
        }
        [TestMethod]
        public void Add_Just()
        {
            builder.Add().EndQuery();
            Assert.AreEqual("ADD ;", builder.Query);
        }
    }
}