using System;
using DataLayer.YourOutputDirectory;

public interface IDataService
{
    IList<Category> GetCategories();
    Category? GetCategory(int categoryId);
    bool DeleteCategory(Category category);
    public bool DeleteCategory(int categoryId);
    public Category CreateCategory(string name, string description);
    public bool UpdateCategory(int id, string updName, string updDescription);

    public Product? GetProduct(int categoryId);
    public List<Product> GetProductByName(string substring);
    public List<Product> GetProductByCategory(int id);

}

