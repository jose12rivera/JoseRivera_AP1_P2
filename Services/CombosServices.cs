using JoseRivera_AP1_P2.DAL;
using JoseRivera_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Linq.Expressions;

namespace JoseRivera_AP1_P2.Services;

public class CombosServices(IDbContextFactory<Contexto> DbFactory)
{

    public async Task<bool> Existe(int ComboId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.combos.AnyAsync(r => r.ComboId == ComboId);
    }

    private async Task<bool> Insertar(Combos combo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.combos.Add(combo);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Combos combo)
    {
        if (!await Existe(combo.ComboId))
            return await Insertar(combo);
        else
            return await Modificar(combo);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminado = await contexto.combos
            .Include(c => c.CombosDetalles)
            .Where(r => r.ComboId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    public async Task<Combos?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.combos
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.ComboId == id);
    }
    private async Task<bool> Modificar(Combos combo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var entidadExistente = contexto.combos
            .Include(c => c.CombosDetalles)
            .FirstOrDefault(c => c.ComboId == combo.ComboId);

        if (entidadExistente != null)
        {

            foreach (var detalle in entidadExistente.CombosDetalles.ToList())
            {
                if (!combo.CombosDetalles.Any(d => d.DetalleId == detalle.DetalleId))
                {
                    contexto.Entry(detalle).State = EntityState.Deleted;
                }
            }

            contexto.Entry(entidadExistente).CurrentValues.SetValues(combo);
            entidadExistente.CombosDetalles = combo.CombosDetalles;
        }

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> EliminarDetalle(int detalleId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var detalle = await contexto.CombosDetalles
            .FirstOrDefaultAsync(d => d.DetalleId == detalleId);

        if (detalle != null)
        {
            contexto.CombosDetalles.Remove(detalle);
            return await contexto.SaveChangesAsync() > 0;
        }

        return false;
    }
    public async Task<List<Combos>> Listar(Expression<Func<Combos, bool>> Criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.combos
            .Include(c => c.CombosDetalles)
            .Where(Criterio)
            .ToListAsync();
    }

    public async Task<List<Combos>> ListarCombos()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.combos
            .AsNoTracking()
            .ToListAsync();
    }
}
