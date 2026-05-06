using AppEscala.AppDatabase;
using AppEscala.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppEscala.Models.Services;

internal sealed class AcolitoServices
{
    private readonly IUnitOfWork unitOfWork;
    public AcolitoServices(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<AcolitoEntity> GetAcolitoByIdAsync(int acolitoId)
    {
        return await unitOfWork
            .Set<AcolitoEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == acolitoId)
            ?? throw new InvalidOperationException("Acólito nao encontrado.");
    }

    public async Task<List<AcolitoEntity>> GetAcolitosAsync()
    {
        return await unitOfWork
            .Set<AcolitoEntity>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<AcolitoDisponibilidadeEntity>> GetAcolitosDisponibilidadeAsync()
    {
        return await unitOfWork
            .Set<AcolitoDisponibilidadeEntity>()
            .Include(x => x.Acolito)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<AcolitoDisponibilidadeEntity>> GetAcolitoDisponibilidadeByIdAsync(int acolitoId)
    {
        return await unitOfWork
            .Set<AcolitoDisponibilidadeEntity>()
            .Include(x => x.Acolito)
            .AsNoTracking()
            .Where(e => e.AcolitoId == acolitoId)
            .ToListAsync();
    }

    public async Task<List<AcolitoCompromissosEntity>> GetAcolitosCompromissosAsync()
    {
        return await unitOfWork
            .Set<AcolitoCompromissosEntity>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<AcolitoCompromissosEntity>> GetAcolitoCompromissosByIdAsync(int acolitoId)
    {
        return await unitOfWork
            .Set<AcolitoCompromissosEntity>()
            .AsNoTracking()
            .Where(e => e.Id_acolitos == acolitoId)
            .ToListAsync();
    }
}
