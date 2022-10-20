using EFDbLibrary;
using EFDbLibrary.DTOs;
using InventoryHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    private static IConfigurationRoot _configuration;
    private static DbContextOptionsBuilder<AdventureWorks2019Context> _optionsBuilder;
    static void Main(string[] args)
    {
        BuildOptions();
        //ListPeopleThenOrderAndTake();
        //QueryPeopleOrderedToListAndTake();
        //FilteredAndPagedResult(string filter, int pageNumber, int pageSize);
        // FilteredAndPagedResult("Ma", 1, 50);
        // ListAllSalespeople();
        //ShowAllSalespeopleUsingProjection();
       // GenerateSalesReportData(20);
        GenerateSalesReportDataToDTO();
    }
    static void BuildOptions()
    {
        _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
        _optionsBuilder = new DbContextOptionsBuilder<AdventureWorks2019Context>();
        _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AdventureWorks"));

        Console.WriteLine(_configuration.GetConnectionString("AdventureWorks"));
    }

    private static void ListPeopleThenOrderAndTake()
    {
        using (var db = new AdventureWorks2019Context(_optionsBuilder.Options))
        {
            var people = db.People.ToList().OrderByDescending(x => x.LastName);

            foreach (var person in people.Take(10))
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}");
            }
        }
    }
    private static void QueryPeopleOrderedToListAndTake()
    {
        using (var db = new AdventureWorks2019Context(_optionsBuilder.Options))
        {
            var query = db.People.AsNoTracking().OrderByDescending(x => x.LastName);
            var result = query.Take(10);
            foreach (var person in result)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}");
            }
        }
    }

    private static void FilteredAndPagedResult(string filter, int pageNumber, int pageSize)
    {
        using (var db = new AdventureWorks2019Context(_optionsBuilder.Options))
        {
            var searchTerm = filter.ToLower();

            var query = db.People.AsNoTracking().Where(x => x.LastName.ToLower().Contains(searchTerm)
            || x.FirstName.ToLower().Contains(searchTerm)
            || x.PersonType.ToLower().Equals(searchTerm))
            .OrderBy(x => x.LastName)
            .Skip(pageNumber * pageSize)
            .Take(pageSize);


            foreach (var person in query)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}, {person.PersonType}");
            }
        }
    }

    private static string GetSalespersonDetail(SalesPerson sp)
    {
        return $"ID: {sp.BusinessEntityId}\t|TID: {sp.TerritoryId}\t|Quota:{ sp.SalesQuota}\t" +
        $"|Bonus: {sp.Bonus}\t|YTDSales: {sp.SalesYtd}\t|Name: \t" +
        $"{sp.BusinessEntity?.BusinessEntity?.FirstName ?? ""}, " +
        $"{sp.BusinessEntity?.BusinessEntity?.LastName ?? ""}";

       
    }

    //private static void ListAllSalespeople()
    //{
    //    using (var db = new AdventureWorks2019Context(_optionsBuilder.Options))
    //    {
    //        var salespeople = db.SalesPeople.AsNoTracking().ToList();

    //        foreach(var salesPerson in salespeople)
    //        {
    //            var p = db.People.FirstOrDefault(x => x.BusinessEntityId == salesPerson.BusinessEntityId);
    //            Console.WriteLine(GetSalespersonDetail(salesPerson,p));
    //        }
    //    }
    //}

    private static void ListAllSalespeople()
    {
        using (var db = new AdventureWorks2019Context(_optionsBuilder.Options))
        {
            var salespeople = db.SalesPeople
                .Include(x => x.BusinessEntity)
                .ThenInclude(y => y.BusinessEntity)
                .AsNoTracking().ToList();


            foreach (var salesPerson in salespeople)
            {
             
                Console.WriteLine(GetSalespersonDetail(salesPerson));
            }
        }
    }

    //private static void ShowAllSalespeopleUsingProjection()
    //{
    //    using (var db = new AdventureWorks2019Context(_optionsBuilder.Options))
    //    {
    //        //Query
    //        var salespeople = db.SalesPeople
    //            .Include(x => x.BusinessEntity) // Navigation
    //            .ThenInclude(y => y.BusinessEntity) //Navigation
    //            .AsNoTracking()
    //            .Select(x => new
    //            {
    //                x.BusinessEntityId,
    //                x.BusinessEntity.BusinessEntity.FirstName,
    //                x.BusinessEntity.BusinessEntity.LastName,
    //                x.SalesQuota,
    //                x.SalesYtd,
    //                x.SalesLastYear

    //            }
                   
    //            ).ToList();

    //        // Loop
    //        foreach (var sp in salespeople)
    //        {
    //            Console.WriteLine($"BID: {sp.BusinessEntityId} | Name: {sp.LastName}" +
    //            $", {sp.FirstName} | Quota: {sp.SalesQuota} | " +
    //            $"YTD Sales: {sp.SalesYtd} | SalesLastYear{ sp.SalesLastYear} ");
    //        }
    //    }
    //}

    // We can leave out Include and ThenInclude() navigation properties when using Projection
    private static void ShowAllSalespeopleUsingProjection()
    {
        using (var db = new AdventureWorks2019Context(_optionsBuilder.Options))
        {
            //Query
            var salespeople = db.SalesPeople
                //.Include(x => x.BusinessEntity) // Navigation
                //.ThenInclude(y => y.BusinessEntity) //Navigation
                .AsNoTracking()
                .Select(x => new
                {
                    x.BusinessEntityId,
                    x.BusinessEntity.BusinessEntity.FirstName,
                    x.BusinessEntity.BusinessEntity.LastName,
                    x.SalesQuota,
                    x.SalesYtd,
                    x.SalesLastYear

                }

                ).ToList();

            // Loop
            foreach (var sp in salespeople)
            {
                Console.WriteLine($"BID: {sp.BusinessEntityId} | Name: {sp.LastName}" +
                $", {sp.FirstName} | Quota: {sp.SalesQuota} | " +
                $"YTD Sales: {sp.SalesYtd} | SalesLastYear{sp.SalesLastYear} ");
            }
        }
    }

    private static void GenerateSalesReportData(int filter)
    {
        using (var db = new AdventureWorks2019Context(_optionsBuilder.Options))
        {
            var salesReportData = db.SalesPeople
                .Select( sp => new
                {
                    beid = sp.BusinessEntityId,
                    sp.BusinessEntity.BusinessEntity.FirstName,
                    sp.BusinessEntity.BusinessEntity.LastName,
                    sp.SalesYtd,
                    Territories = sp.SalesTerritoryHistories
                                 .Select(y => y.Territory.Name),
                    OrderCount = sp.SalesOrderHeaders.Count(),
                    TotalProductsSold = sp.SalesOrderHeaders
                    .SelectMany(y => y.SalesOrderDetails)
                    .Sum(z => z.OrderQty)

                }
             ).Where(srdata => srdata.SalesYtd > filter)
             .OrderBy(srds => srds.LastName)
             .ThenBy(srds => srds.FirstName)
             .ThenByDescending(srds => srds.SalesYtd)
             .ToList();

            foreach (var srd in salesReportData)
            {
                Console.WriteLine($"{srd.beid}| {srd.LastName}, {srd.FirstName} |" +
                $"YTD Sales: {srd.SalesYtd} |" +
                $"{string.Join(',', srd.Territories)} |" +
                $"Order Count: {srd.OrderCount} |" +
                $"Products Sold: {srd.TotalProductsSold}");
            }
        }
    }

    private static void GenerateSalesReportDataToDTO()
    {
        Console.WriteLine("What is the minimum amount of sales");
        var input = Console.ReadLine();
        decimal filter = 0.0m;

        if(!decimal.TryParse(input,out filter))
        {
            Console.WriteLine("Bad input");
            return;
        }
        using (var db = new AdventureWorks2019Context(_optionsBuilder.Options))
        {
            var salesReportData = db.SalesPeople
                .Select(sp => new SalesReportListingDTO
                {
                    BusinessEntityId = sp.BusinessEntityId,
                    FirstName = sp.BusinessEntity.BusinessEntity.FirstName,
                    LastName = sp.BusinessEntity.BusinessEntity.LastName,
                    SalesYtd = sp.SalesYtd,
                    Territories = sp.SalesTerritoryHistories
                    .Select(y => y.Territory.Name),
                    TotalOrders = sp.SalesOrderHeaders.Count(),
                    TotalProductsSold = sp.SalesOrderHeaders
                    .SelectMany(y => y.SalesOrderDetails)
                    .Sum(z => z.OrderQty)

                }
             ).Where(srdata => srdata.SalesYtd > filter)
             .OrderBy(srds => srds.LastName)
             .ThenBy(srds => srds.FirstName)
             .ThenByDescending(srds => srds.SalesYtd)
             .ToList();

            foreach (var srd in salesReportData)
            {
                Console.WriteLine(srd.ToString());
            }
        }
    }
}
