using JoseRivera_AP1_P2.DAL;
using JoseRivera_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JoseRivera_AP1_P2.Services;

public class RegistroServices(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool>Existe(int RegistroId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.registros.AnyAsync(r=>r.RegistroId == RegistroId);    
    }

    private async Task<bool> Insertar(Registros registro)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.registros.Add(registro);
       return await contexto.SaveChangesAsync()>0;
    }
    private async Task<bool> Modificar(Registros registro)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.registros.Update(registro);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task <bool>Guardar(Registros registro)
    {
        if(!await Existe(registro.RegistroId)) 
            return await Insertar(registro);
        else
            return await Modificar(registro);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminado= await contexto.registros
            .Where(r=>r.RegistroId==id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    public async Task<Registros?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.registros
            .AsNoTracking()
            .FirstOrDefaultAsync(r=>r.RegistroId==id);
    }

    public async Task <List<Registros>>Listar(Expression<Func<Registros, bool>> Criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.registros
            .AsNoTracking()
            .Where(Criterio)
            .ToListAsync();
    }
}
