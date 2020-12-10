### You can create with your POCO objects with simple T-SQL query.

```csharp
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
                .Null().EndQuery();
            //SELECT [BusinessEntityID],[MiddleName],[LastName],[Title] FROM Person.Person WHERE [Title] IS NOT NULL ;
            Console.WriteLine(query);
            builder.Clear();



            query =
               builder.Select()
                   .Top(100, false, e => e.BusinessEntityID, e => e.MiddleName, e => e.LastName)
                   .From()
                   .EndQuery();
            //SELECT TOP 100 [BusinessEntityID],[MiddleName],[LastName] FROM Person ;
            Console.WriteLine(query);
            builder.Clear();



            query = builder.SelectAllProperties().From().Where(e => e.PersonType).In("EM", "IN").EndQuery();
            //SELECT [BusinessEntityID],[PersonType],[LastName],[Title],[MiddleName],[EmailPromotion],[ModifiedDate] FROM Person WHERE [PersonType] IN ('EM','IN') ;
            Console.WriteLine(query);
            builder.Clear();



            query =
                builder.Select().Avg(e => e.Total)
                    .From(true).FreeText("( ").Select(e => e.MiddleName, e => e.LastName).Sum(e => e.Amount).As("TOTAL")
                    .From("PENALTIES")
                    .GroupBy(e => e.LastName).As("TOTALS")
                .Where(e => e.LastName).In()
                    .FreeText("( ")
                    .Select(e => e.LastName)
                    .From("Players")
                    .Where(e => e.LastName == "Jack").Or(e => e.LastName == "Mike")
                    .FreeText(")")
                    .EndQuery();
            /*
             SELECT AVG ([Total]) 
	            FROM ( SELECT [MiddleName],[LastName] SUM ([Amount]) AS [TOTAL] 
	            FROM PENALTIES GROUP BY [LastName] AS [TOTALS] 
            WHERE [LastName] IN ( SELECT [LastName] FROM Players WHERE [LastName] = 'Jack'  OR [LastName] = 'Mike' );
             */
            Console.WriteLine(query);
            builder.Clear();



            query =
                        builder.Select(e => e.LastName, e => e.MiddleName, e => e.Title)
                            .From()
                            .LeftJoin<Product>()
                            .On<Product>(e => e.BusinessEntityID, e => e.ProductID)
                            .Where(e => e.BusinessEntityID > 20)
                            .EndQuery();
            //SELECT [LastName],[MiddleName],[Title] FROM Person LEFT JOIN Product ON Person.BusinessEntityID = Product.ProductID WHERE [BusinessEntityID] > 20 ;
            Console.WriteLine(query);
            builder.Clear();


            query =
                       builder.Insert()
                           .Into(true)
                           .Columns(e => e.LastName, e => e.MiddleName, e => e.Title)
                           .Values("güral", "selçuk", "DEV")
                           .EndQuery();
            //INSERT INTO Person ([LastName],[MiddleName],[Title]) VALUES ('güral','selçuk','DEV') ;
            Console.WriteLine(query);
            builder.Clear();


            query = builder.Delete().From().Where(e => e.BusinessEntityID == 2).EndQuery();
            //DELETE FROM Person WHERE[BusinessEntityID] = 2;
            Console.WriteLine(query);
            builder.Clear();
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
        public decimal Total { get; set; } //dummy
        public decimal Amount { get; set; }
    }
    public class Product
    {
        public int ProductID { get; set; }
        public decimal ListPrice { get; set; }
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
```
