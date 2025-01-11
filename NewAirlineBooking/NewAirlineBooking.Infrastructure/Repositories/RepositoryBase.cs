using Microsoft.EntityFrameworkCore;
using NewAirlineBooking.Domain.Common;
using NewAirlineBooking.Domain.Exceptions;
using NewAirlineBooking.Domain.Interfaces;
using NewAirlineBooking.Infrastructure.Persistence;

namespace NewAirlineBooking.Infrastructure.Repositories;
internal class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
{
    protected ApplicationDbContext _context;

    public RepositoryBase(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<TEntity> GetAll()
    {
        var entities = _context.Set<TEntity>()
            .AsNoTracking()
            .ToList();

        return entities;
    }

    public TEntity GetById(int id)
    {
        var entity = GetOrThrow(id);

        return entity;
    }

    public TEntity Create(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _context.Set<TEntity>().Add(entity);

        return entity;
    }

    public void Update(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _context.Set<TEntity>().Update(entity);

    }

    public void Delete(int id)
    {
        var entity = GetOrThrow(id);

        _context.Remove(entity);
    }

    public bool Exists(int id)
        => _context.Set<TEntity>().Any(x => x.Id == id);

    private TEntity GetOrThrow(int id)
    {
        var entity = _context.Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        if (entity == null)
        {
            throw new EntityNotFoundException($"{typeof(TEntity)} with id:{id} is not found!");
        }

        return entity;
    }
}
