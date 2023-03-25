using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VoteWithYourWallet.Models;

namespace VoteWithYourWallet.Areas.Identity.Data;

public class VoteWithYourWalletIdentityDbContext : IdentityDbContext<IdentityUser>
{
    public VoteWithYourWalletIdentityDbContext(DbContextOptions<VoteWithYourWalletIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityUser>().Ignore(c => c.AccessFailedCount)
                                           .Ignore(c => c.LockoutEnabled);
                                      
                                       

        builder.Entity<IdentityUser>().ToTable("users");//to change the name of table.
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<ApplicationUser> users { get; set; }
    public DbSet<Cause> causes { get; set; }
    public DbSet<Signature> signatures { get; set; }


}

