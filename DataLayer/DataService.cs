using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;
using DataLayer;
using DataLayer.YourOutputDirectory;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

public class DataService : IDataService
{

    public IList<Category> GetCategories()
    {
        var db = new NorthwindContext();
        return db.Categories.ToList();
    }
    public Category? GetCategory(int categoryId)
    {
        var db = new NorthwindContext();
        return db.Categories.FirstOrDefault(x => x.Id == categoryId);
    }
    public bool DeleteCategory(Category category)
    {
        return DeleteCategory(category.Id);
    }
    public bool DeleteCategory(int categoryId)
    {
        var db = new NorthwindContext();
        var category = db.Categories.FirstOrDefault(x => x.Id == categoryId);
        if (category != null)
        {
            db.Categories.Remove(category);
            //db.Remove(category);
            return db.SaveChanges() > 0;
        }
        return false;
    }

    public Category CreateCategory(string name, string description) { 
    
        var db = new NorthwindContext();
        var id = db.Categories.Max(x => x.Id) + 1;
        var category = new Category
        {
            Id = id,
            Name = name,
            Description = description
        };
        db.Add(category);
        db.SaveChanges();
        return category;
    }

    public bool UpdateCategory(int id, string updName, string updDescription)
    {
      
        var db = new NorthwindContext();
        var category = GetCategory(id);
        if (category == null)
        {
            return false;
        }
        category.Description = updDescription;
        category.Name = updName;
        try
        {
            db.Update(category);
            db.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
    public Product? GetProduct(int categoryId)
    {
        var db = new NorthwindContext();
        var product = db.Products.FirstOrDefault(x => x.Id == categoryId);
        var categoryName = db.Categories.FirstOrDefault(x => x.Id == product.Categoryid).Name;
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            ReferenceHandler = ReferenceHandler.Preserve
        };


        product.CategoryName = categoryName;
        Console.WriteLine("SDADASD {0}", JsonSerializer.Serialize<Product>(product, options));
        return product;
    }

    public List<Product> GetProductByName(string substring)
    {
        var db = new NorthwindContext();
        var products = db.Products
         .Where(p => EF.Functions.Like(p.Name, $"%{substring}%")) // Use the EF.Functions.Like method for substring search
        .Select(p => new Product
        {
            Id = p.Id,
            Name = p.Name,
            Categoryid = p.Categoryid,
            QuantityPerUnit = p.QuantityPerUnit,
            UnitPrice = p.UnitPrice,
            UnitsInStock = p.UnitsInStock,
            CategoryName = Convert.ToString(db.Categories.FirstOrDefault(x => x.Id == p.Categoryid).Name)
        })
         .ToList();

        return products;
    }

    public List<Product> GetProductByCategory(int id)
    {
        var db = new NorthwindContext();
        var products = db.Products
            .Where(p => p.Categoryid == id)
             .Select(p => new Product
             {
                 Id = p.Id,
                 Name = p.Name,
                 Categoryid = p.Categoryid,
                 QuantityPerUnit = p.QuantityPerUnit,
                 UnitPrice = p.UnitPrice,
                 UnitsInStock = p.UnitsInStock,
                 CategoryName =db.Categories.FirstOrDefault(x => x.Id == p.Categoryid).Name
             })
            .ToList();
        return products; 
    }

    public Order GetOrder(int orderId)
    {
        var db = new NorthwindContext();
        var order = db.Orders
           .Where(p => p.Id == orderId)
           .Include(o => o.OrderDetails)  // Eager loading
           .First();
        return order;
    }

    public List<Order> GetOrders()
    {
        var db = new NorthwindContext();
        return db.Orders.ToList();
    }

    public ICollection<OrderDetails> GetOrderDetailsByOrderId(int id)
    {
        var db = new NorthwindContext();
        var orders = db.Orderdetails
            .Where(p => p.OrderId == id)
            .Include(o => o.Product)  // Eager loading
            .Include(o => o.Order)
            //.ThenInclude(od => od.)// Include the Product within OrderDetails

            .ToList();

        return orders;
    }

}


