using Microsoft.AspNetCore.Mvc;
using ServiceLocatorTest2.Models;
using System.Diagnostics;
using ServiceLocatorTest2.Services;

namespace ServiceLocatorTest2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArrayReversalService _arrayReversalService;

        public HomeController(ILogger<HomeController> logger, IArrayReversalService arrayReversalService)
        {
            _logger = logger;
            _arrayReversalService = arrayReversalService;
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
}