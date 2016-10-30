using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Where
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();
        [TestMethod]
        public void Where_With_Equals_Method()
        {
            builder.Clear();
            builder.Where(e => e.BusinessEntityID.Equals(0)).EndQuery();
            Assert.AreEqual("WHERE [BusinessEntityID] = 0  ;", builder.Query);
        }
        [TestMethod]
        public void Where_With_Equal_Operand()
        {
            builder.Clear();
            builder.Where(e => e.BusinessEntityID == 0).EndQuery();
            Assert.AreEqual("WHERE [BusinessEntityID] = 0  ;", builder.Query);
        }
        [TestMethod]
        public void Where_With_LessThan_Equal()
        {
            builder.Clear();
            builder.Where(e => e.BusinessEntityID <= 0).EndQuery();
            Assert.AreEqual("WHERE [BusinessEntityID] <= 0  ;", builder.Query);
        }
        [TestMethod]
        public void Where_With_GreatherThan_Equal()
        {
            builder.Clear();
            builder.Where(e => e.BusinessEntityID >= 0).EndQuery();
            Assert.AreEqual("WHERE [BusinessEntityID] >= 0  ;", builder.Query);
        }
        [TestMethod]
        public void Where_With_NotEqual()
        {
            builder.Clear();
            builder.Where(e => e.BusinessEntityID != 0).EndQuery();
            Assert.AreEqual("WHERE [BusinessEntityID] <> 0  ;", builder.Query);
        }
        [TestMethod]
        public void Where_()
        {
            builder.Clear();
            builder.Where().EndQuery();
            Assert.AreEqual("WHERE ;", builder.Query);
        }
        [TestMethod]
        public void Where_Wiht_HardQuery()
        {
            builder.Clear();
            builder.Where("FirstName = 'Selçuk'").EndQuery();
            Assert.AreEqual("WHERE FirstName = 'Selçuk';", builder.Query);
        }
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Where_With_NotImplementedException()
        {
            builder.Clear();
            builder.Where(e => e.BusinessEntityID << 0).EndQuery();
        }
        [TestMethod]
        public void Where_Wiht_Parantess()
        {
            builder.Clear();
            builder.Where(e=> e.LastName == "Selçuk",true).EndQuery();
            Assert.AreEqual("WHERE ([LastName] = 'Selçuk'  );", builder.Query);
        }
    }
}
