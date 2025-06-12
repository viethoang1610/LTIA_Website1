using LTIA_website.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// 1) Localization
builder.Services.AddLocalization(opts => opts.ResourcesPath = "Resources");

// 2) EF Core + SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 3) Identity
builder.Services.AddDefaultIdentity<IdentityUser>(opts =>
{
    opts.SignIn.RequireConfirmedAccount = true;
    opts.Password.RequireDigit = true;
    opts.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// 4) (Tuỳ chọn) External Authentication
// builder.Services.AddAuthentication()
//     .AddGoogle(opts => { /* ... */ })
//     .AddFacebook(opts => { /* ... */ })
//     .AddApple(opts => { /* ... */ });

// 5) MVC + ViewLocalization + DataAnnotations Localization
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();
builder.Services.AddSession();
// 6) Razor Pages (cần cho Identity UI)
builder.Services.AddRazorPages();

var app = builder.Build();

// 7) Request Localization Middleware
var cultures = new[] { new CultureInfo("vi"), new CultureInfo("en") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("vi"),
    SupportedCultures = cultures,
    SupportedUICultures = cultures
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

// 8) Endpoints
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
