using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GalacticNavigator.Models;
using GalacticNavigator.Services; 

namespace GalacticNavigator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly NasaApiService _nasaApiService; // Add this

    // Modify the constructor to inject NasaApiService
    public HomeController(ILogger<HomeController> logger, NasaApiService nasaApiService)
    {
        _logger = logger;
        _nasaApiService = nasaApiService; // Set the injected service
    }

    // Modify the Index action to be asynchronous and use the NasaApiService
    public async Task<IActionResult> Index()
    {
        var model = await _nasaApiService.GetAstronomyPictureOfTheDayAsync(); // Use the service to get the model
        return View(model);
    }

    
}
