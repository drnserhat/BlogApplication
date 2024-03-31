using BlogApplication.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

builder.Services.AddMvc();
builder.Services.AddServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalR();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.Cookie.Name = "UserDetail";
    options.AccessDeniedPath = "/Account/Login";

}
          );
builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("role", "admin"));


});
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromDays(1);
});
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Index}/{id?}");


app.Run();
