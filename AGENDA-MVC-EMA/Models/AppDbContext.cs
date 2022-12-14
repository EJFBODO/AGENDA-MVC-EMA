using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AGENDA_MVC_EMA.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>

    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Contactos> Contactos { get; set; }
    }

}

