using Examen_Practica.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen_Practica.Data
{
    public class PersonaDbContext : DbContext
    {
        public PersonaDbContext(DbContextOptions<PersonaDbContext> options) : base(options) 
        { 
        }
        
        public DbSet<Persona> personas { get; set; }        
    }
}
