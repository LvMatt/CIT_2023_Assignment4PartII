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
        Console.WriteLine("ID {0}", id);
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


}