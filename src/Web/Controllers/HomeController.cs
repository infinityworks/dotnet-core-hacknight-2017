using CatApi;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly ICatApiClient _catApiClient;

    public HomeController(ICatApiClient catApiClient)
    {
        _catApiClient = catApiClient;
    }

    public ActionResult Index()
    {
        return View();
    }
}