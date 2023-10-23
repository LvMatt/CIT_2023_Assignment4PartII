using DataLayer.YourOutputDirectory;
using Microsoft.AspNetCore.Mvc;

namespace WebServerAPI.Controllers;

[ApiController]
[Route("api/categories")]
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
     

        return Ok(200);
    }
}

