using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saka.Entity.QueryBuilder.Tests
{
    [TestClass]
    public class Print
    {
        private readonly QueryBuilder<Person> builder = new QueryBuilder<Person>();

        [TestMethod]
        public void Print_WihtString()
        {
            builder.Print("Merhaba dünya!").EndQuery();
            Assert.AreEqual("PRINT 'Merhaba dünya!' ;", builder.Query);
        }
        [TestMethod]
        public void Print_Just()
        {
            builder.Print().EndQuery();
            Assert.AreEqual("PRINT ;", builder.Query);
        }
    }
}