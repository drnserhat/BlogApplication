using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using BlogApplication.Models;


namespace BlogApplication.Views.Shared.Components.User
{
    public class UserViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MyDbContext _db;


        public UserViewComponent(MyDbContext db,IHttpContextAccessor httpContextAccessor)
        {

          _db = db;
            _httpContextAccessor = httpContextAccessor;


        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ana = _db.AnaSayfas.FirstOrDefault();

            //string BildirimListeJson = JsonConvert.SerializeObject(BildirimListe);
            //HttpContext.Session.SetString("kullaniciBildirim", BildirimListeJson);
            //HttpContext.Session.SetString("userFoto", user.PP);

            return View(ana);
        }
    }
}
