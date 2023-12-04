global using WebDiaryVersion1.DLL.Models_DLL;
global using WebDiaryVersion1.DLL;
using WebDiaryVersion1.BL;
using WebDiaryVersion1.BL.Auth;
using WebDiaryVersion1.DLL.Auth_DLL;
using WebDiaryVersion1.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMainPageDALL, MainPageDALL>();
builder.Services.AddScoped<IMainPageBL, MainPageBL>();
builder.Services.AddScoped<IAuthBL, AuthBL>();
builder.Services.AddSingleton<IEncrypt, Encrypt>();
builder.Services.AddScoped<ICurrentUser, CurrentUser>();
builder.Services.AddSingleton<IAuthDall, AuthDall>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IDbSessionDAL, DbSessionDaLL>();
builder.Services.AddScoped<IDbSession, DbSession>();
builder.Services.AddMvc();

builder.Services.AddControllersWithViews(opts =>
{
    opts.ModelBinderProviders.Insert(0, new CustomPageModelBinderProvider());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
