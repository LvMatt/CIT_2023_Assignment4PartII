using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using DataLayer;
using DataLayer.YourOutputDirectory;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebServer.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{

    private readonly IDataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public ProductsController(IDataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }

    [HttpGet("{id:int}")]
    public IActionResult GetProduct(int id)
    {
        Product result = _dataService.GetProduct(id);

        if (result == null)
        {
            return NotFound();

        }

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            ReferenceHandler = ReferenceHandler.Preserve

        };

        var resultJson = JsonSerializer.Serialize<Product>(result, options);
        Console.WriteLine("resultJson {0}", resultJson);
        return Ok(resultJson);
    }

    [HttpGet("categories/{id:int}")]
    public IActionResult GetProductCategories(int id)
    {
        List<Product> result = _dataService.GetProductByCategory(id);

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            ReferenceHandler = ReferenceHandler.Preserve
        };

        var resultJson = JsonSerializer.Serialize(result, options);

        Console.WriteLine("DSDA1 {0}", resultJson);
        return Ok(resultJson);
    }


    [HttpGet]
    public IActionResult GetProductsByName([FromQuery] string name)
    {
        List<Product> result = _dataService.GetProductByName(name);

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            ReferenceHandler = ReferenceHandler.Preserve
        };

        var resultJson = JsonSerializer.Serialize<List<Product>>(result, options);
        string cleanedJson = RemoveJsonElements(resultJson, "$id", "$values");

        Console.WriteLine("DSDA1 {0}", cleanedJson);
        return Ok(cleanedJson);
    }


    public static string RemoveJsonElements(string json, params string[] elementNames)
    {
        try
        {
            using (JsonDocument doc = JsonDocument.Parse(json))
            {
                var root = doc.RootElement;

                // Remove specified JSON elements
                foreach (var elementName in elementNames)
                {
                    root.TryGetProperty(elementName, out _);
                }

                // Serialize the modified JSON back to a string
                return root.GetRawText();
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Failed to parse JSON: {ex}");
            return null;
        }
    }


}