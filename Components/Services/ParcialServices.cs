using Francis_Castillo_P1_AP1.Components.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Francis_Castillo_P1_AP1.DAL;

namespace Francis_Castillo_P1_AP1.Services;

public class AportesService
{
    private readonly IDbContextFactory<Contexto> _DbFactory;
    private readonly ILogger<AportesService> _Logger;

    public AportesService(IDbContextFactory<Contexto> DbFactory, ILogger<AportesService> logger)
    {
        _DbFactory = DbFactory;
        _Logger = logger;
    }

    private async Task<bool> Existe(int AporteId)
    {
        await using var contexto = await _DbFactory.CreateDbContextAsync();
        return await contexto.parcialModelos.AnyAsync(a => a.AporteId == AporteId);
    }

    public async Task<bool> Existe(int aporteId, string persona, string observacion)
    {
        await using var contexto = await _DbFactory.CreateDbContextAsync();
        return await contexto.parcialModelos.AnyAsync(a => a.AporteId != aporteId
            && (a.Persona.ToLower() == persona.ToLower() || a.Observacion.ToLower() == observacion.ToLower()));
    }

    private async Task<bool> Insertar(ParcialModelo aporte)
    {
        Console.WriteLine("Usando insertar ");
        await using var contexto = await _DbFactory.CreateDbContextAsync();
        contexto.parcialModelos.Add(aporte);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(ParcialModelo aporte)
    {
        Console.WriteLine("Usando Modificar ");
        await using var contexto = await _DbFactory.CreateDbContextAsync();
        contexto.Update(aporte);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(ParcialModelo aporte)
    {
        Console.WriteLine("Usando GUARDAR ");
        if (!await Existe(aporte.AporteId))
        {
            return await Insertar(aporte);
        }
        else
        {
            return await Modificar(aporte);
        }
    }

    public async Task<ParcialModelo?> Buscar(int AporteId)
    {
        Console.WriteLine("Usando BUSCAR ");
        await using var contexto = await _DbFactory.CreateDbContextAsync();
        return await contexto.parcialModelos.FirstOrDefaultAsync(a => a.AporteId == AporteId);
    }

    public async Task<bool> Eliminar(int AporteId)
    {
        Console.WriteLine("Usando ELIMINAR ");
        await using var contexto = await _DbFactory.CreateDbContextAsync();
        return await contexto.parcialModelos
            .AsNoTracking()
            .Where(a => a.AporteId == AporteId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<ParcialModelo>> Listar(Expression<Func<ParcialModelo, bool>> criterio)
    {
        _Logger.LogInformation("Usando Listar");
        await using var contexto = await _DbFactory.CreateDbContextAsync();
        return await contexto.parcialModelos
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<double> ObtenerTotalMontos()
    {
        Console.WriteLine("Calculando total de montos");
        await using var contexto = await _DbFactory.CreateDbContextAsync();
        return await contexto.parcialModelos.SumAsync(a => a.Monto);
    }
}
