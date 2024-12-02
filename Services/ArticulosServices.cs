using JoseRivera_AP1_P2.DAL;
using JoseRivera_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JoseRivera_AP1_P2.Services
{
    public class ArticulosServices(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> Criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Articulos
                .AsNoTracking()
                .Where(Criterio)
                .ToListAsync();
        }
        public async Task<List<Articulos>> ListarArticulos()
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Articulos
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
