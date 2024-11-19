using JoseRivera_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace JoseRivera_AP1_P2.DAL;

public class Contexto:DbContext
{
    public Contexto(DbContextOptions<Contexto>options) :base(options){ }
    public DbSet<Combos> combos { get; set; }
    public DbSet<CombosDetalle> CombosDetalles { get; set; }
    public DbSet<Articulos> Articulos{ get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Articulos>().HasData(new List<Articulos>()
        {
         new Articulos() { ArticuloId=1,Nombre="Mouse",Descripcion="Del"},
         new Articulos() { ArticuloId=2,Nombre="Ram",Descripcion="64 GB"},
         new Articulos() { ArticuloId=3,Nombre="Teclado",Descripcion="Gamer 7!"},
         new Articulos() { ArticuloId=4,Nombre="Pantalla",Descripcion="40Pl"}
        } );
    }
}
