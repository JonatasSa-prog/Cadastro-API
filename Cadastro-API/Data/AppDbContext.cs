using Cadastro_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlServer("Server=DESKTOP-3OHR665;Initial Catalog=Cadastro;Integrated Security=True;TrustServerCertificate=true");
        
    }
}
