using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GalacticNavigator.Models;
using GalacticNavigator.Services;


public class SpaceController : Controller
{
    private readonly NasaApiService _nasaApiService;

    public SpaceController(NasaApiService nasaApiService)
    {
        _nasaApiService = nasaApiService;
    }

    public async Task<IActionResult> Index()
    {
        var apod = await _nasaApiService.GetAstronomyPictureOfTheDayAsync();
        return View(apod);
    }
}
