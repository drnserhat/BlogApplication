using BlogApplication.Enums;
using BlogApplication.Models;
using BlogApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
    public class AdminController : Controller
    {
        MyDbContext _db;
        private readonly IWebHostEnvironment _env;

        public AdminController(MyDbContext myDbContext, IWebHostEnvironment env)
        {
            _db = myDbContext;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AnaSayfa( ) { 
            var ana = _db.AnaSayfas.FirstOrDefault();
            ViewBag.Fotograf = _db.Fotografs.Where(a=>a.FotoTipi == Enums.FotoTipi.anasayfa).ToList();
          
            return View(ana); }
        [HttpPost]
        public IActionResult AnaSayfa(AnaSayfa anaSayfa,IFormFile[] file)
        {
            System.GC.Collect();
            string webRootPath = _env.WebRootPath;
            var fotolar= _db.Fotografs.Where(a => a.FotoTipi == Enums.FotoTipi.anasayfa).ToList();
            anaSayfa.UpdatedDate = DateTime.Now;
            anaSayfa.CreatedDate   = DateTime.Now;
            _db.AnaSayfas.Update(anaSayfa);
            if (file != null && file.Length > 0)
            {
                foreach (var item in fotolar)
                {
                    string oldFilePath = Path.Combine(webRootPath,item.FotoUrl );
                    if (System.IO.File.Exists(oldFilePath))
                    {

                        System.IO.File.Delete(oldFilePath);
                    }
                    _db.Fotografs.Remove(item);
                }

                foreach (var item in file)
                {
                    Fotograf fotograf = new();

                    fotograf.FotoUrl = UploadFile.Upload(item, FotoTipi.anasayfa);
                    fotograf.IslemSayfaID = anaSayfa.ID;
                    fotograf.FotoTipi = FotoTipi.anasayfa;
                  _db.Fotografs.Add(fotograf);

                }
            }
            _db.SaveChanges();
            return RedirectToAction("AnaSayfa","Admin");
        }

        public IActionResult Hizmetler() {
           // var ana = _db.Hizmetlers.FirstOrDefault();
            ViewBag.Fotograf = _db.Fotografs.Where(a => a.FotoTipi == Enums.FotoTipi.hizmet).FirstOrDefault();
            ViewBag.Hizmetler= _db.Hizmetlers.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Hizmetler(Hizmetler anaSayfa, IFormFile file)
        {
            System.GC.Collect();
            string webRootPath = _env.WebRootPath;
            var fotolar = _db.Fotografs.Where(a => a.FotoTipi == Enums.FotoTipi.hizmet).FirstOrDefault();
            anaSayfa.UpdatedDate = DateTime.Now;
            anaSayfa.CreatedDate = DateTime.Now;
            if (file != null && file.Length > 0)
            {
            
               
                    anaSayfa.FotoUrl = UploadFile.Upload(file, FotoTipi.hizmet);
           

                
            }
            _db.Hizmetlers.Update(anaSayfa);

            _db.SaveChanges();
            return RedirectToAction("Hizmetler", "Admin");
        }
        public IActionResult HizmetDuzenle(int id)
        {
             var ana = _db.Hizmetlers.Where(a=>a.ID==id).FirstOrDefault();
            //ViewBag.Fotograf = _db.Fotografs.Where(a => a.FotoTipi == Enums.FotoTipi.hizmet).FirstOrDefault();
           // ViewBag.Hizmetler = _db.Hizmetlers.ToList();
            return View(ana);
        }
        [HttpPost]
        public IActionResult HizmetDuzenle(Hizmetler anaSayfa, IFormFile file)
        {
            System.GC.Collect();
            var ana = _db.Hizmetlers.Where(a => a.ID == anaSayfa.ID).FirstOrDefault();

            string webRootPath = _env.WebRootPath;
            var fotolar = _db.Fotografs.Where(a => a.FotoTipi == Enums.FotoTipi.hizmet).FirstOrDefault();
            ana.UpdatedDate = DateTime.Now;
            ana.CreatedDate = DateTime.Now;

            if (file != null && file.Length > 0)
            {

                string oldFilePath = Path.Combine(webRootPath, ana.FotoUrl);
                if (System.IO.File.Exists(oldFilePath))
                {

                    System.IO.File.Delete(oldFilePath);
                }




                ana.FotoUrl = UploadFile.Upload(file, FotoTipi.hizmet);
  

            }
            _db.Hizmetlers.Update(ana);
            _db.SaveChanges();
            return RedirectToAction("Hizmetler", "Admin");
        }


		public IActionResult HizmetSil(int id)
		{
			var ana = _db.Hizmetlers.Find(id);
            _db.Hizmetlers.Remove(ana);
            _db.SaveChanges();
			//ViewBag.Fotograf = _db.Fotografs.Where(a => a.FotoTipi == Enums.FotoTipi.hizmet).FirstOrDefault();
			// ViewBag.Hizmetler = _db.Hizmetlers.ToList();
			return RedirectToAction("Hizmetler", "Admin");
		}



		public IActionResult Hakkimizda() {
            var ana = _db.Hakkimizdas.FirstOrDefault();
            ViewBag.Fotograf = _db.Fotografs.Where(a => a.FotoTipi == Enums.FotoTipi.hakkimizda).FirstOrDefault();

            return View(ana);
        }
        [HttpPost]
        public IActionResult Hakkimizda(Hakkimizda anaSayfa, IFormFile file)
        {
            System.GC.Collect();
            string webRootPath = _env.WebRootPath;
            var fotolar = _db.Fotografs.Where(a => a.FotoTipi == Enums.FotoTipi.hakkimizda).FirstOrDefault();
            anaSayfa.UpdatedDate = DateTime.Now;
            anaSayfa.CreatedDate = DateTime.Now;
            _db.Hakkimizdas.Update(anaSayfa);
            if (file != null && file.Length > 0)
            {

                string oldFilePath = Path.Combine(webRootPath, fotolar.FotoUrl);
                if (System.IO.File.Exists(oldFilePath))
                {

                    System.IO.File.Delete(oldFilePath);
                }
                _db.Fotografs.Remove(fotolar);



                Fotograf fotograf = new();

                fotograf.FotoUrl = UploadFile.Upload(file, FotoTipi.hakkimizda);
                fotograf.IslemSayfaID = anaSayfa.ID;
                fotograf.FotoTipi = FotoTipi.hakkimizda ;

                _db.Fotografs.Add(fotograf);


            }
            _db.SaveChanges();
            return RedirectToAction("Hakkimizda", "Admin");
        }
        public IActionResult Iletisim() {
            var ana = _db.Iletisims.FirstOrDefault();
            ViewBag.Fotograf = _db.Fotografs.Where(a => a.FotoTipi == Enums.FotoTipi.iletisim).FirstOrDefault();

            return View(ana);
        }
        [HttpPost]
        public IActionResult Iletisim(Iletisim anaSayfa, IFormFile file)
        {
            System.GC.Collect();
            string webRootPath = _env.WebRootPath;
            var fotolar = _db.Fotografs.Where(a => a.FotoTipi == Enums.FotoTipi.iletisim).FirstOrDefault();
            anaSayfa.UpdatedDate = DateTime.Now;
            anaSayfa.CreatedDate = DateTime.Now;
            _db.Iletisims.Update(anaSayfa);
            if (file != null && file.Length > 0)
            {

                string oldFilePath = Path.Combine(webRootPath, fotolar.FotoUrl);
                if (System.IO.File.Exists(oldFilePath))
                {

                    System.IO.File.Delete(oldFilePath);
                }

                _db.Fotografs.Remove(fotolar);


                Fotograf fotograf = new();

                fotograf.FotoUrl = UploadFile.Upload(file, FotoTipi.iletisim);
                fotograf.IslemSayfaID = anaSayfa.ID;
                fotograf.FotoTipi = FotoTipi.iletisim;

                _db.Fotografs.Add(fotograf);


            }
            _db.SaveChanges();
            return RedirectToAction("Iletisim", "Admin");
        }

    }
}
