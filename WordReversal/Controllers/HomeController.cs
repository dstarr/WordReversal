using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WordReversal.Models;
using WordReversal.Services;

namespace WordReversal.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]

    public IActionResult ReverseWords(
        [FromServices] IWordReversalService wordReversalService, 
        string wordsToReverse)
    {
        var reversedWords = wordReversalService.ReverseWords(wordsToReverse);

        var model = new ReversedArrayModel()
        {
            InitialArray = wordsToReverse,
            ReversedArray = reversedWords
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