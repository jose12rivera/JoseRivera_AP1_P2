using JoseRivera_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace JoseRivera_AP1_P2.DAL
{
    public class Contexto:DbContext
    {
        public Contexto(DbContextOptions<Contexto>options) :base(options){ }
        public DbSet<Registros> Registros { get; set; }
    }
}
