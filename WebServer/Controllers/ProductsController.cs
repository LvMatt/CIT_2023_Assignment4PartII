using DataLayer;
using DataLayer.YourOutputDirectory;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/categories")]
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


}