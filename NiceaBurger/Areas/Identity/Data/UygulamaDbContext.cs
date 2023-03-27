using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NiceaBurger.Areas.Identity.Data;

namespace NiceaBurger.Areas.Identity.Data;

public class UygulamaDbContext : IdentityDbContext<Kullanici>
{
    public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<Menu> Menu { get; set; }

    public DbSet<EkstraMalzeme> EkstraMalzeme { get; set; }

    public DbSet<NiceaBurger.Areas.Identity.Data.SiparisUrun> SiparisUrun { get; set; }
}
