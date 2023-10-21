var service = new DataService();
var categories = service.GetCategories();
Console.WriteLine("IMPORTANT! {0}", categories);


Console.ReadKey();