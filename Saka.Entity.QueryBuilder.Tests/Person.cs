namespace Saka.Entity.QueryBuilder.Tests
{
    using System;
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
