using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data.Context
{
    public class DbContextBiblioteca : DbContext
    {
        public DbContextBiblioteca(DbContextOptions options) : base(options) { }

        public DbSet<Livro> Livro { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Checkout> Checkout { get; set; }
        public DbSet<CheckoutHistorico> CheckoutHistorico { get; set; }
        public DbSet<Filial> Filial { get; set; }
        public DbSet<HorarioFuncionamento> HorarioFuncionamento { get; set; }
        public DbSet<Cartao> Cartao { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Acervo> Acervo { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
    }
}
