using CrudNet7.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudNet7.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        { 
        
        }

        //Agregamos los modelos en esta parte
        public DbSet<Contacto> Contact { get; set; }
    }
}
