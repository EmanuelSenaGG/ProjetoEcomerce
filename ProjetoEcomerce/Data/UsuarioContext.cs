using Microsoft.EntityFrameworkCore;
using ProjetoEcomerce.Models;

namespace ProjetoEcomerce.Data
{
    public class UsuarioContext:DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options) { }

        public DbSet<UsuarioModel>Usuarios { get; set; }
    }
}
