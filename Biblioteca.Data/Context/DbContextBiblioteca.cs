using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data.Context
{
    public class DbContextBiblioteca : DbContext
    {
        public DbContextBiblioteca(DbContextOptions options) : base(options) { }
    }
}
