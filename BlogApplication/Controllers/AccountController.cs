using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity;
using BlogApplication.Models;

namespace BlogApplication.Controllers
{
    public class AccountController : Controller
    {
        MyDbContext _db;
        public AccountController(MyDbContext db)
        {
            _db = db;
        }


   
        public IActionResult Login()
        {
            ViewBag.HataMesaji = "";
            return View();
        }
        // veritabanında ilgili kullanıcı var mı kontrolu
        // kullanıcının bilgilerini çekicem
        // kullanıcının şifresi kriptolu veriyle eşleşiyor mu
        // kullanıcının rolüne göre yönlendirmesi yapıcam
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (_db.Users.Any(x => x.Email == user.Email))
            {
                User selectUser = _db.Users.FirstOrDefault(x => x.Email == user.Email);
                //bool isValid = BCrypt.Net.BCrypt.Verify(user.Password, selectUser.Password);
                bool isValid = _db.Users.Where(a => a.Email == user.Email).Any(x => x.Sifre == user.Sifre);
                if (isValid)
                {
         
                    List<Claim> claims = new List<Claim>()
                    {
        
                        new Claim("TamAd",selectUser.Ad + " " + selectUser.Soyad),
                        new Claim("KullaniciAdi",selectUser.KullaniciAdi),
                        new Claim("Email",selectUser.Email),
                        new Claim("role",selectUser.Role.ToString()),
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.Session.SetString("userName", selectUser.KullaniciAdi);
                    HttpContext.Session.SetString("userEmail", selectUser.Email);
                    HttpContext.Session.SetString("fullName", selectUser.Ad + " " + selectUser.Soyad);
                    HttpContext.Session.SetString("userId", selectUser.ID.ToString());

                    await HttpContext.SignInAsync(principal);


                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.HataMesaji = "Email veya Şifre Yanlış!";
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
