using DataLayer;
using DataLayer.YourOutputDirectory;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    
    private readonly IDataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public CategoriesController(IDataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }

    [HttpGet]
    public IActionResult GetCetagories(string? name = null)
    {
        IEnumerable<Category>  result = _dataService.GetCategories();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetCategory(int id)
    {
        Category result = _dataService.GetCategory(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }


    [HttpDelete("{id}")]
    public IActionResult RemoveCategory(int id)
    {
        var existingCategory = _dataService.GetCategory(id);
        if (existingCategory == null)
        {
            Console.WriteLine("not found!");
            return NotFound(); // Category not found, return 404 Not Found response.
        }

        // Update the properties of the existing category.

        // Return the updated category.
        return Ok(existingCategory);
    }





}