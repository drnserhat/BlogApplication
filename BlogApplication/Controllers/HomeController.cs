﻿using BlogApplication.Models;
using BlogApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
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
            ViewBag.About = _db.Hakkimizdas.FirstOrDefault();
            var aboutFoto = _db.Fotografs.Where(a => a.FotoTipi == Enums.FotoTipi.hakkimizda).FirstOrDefault();
			ViewBag.AboutFoto = aboutFoto.FotoUrl;
			var hizmet = _db.Hizmetlers.Where(a => a.HizmetTipi == Enums.HizmetTipi.hizmet).Take(4).ToList();
            ViewBag.Hizmet=hizmet;
			var proje = _db.Hizmetlers.Where(a => a.HizmetTipi == Enums.HizmetTipi.proje).Take(4).ToList();
			ViewBag.Projeler = proje;

            ViewBag.MessageCount = _db.Messages.Count();
			return View(ana);
        }

        public IActionResult Services()
        {
            var ana = _db.Hizmetlers.Where(a => a.HizmetTipi == Enums.HizmetTipi.hizmet).ToList();


            return View(ana);

		}
        public IActionResult ServiceDetail(int id)
        {
            if (id==0)
            {
                id = Convert.ToInt32(HttpContext.Session.GetString("Id"));

			}
			else
            {
				HttpContext.Session.SetString("Id", id.ToString());

			}
			var detay = _db.Hizmetlers.Where(a=>a.ID == id).FirstOrDefault();
            return View(detay);
        }

        public IActionResult Projects()
        {
            var ana = _db.Hizmetlers.Where(a=>a.HizmetTipi==Enums.HizmetTipi.proje).ToList();


            return View(ana);

        }
        public IActionResult ProjectDetail(int id)
        {
            if (id == 0)
            {
                id = Convert.ToInt32(HttpContext.Session.GetString("Id"));

            }
            else
            {
                HttpContext.Session.SetString("Id", id.ToString());

            }
            var detay = _db.Hizmetlers.Where(a => a.ID == id).FirstOrDefault();
            return View(detay);
        }

        public IActionResult About() {

			var ana = _db.Hakkimizdas.FirstOrDefault();
            var fotograf = _db.Fotografs.Where(a => a.FotoTipi == Enums.FotoTipi.hakkimizda).FirstOrDefault();
            ViewBag.Fotograf = fotograf.FotoUrl;
			return View(ana);
		}

        public IActionResult Contact()
        {
			var ana = _db.Iletisims.FirstOrDefault();
			var fotograf = _db.Fotografs.Where(a => a.FotoTipi == Enums.FotoTipi.iletisim).FirstOrDefault();
			ViewBag.Fotograf = fotograf.FotoUrl;
			return View(ana);
		}

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Contact");
            }
            _db.Messages.Add(message);
            _db.SaveChanges();
            return RedirectToAction("Contact");
        }

        [HttpPost]
        public IActionResult SendEmail(Message message)
        {
            message.Name = "Email ileten..";
            message.Mesaj = "Email ileten..";
            message.Konu = "Email ileten..";
			if (message.Email==null || message.Email == "")
			{
				return RedirectToAction("Index");
			}
			_db.Messages.Add(message);
			_db.SaveChanges();
			return RedirectToAction("Index");
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
