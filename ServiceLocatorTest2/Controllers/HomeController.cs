using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ServiceLocatorIdea.Models;
using ServiceLocatorIdea.Services;

namespace ServiceLocatorIdea.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController>? _logger;
    private readonly IArrayReversalService? _arrayReversalService;

    public HomeController(IServiceProvider serviceProvider)
    {
        _arrayReversalService = serviceProvider.GetService<IArrayReversalService>();
        _logger = serviceProvider.GetService<ILogger<HomeController>>();
    }

    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ReverseArray(string arrayToReverse)
    {
        if (arrayToReverse == null)
        {
            return Error();
        }
            
        var reversedArray = _arrayReversalService.ReverseArray(arrayToReverse);

        var model = new ReversedArrayModel()
        {
            InitialArray = arrayToReverse,
            ReversedArray = reversedArray
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}