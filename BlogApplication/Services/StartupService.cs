
using BlogApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Services
{
    public static class StartupService
    {
        
        public static void AddServices(this IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
  
        }
    }
}
