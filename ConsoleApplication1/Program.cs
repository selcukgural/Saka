using System;
using Saka.Entity.QueryBuilder;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new QueryBuilder<Person>();
            var query = builder.Select(e => e.BusinessEntityID, e => e.MiddleName, e => e.LastName, e => e.Title)
                .From("Person.Person")
                .Where(e => e.Title)
                .Is()
                .Not()
                .Null();
            Console.ReadKey();

        }
    }
    public class Person
    {
        public int BusinessEntityID { get; set; }
        public string PersonType { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string MiddleName { get; set; }
        public string EmailPromotion { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public int MakeFlag { get; set; }
        public string Color { get; set; }
        public int SafetyStockLevel { get; set; }
        public int ReorderPoint { get; set; }
        public string Size { get; set; }
        public string RowGuid { get; set; }
    }
}
