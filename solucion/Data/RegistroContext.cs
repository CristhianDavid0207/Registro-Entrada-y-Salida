using Microsoft.EntityFrameworkCore;
using solucion.Models;

namespace solucion.Data
{
    public class RegistroContext : DbContext
    {
        public RegistroContext(DbContextOptions<RegistroContext> options) : base(options){

        }

        public DbSet<Employee> Employees { get; set;}
        public DbSet<Control> Controls  { get; set; }
    }
}
