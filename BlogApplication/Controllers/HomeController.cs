using BlogApplication.Models;
using BlogApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        MyDbContext _db;

        public HomeController(ILogger<HomeController> logger, MyDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var ana = _db.AnaSayfas.FirstOrDefault();
            ViewBag.Fotograf = _db.Fotografs.Where(a => a.FotoTipi == Enums.FotoTipi.anasayfa).ToList();
            return View(ana);
        }
        public IActionResult Services()
        {
			var ana = _db.Hizmetlers.ToList();
		

			return View(ana);

		}

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
