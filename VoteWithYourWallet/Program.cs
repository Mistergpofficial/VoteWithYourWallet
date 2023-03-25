using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VoteWithYourWallet.Areas.Identity.Data;
using VoteWithYourWallet.Models;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("VoteWithYourWalletIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'VoteWithYourWalletIdentityDbContextConnection' not found.");
//var connectionString = builder.Configuration.GetConnectionString("VoteWithYourWalletIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'VoteWithYourWalletIdentityDbContextConnection' not found.");
// Replace with your connection string.
var connectionString = "server=localhost;port=3307;user=root;password=;database=voters";

// Replace with your server version and type.
// Use 'MariaDbServerVersion' for MariaDB.
// Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
// For common usages, see pull request #1233.
var serverVersion = new MySqlServerVersion(new Version(10, 4, 21));

//builder.Services.AddDbContext<VoteWithYourWalletIdentityDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<VoteWithYourWalletIdentityDbContext>(options => options.UseMySql(connectionString, serverVersion));
//UseMySQL
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<VoteWithYourWalletIdentityDbContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options =>
{
    //Location for your Custom Access Denied Page
    options.AccessDeniedPath = "/Account/AccessDenied";

    //Location for your Custom Login Page
    options.LoginPath = "/Account/Login";

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

