using System;
using System.Threading.Tasks;
using CatApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

public class HomeController : Controller
{
    private readonly ICatApiClient _catApiClient;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, ICatApiClient catApiClient)
    {
        _logger = logger;
        _catApiClient = catApiClient;
    }

    public async Task<ActionResult> Index()
    {
        var apiResponse = await _catApiClient.List(20);

        if (apiResponse.StatusCode != 200)
        {
            _logger.LogError("Unexpected HTTP status calling _catApiClient.List, expected 200, got {statuscode}", apiResponse.StatusCode);
            throw new Exception("Failed to call _catApiClient.List");
        }

        _logger.LogInformation("Rendering list of {count} images", apiResponse.Response.Data.Images.Count);

        return View(new CatListModel
        {
            Images = apiResponse.Response.Data.Images,
        });
    }
}