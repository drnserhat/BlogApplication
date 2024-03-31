using BlogApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
    public class AdminController : Controller
    {
        MyDbContext _db;
        public AdminController(MyDbContext myDbContext)
        {
                _db = myDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AnaSayfa() { return View(); }
        public IActionResult Hizmetler() { return View(); }
        public IActionResult Hakkimizda() { return View(); }
        public IActionResult Iletisim() { return View(); }


    }
}
