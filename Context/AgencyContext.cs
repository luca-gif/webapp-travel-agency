using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Context
{
    public class AgencyContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<PacchettoViaggio> pacchettiViaggi { get; set; }
        public DbSet<Categoria> categorie { get; set; }
        public DbSet<Info> informazioni { get; set; }


        public AgencyContext(DbContextOptions<AgencyContext> options)
       : base(options)
        {

        }

        public AgencyContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-agency;Integrated Security=True");
        }

    }
}
