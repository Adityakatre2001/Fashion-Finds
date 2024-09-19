using FashionFinds.DataAccess.Repository;
using FashionFinds.DataAccess.Repository.IRepository;
using FashionFinds.DataAcess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using FashionFinds.Utility;
using Stripe;
using FashionFinds.DataAccess.DbInitializer;

var builder = WebApplication.CreateBuilder(args);

// to add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options=> 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

builder.Services.AddIdentity<IdentityUser,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
/*builder.Services.AddAuthentication().AddFacebook(option => {
    option.AppId = "193813826680436";// facebook-app-id
    option.AppSecret = "8fc42ae3f4f2a4986143461d4e2da919";//facebook-app-secret
});
builder.Services.AddAuthentication().AddMicrosoftAccount(option => {
    option.ClientId = "ec4d380d-d631-465d-b473-1e26ee706331";  // microsoft-client-id
    option.ClientSecret = "qMW8Q~LlEEZST~SDxDgcEVx_45LJQF2cQ_rEKcSQ";  // microsoft-client-secret
});*/

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IDbInitializer, DbInitializer>(); // for initializing db
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // for managing data operaations
builder.Services.AddScoped<IEmailSender, EmailSender>(); // for sending mails
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // this is used to Redirects HTTP requests to HTTPS. this ensures that all traffic of our application is encrypted and secure
app.UseStaticFiles(); //  Serves static files like CSS, JavaScript, and images from wwwroot directory.
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
app.UseRouting();
app.UseAuthentication(); // to enable authentication
app.UseAuthorization(); // to enable authorization
app.UseSession();
SeedDatabase();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();


void SeedDatabase() {
    using (var scope = app.Services.CreateScope()) {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}
