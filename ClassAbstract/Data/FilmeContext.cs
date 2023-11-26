using ClassAbstract.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassAbstract.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> options) : base(options) { }

        public DbSet<Locadora> Locadoras { get; set; }
    }
}
