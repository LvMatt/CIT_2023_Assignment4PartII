using DataLayer.YourOutputDirectory;

var service = new DataService();
var findOrderDetail = service.GetOrderDetailsByOrderId(10248);
var order = service.GetOrder(10248);

Console.WriteLine("IMPORTANT! {0}", order.OrderDetails?.First().Product?.Name);

Console.ReadKey();


// dotnet ef dbcontext scaffold "Server=localhost;Database=northwind;User Id=postgres;Password=admin" Npgsql.EntityFrameworkCore.PostgreSQL -o YourOutputDirectory 