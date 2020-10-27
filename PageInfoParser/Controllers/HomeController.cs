using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PageInfoParser.Models;
using PageInfoParserService.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PageInfoParser.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPageParserService _pageParserService;

        public HomeController(ILogger<HomeController> logger, IPageParserService pageParserService)
        {
            _logger = logger;
            _pageParserService = pageParserService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovedPermanently()
        {
            return new StatusCodeResult(301);
        }

        [HttpPost]
        public async Task<IActionResult> PageInfoUpload(string pageUrl)
        {
            return Ok(await _pageParserService.GetPagesInfoAsync(pageUrl));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
