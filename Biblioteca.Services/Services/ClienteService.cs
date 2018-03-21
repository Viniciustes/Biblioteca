using Biblioteca.Data.Context;
using Biblioteca.Data.Interfaces;
using Biblioteca.Data.Models;

namespace Biblioteca.Services.Services
{
    public class ClienteService : BaseService, ICliente
    {
        public ClienteService(DbContextBiblioteca dbContextBiblioteca)
        {
            _db = dbContextBiblioteca;
        }

        public void Add(Cliente cliente)
        {
                _db.Add(cliente);
                _db.SaveChanges();
        }
    }
}
