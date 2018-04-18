using Microsoft.EntityFrameworkCore;

namespace Net.Core.LoginSolucion.Api.ModeloDeDatos
{
    public class LoginDBContext : DbContext
    {
        public LoginDBContext(DbContextOptions<LoginDBContext> options):base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
