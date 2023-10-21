using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;
using DataLayer;

public class DataService
{

    public IList<Category> GetCategories()
    {
        var db = new NorthwindDbContext();
        return db.categories.ToList();
    }
    public Category? GetCategory(int categoryId)
    {
        var db = new NorthwindDbContext();
        return db.categories.FirstOrDefault(x => x.Id == categoryId);
    }
    public bool DeleteCategory(Category category)
    {
        return DeleteCategory(category.Id);
    }
    public bool DeleteCategory(int categoryId)
    {
        var db = new NorthwindDbContext();
        var category = db.categories.FirstOrDefault(x => x.Id == categoryId);
        if (category != null)
        {
            db.categories.Remove(category);
            //db.Remove(category);
            return db.SaveChanges() > 0;
        }
        return false;
    }

    public Category CreateCategory(string name, string description)
    {
        var db = new NorthwindDbContext();
        var id = db.categories.Max(x => x.Id) + 1;
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




}


